using ARMeilleure.CodeGen.RegisterAllocators;
using ARMeilleure.IntermediateRepresentation;
using System.IO;
using System.Numerics;

namespace ARMeilleure.CodeGen.X86
{
    class CodeGenContext
    {
        private readonly Stream _stream;
        private readonly Operand[] _blockLabels;

        public int StreamOffset => (int)_stream.Length;

        public AllocationResult AllocResult { get; }

        public Assembler Assembler { get; }
        public BasicBlock CurrBlock { get; private set; }

        public int CallArgsRegionSize { get; }
        public int XmmSaveRegionSize { get; }

        public CodeGenContext(AllocationResult allocResult, int maxCallArgs, int blocksCount, bool relocatable)
        {
            _stream = new MemoryStream();
            _blockLabels = new Operand[blocksCount];

            AllocResult = allocResult;
            Assembler = new Assembler(_stream, relocatable);

            CallArgsRegionSize = GetCallArgsRegionSize(allocResult, maxCallArgs, out int xmmSaveRegionSize);
            XmmSaveRegionSize  = xmmSaveRegionSize;
        }

        private static int GetCallArgsRegionSize(AllocationResult allocResult, int maxCallArgs, out int xmmSaveRegionSize)
        {
            // We need to add 8 bytes to the total size, as the call to this function already pushed 8 bytes (the
            // return address).
            int intMask = CallingConvention.GetIntCalleeSavedRegisters() & allocResult.IntUsedRegisters;
            int vecMask = CallingConvention.GetVecCalleeSavedRegisters() & allocResult.VecUsedRegisters;

            xmmSaveRegionSize = BitOperations.PopCount((uint)vecMask) * 16;

            int calleeSaveRegionSize = BitOperations.PopCount((uint)intMask) * 8 + xmmSaveRegionSize + 8;

            int argsCount = maxCallArgs;

            if (argsCount < 0)
            {
                // When the function has no calls, argsCount is -1. In this case, we don't need to allocate the shadow
                // space.
                argsCount = 0;
            }
            else if (argsCount < 4)
            {
                // The ABI mandates that the space for at least 4 arguments is reserved on the stack (this is called
                // shadow space).
                argsCount = 4;
            }

            // Align XMM save region to 16 bytes because unwinding on Windows requires it.
            xmmSaveRegionSize = xmmSaveRegionSize * 16;
            
            int frameSize = calleeSaveRegionSize + allocResult.SpillRegionSize;

            
            int callArgsAndFrameSize = frameSize + argsCount * 16;

            // Ensure that the Stack Pointer will be aligned to 16 bytes.
            callArgsAndFrameSize = (callArgsAndFrameSize + 0xf) & ~0xf;

            return callArgsAndFrameSize - frameSize;
        }

        public void EnterBlock(BasicBlock block)
        {
            Assembler.MarkLabel(GetLabel(block));

            CurrBlock = block;
        }

        public void JumpTo(BasicBlock target)
        {
            Assembler.Jmp(GetLabel(target));
        }

        public void JumpTo(X86Condition condition, BasicBlock target)
        {
            Assembler.Jcc(condition, GetLabel(target));
        }

        private Operand GetLabel(BasicBlock block)
        {
            ref Operand label = ref _blockLabels[block.Index];

            if (label == default)
            {
                label = Operand.Factory.Label();
            }

            return label;
        }
    }
}