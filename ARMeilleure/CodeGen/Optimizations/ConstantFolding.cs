using ARMeilleure.IntermediateRepresentation;
using System;
using static ARMeilleure.IntermediateRepresentation.Operand.Factory;

namespace ARMeilleure.CodeGen.Optimizations
{
    static class ConstantFolding
    {
        static Operation operation;
        public static OperandType type = operation.Destination.Type;

        public static void FunctionAdd(Operation operation)
        {
            if (operation.GetSource(0).Relocatable ||
                      operation.GetSource(1).Relocatable)
            {
                return;
            }
            else if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x + y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x + y);
            }
        }
        public static void FunctionBitwiseAnd(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x & y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x & y);
            }
        }
        public static void FuncitonBitwiseExclusiveOr(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x ^ y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x ^ y);
            }
        }
        public static void FunctionBitwiseNot(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => ~x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => ~x);
            }
        }
        public static void FunctionBitwiseOr(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x | y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x | y);
            }
        }
        public static void FunctionConvertI64ToI32(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => x);
            }
        }
        public static void FunctionCopy(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => x);
            }
        }
        public static void FunctionDivide(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => y != 0 ? x / y : 0);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => y != 0 ? x / y : 0);
            }
        }
        public static void FunctionDivideUI(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => y != 0 ? (int)((uint)x / (uint)y) : 0);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => y != 0 ? (long)((ulong)x / (ulong)y) : 0);
            }
        }
        public static void FunctionMultiply(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x * y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x * y);
            }
        }
        public static void FunctionNegate(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => -x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => -x);
            }
        }
        public static void FunctionShiftLeft(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x << y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x << (int)y);
            }
        }
        public static void FunctionShiftRightSI(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x >> y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x >> (int)y);
            }
        }
        public static void FunctionShiftRightUI(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => (int)((uint)x >> y));
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => (long)((ulong)x >> (int)y));
            }
        }
        public static void FunctionSignExtend16(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => (short)x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (short)x);
            }
        }
        public static void FunctionSignExtend32(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (int)x);
            }
        }
        public static void FunctionSignExtend8(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => (sbyte)x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (sbyte)x);
            }
        }
        public static void FunctionZeroExtend16(Operation operation)
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => (ushort)x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (ushort)x);
            }
        }
        public static void FunctionZeroExtend32(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (uint)x);
            }
        }
        public static void FunctionZeroExtend8(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateUnaryI32(operation, (x) => (byte)x);
            }
            else if (type == OperandType.I64)
            {
                EvaluateUnaryI64(operation, (x) => (byte)x);
            }
        }
        public static void FunctionSubtract(Operation operation) 
        {
            if (type == OperandType.I32)
            {
                EvaluateBinaryI32(operation, (x, y) => x - y);
            }
            else if (type == OperandType.I64)
            {
                EvaluateBinaryI64(operation, (x, y) => x - y);
            }
        }

        public static void RunPass(Operation operation)
        {
            if (operation.Destination == default || operation.SourcesCount == 0 || !AreAllSourcesConstant(operation))
            {
                return;
            }
           // OperandType type = operation.Destination.Type;
            if (operation.Instruction == Instruction.Add)
            {
                FunctionAdd(operation);
            }
            else if (operation.Instruction == Instruction.BitwiseAnd)
            {
                FunctionBitwiseAnd(operation);
            }
            else if (operation.Instruction == Instruction.BitwiseExclusiveOr)
            {
                FuncitonBitwiseExclusiveOr(operation);
            }
            else if (operation.Instruction == Instruction.BitwiseNot)
            {
                FunctionBitwiseNot(operation);
            }
            else if (operation.Instruction == Instruction.BitwiseOr)
            {
                FunctionBitwiseOr(operation);
            }
            else if (operation.Instruction == Instruction.ConvertI64ToI32)
            {
                FunctionConvertI64ToI32(operation);
            }
            else if (operation.Instruction == Instruction.Copy)
            {
                FunctionCopy(operation);
            }
            else if (operation.Instruction == Instruction.Divide)
            {
                FunctionDivide(operation);
            }
            else if (operation.Instruction == Instruction.DivideUI)
            {
                FunctionDivideUI(operation);
            }
            else if (operation.Instruction == Instruction.Multiply)
            {
                FunctionMultiply(operation);
            }
            else if (operation.Instruction == Instruction.Negate)
            {
                FunctionNegate(operation);
            }
            else if (operation.Instruction == Instruction.ShiftLeft)
            {
                FunctionShiftLeft(operation);
            }
            else if (operation.Instruction == Instruction.ShiftRightSI)
            {
                FunctionShiftRightSI(operation);
            }
            else if (operation.Instruction == Instruction.ShiftRightUI)
            {
                FunctionShiftRightUI(operation);
            }
            else if (operation.Instruction == Instruction.SignExtend16)
            {
                FunctionSignExtend16(operation);
            }
            else if (operation.Instruction == Instruction.SignExtend32)
            {
                FunctionSignExtend32(operation);
            }
            else if (operation.Instruction == Instruction.SignExtend8)
            {
                FunctionSignExtend8(operation);
            }
            else if (operation.Instruction == Instruction.ZeroExtend16)
            {
                FunctionZeroExtend16(operation);
            }
            else if (operation.Instruction == Instruction.ZeroExtend32)
            {
                FunctionZeroExtend32(operation);
            }
            else if (operation.Instruction == Instruction.ZeroExtend8)
            {
                FunctionZeroExtend8(operation);
            }
            else if (operation.Instruction == Instruction.Subtract)
            {
                FunctionSubtract(operation);
            }
        }

        private static bool AreAllSourcesConstant(Operation operation)
        {
            for (int index = 0; index < operation.SourcesCount; index++)
            {
                Operand srcOp = operation.GetSource(index);

                if (srcOp.Kind != OperandKind.Constant)
                {
                    return false;
                }
            }

            return true;
        }

        private static void EvaluateUnaryI32(Operation operation, Func<int, int> op)
        {
            int x = operation.GetSource(0).AsInt32();

            operation.TurnIntoCopy(Const(op(x)));
        }

        private static void EvaluateUnaryI64(Operation operation, Func<long, long> op)
        {
            long x = operation.GetSource(0).AsInt64();

            operation.TurnIntoCopy(Const(op(x)));
        }

        private static void EvaluateBinaryI32(Operation operation, Func<int, int, int> op)
        {
            int x = operation.GetSource(0).AsInt32();
            int y = operation.GetSource(1).AsInt32();

            operation.TurnIntoCopy(Const(op(x, y)));
        }

        private static void EvaluateBinaryI64(Operation operation, Func<long, long, long> op)
        {
            long x = operation.GetSource(0).AsInt64();
            long y = operation.GetSource(1).AsInt64();

            operation.TurnIntoCopy(Const(op(x, y)));
        }
    }
}