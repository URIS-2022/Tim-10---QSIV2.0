﻿using Ryujinx.Common.Memory;
using Ryujinx.Graphics.Nvdec.Vp9.Types;

namespace Ryujinx.Graphics.Nvdec.Vp9
{
    internal static class Luts
    {
        public static readonly byte[] SizeGroupLookup = new byte[]
        {
            0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3
        };

        public static readonly BlockSize[][] SubsizeLookup = new BlockSize[][]
        {
            new BlockSize[]
            { // PARTITION_NONE
                BlockSize.Block4x4, BlockSize.Block4x8, BlockSize.Block8x4, BlockSize.Block8x8, BlockSize.Block8x16, BlockSize.Block16x8,
                BlockSize.Block16x16, BlockSize.Block16x32, BlockSize.Block32x16, BlockSize.Block32x32, BlockSize.Block32x64,
                BlockSize.Block64x32, BlockSize.Block64x64
            },
            new BlockSize[]
            { // PARTITION_HORZ
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block8x4, BlockSize.BlockInvalid,
                BlockSize.BlockInvalid, BlockSize.Block16x8, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block32x16,
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block64x32
            },
            new BlockSize[]
            { // PARTITION_VERT
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block4x8, BlockSize.BlockInvalid,
                BlockSize.BlockInvalid, BlockSize.Block8x16, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block16x32,
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block32x64
            },
            new BlockSize[]
            { // PARTITION_SPLIT
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block4x4, BlockSize.BlockInvalid,
                BlockSize.BlockInvalid, BlockSize.Block8x8, BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block16x16,
                BlockSize.BlockInvalid, BlockSize.BlockInvalid, BlockSize.Block32x32
            }
        };

        public static readonly TxSize[] MaxTxSizeLookup = new TxSize[]
        {
            TxSize.Tx4x4,   TxSize.Tx4x4,   TxSize.Tx4x4,   TxSize.Tx8x8,   TxSize.Tx8x8,   TxSize.Tx8x8,  TxSize.Tx16x16,
            TxSize.Tx16x16, TxSize.Tx16x16, TxSize.Tx32x32, TxSize.Tx32x32, TxSize.Tx32x32, TxSize.Tx32x32
        };

        public static readonly TxSize[] TxModeToBiggestTxSize = new TxSize[]
        {
            TxSize.Tx4x4,    // ONLY_4X4
            TxSize.Tx8x8,    // ALLOW_8X8
            TxSize.Tx16x16,  // ALLOW_16X16
            TxSize.Tx32x32,  // ALLOW_32X32
            TxSize.Tx32x32,  // TX_MODE_SELECT
        };

        public static readonly BlockSize[][][] SsSizeLookup = new BlockSize[][][]
        {
            //  ss_x == 0    ss_x == 0        ss_x == 1      ss_x == 1
            //  ss_y == 0    ss_y == 1        ss_y == 0      ss_y == 1
            new BlockSize[][] { new BlockSize[] { BlockSize.Block4x4, BlockSize.BlockInvalid }, new BlockSize[] { BlockSize.BlockInvalid, BlockSize.BlockInvalid } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block4x8, BlockSize.Block4x4 }, new BlockSize[] { BlockSize.BlockInvalid, BlockSize.BlockInvalid } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block8x4, BlockSize.BlockInvalid }, new BlockSize[] { BlockSize.Block4x4, BlockSize.BlockInvalid } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block8x8, BlockSize.Block8x4 }, new BlockSize[] { BlockSize.Block4x8, BlockSize.Block4x4 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block8x16, BlockSize.Block8x8 }, new BlockSize[] { BlockSize.BlockInvalid, BlockSize.Block4x8 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block16x8, BlockSize.BlockInvalid }, new BlockSize[] { BlockSize.Block8x8, BlockSize.Block8x4 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block16x16, BlockSize.Block16x8 }, new BlockSize[] { BlockSize.Block8x16, BlockSize.Block8x8 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block16x32, BlockSize.Block16x16 }, new BlockSize[] { BlockSize.BlockInvalid, BlockSize.Block8x16 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block32x16, BlockSize.BlockInvalid }, new BlockSize[] { BlockSize.Block16x16, BlockSize.Block16x8 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block32x32, BlockSize.Block32x16 }, new BlockSize[] { BlockSize.Block16x32, BlockSize.Block16x16 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block32x64, BlockSize.Block32x32 }, new BlockSize[] { BlockSize.BlockInvalid, BlockSize.Block16x32 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block64x32, BlockSize.BlockInvalid }, new BlockSize[] { BlockSize.Block32x32, BlockSize.Block32x16 } },
            new BlockSize[][] { new BlockSize[] { BlockSize.Block64x64, BlockSize.Block64x32 }, new BlockSize[] { BlockSize.Block32x64, BlockSize.Block32x32 } },
        };

        public static readonly TxSize[][][][] UvTxsizeLookup = new TxSize[][][][]
        {
          //  ss_x == 0    ss_x == 0        ss_x == 1      ss_x == 1
          //  ss_y == 0    ss_y == 1        ss_y == 0      ss_y == 1
          new TxSize[][][]
          {
              // BLOCK_4X4
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
          },
          new TxSize[][][]
          {
              // BLOCK_4X8
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
          },
          new TxSize[][][]
          {
              // BLOCK_8X4
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
          },
          new TxSize[][][]
          {
              // BLOCK_8X8
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
          },
          new TxSize[][][]
          {
              // BLOCK_8X16
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
          },
          new TxSize[][][]
          {
              // BLOCK_16X8
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
          },
          new TxSize[][][]
          {
              // BLOCK_16X16
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
          },
          new TxSize[][][]
          {
              // BLOCK_16X32
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
          },
          new TxSize[][][]
          {
              // BLOCK_32X16
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx8x8 } },
          },
          new TxSize[][][]
          {
              // BLOCK_32X32
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx32x32, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
          },
          new TxSize[][][]
          {
              // BLOCK_32X64
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx32x32, TxSize.Tx32x32 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
          },
          new TxSize[][][]
          {
              // BLOCK_64X32
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx32x32, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx32x32, TxSize.Tx16x16 } },
          },
          new TxSize[][][]
          {
              // BLOCK_64X64
              new TxSize[][] { new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 }, new TxSize[] { TxSize.Tx4x4, TxSize.Tx4x4 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 }, new TxSize[] { TxSize.Tx8x8, TxSize.Tx8x8 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 }, new TxSize[] { TxSize.Tx16x16, TxSize.Tx16x16 } },
              new TxSize[][] { new TxSize[] { TxSize.Tx32x32, TxSize.Tx32x32 }, new TxSize[] { TxSize.Tx32x32, TxSize.Tx32x32 } },
          },
        };

        public struct PartitionContextPair
        {
            public sbyte Above;
            public sbyte Left;

            public PartitionContextPair(sbyte above, sbyte left)
            {
                Above = above;
                Left = left;
            }
        }

        // Generates 4 bit field in which each bit set to 1 represents
        // a blocksize partition  1111 means we split 64x64, 32x32, 16x16
        // and 8x8. 1000 means we just split the 64x64 to 32x32
        public static readonly PartitionContextPair[] PartitionContextLookup = new PartitionContextPair[]
        {
            new PartitionContextPair(15, 15),  // 4X4   - {0b1111, 0b1111}
            new PartitionContextPair(15, 14),  // 4X8   - {0b1111, 0b1110}
            new PartitionContextPair(14, 15),  // 8X4   - {0b1110, 0b1111}
            new PartitionContextPair(14, 14),  // 8X8   - {0b1110, 0b1110}
            new PartitionContextPair(14, 12),  // 8X16  - {0b1110, 0b1100}
            new PartitionContextPair(12, 14),  // 16X8  - {0b1100, 0b1110}
            new PartitionContextPair(12, 12),  // 16X16 - {0b1100, 0b1100}
            new PartitionContextPair(12, 8),   // 16X32 - {0b1100, 0b1000}
            new PartitionContextPair(8, 12),   // 32X16 - {0b1000, 0b1100}
            new PartitionContextPair(8, 8),    // 32X32 - {0b1000, 0b1000}
            new PartitionContextPair(8, 0),    // 32X64 - {0b1000, 0b0000}
            new PartitionContextPair(0, 8),    // 64X32 - {0b0000, 0b1000}
            new PartitionContextPair(0, 0),    // 64X64 - {0b0000, 0b0000}
        };

        // Filter

        private static readonly Array8<short>[] BilinearFilters = new Array8<short>[]
        {
            NewArray8Short(0, 0, 0, 128, 0, 0, 0, 0),  NewArray8Short(0, 0, 0, 120, 8, 0, 0, 0),
            NewArray8Short(0, 0, 0, 112, 16, 0, 0, 0), NewArray8Short(0, 0, 0, 104, 24, 0, 0, 0),
            NewArray8Short(0, 0, 0, 96, 32, 0, 0, 0),  NewArray8Short(0, 0, 0, 88, 40, 0, 0, 0),
            NewArray8Short(0, 0, 0, 80, 48, 0, 0, 0),  NewArray8Short(0, 0, 0, 72, 56, 0, 0, 0),
            NewArray8Short(0, 0, 0, 64, 64, 0, 0, 0),  NewArray8Short(0, 0, 0, 56, 72, 0, 0, 0),
            NewArray8Short(0, 0, 0, 48, 80, 0, 0, 0),  NewArray8Short(0, 0, 0, 40, 88, 0, 0, 0),
            NewArray8Short(0, 0, 0, 32, 96, 0, 0, 0),  NewArray8Short(0, 0, 0, 24, 104, 0, 0, 0),
            NewArray8Short(0, 0, 0, 16, 112, 0, 0, 0), NewArray8Short(0, 0, 0, 8, 120, 0, 0, 0)
        };

        // Lagrangian interpolation filter
        private static readonly Array8<short>[] SubPelFilters8 = new Array8<short>[]
        {
            NewArray8Short(0, 0, 0, 128, 0, 0, 0, 0),        NewArray8Short(0, 1, -5, 126, 8, -3, 1, 0),
            NewArray8Short(-1, 3, -10, 122, 18, -6, 2, 0),   NewArray8Short(-1, 4, -13, 118, 27, -9, 3, -1),
            NewArray8Short(-1, 4, -16, 112, 37, -11, 4, -1), NewArray8Short(-1, 5, -18, 105, 48, -14, 4, -1),
            NewArray8Short(-1, 5, -19, 97, 58, -16, 5, -1),  NewArray8Short(-1, 6, -19, 88, 68, -18, 5, -1),
            NewArray8Short(-1, 6, -19, 78, 78, -19, 6, -1),  NewArray8Short(-1, 5, -18, 68, 88, -19, 6, -1),
            NewArray8Short(-1, 5, -16, 58, 97, -19, 5, -1),  NewArray8Short(-1, 4, -14, 48, 105, -18, 5, -1),
            NewArray8Short(-1, 4, -11, 37, 112, -16, 4, -1), NewArray8Short(-1, 3, -9, 27, 118, -13, 4, -1),
            NewArray8Short(0, 2, -6, 18, 122, -10, 3, -1),   NewArray8Short(0, 1, -3, 8, 126, -5, 1, 0)
        };

        // DCT based filter
        private static readonly Array8<short>[] SubPelFilters8S = new Array8<short>[]
        {
            NewArray8Short(0, 0, 0, 128, 0, 0, 0, 0),         NewArray8Short(-1, 3, -7, 127, 8, -3, 1, 0),
            NewArray8Short(-2, 5, -13, 125, 17, -6, 3, -1),   NewArray8Short(-3, 7, -17, 121, 27, -10, 5, -2),
            NewArray8Short(-4, 9, -20, 115, 37, -13, 6, -2),  NewArray8Short(-4, 10, -23, 108, 48, -16, 8, -3),
            NewArray8Short(-4, 10, -24, 100, 59, -19, 9, -3), NewArray8Short(-4, 11, -24, 90, 70, -21, 10, -4),
            NewArray8Short(-4, 11, -23, 80, 80, -23, 11, -4), NewArray8Short(-4, 10, -21, 70, 90, -24, 11, -4),
            NewArray8Short(-3, 9, -19, 59, 100, -24, 10, -4), NewArray8Short(-3, 8, -16, 48, 108, -23, 10, -4),
            NewArray8Short(-2, 6, -13, 37, 115, -20, 9, -4),  NewArray8Short(-2, 5, -10, 27, 121, -17, 7, -3),
            NewArray8Short(-1, 3, -6, 17, 125, -13, 5, -2),   NewArray8Short(0, 1, -3, 8, 127, -7, 3, -1)
        };

        // freqmultiplier = 0.5
        private static readonly Array8<short>[] SubPelFilters8Lp = new Array8<short>[]
        {
            NewArray8Short(0, 0, 0, 128, 0, 0, 0, 0),       NewArray8Short(-3, -1, 32, 64, 38, 1, -3, 0),
            NewArray8Short(-2, -2, 29, 63, 41, 2, -3, 0),   NewArray8Short(-2, -2, 26, 63, 43, 4, -4, 0),
            NewArray8Short(-2, -3, 24, 62, 46, 5, -4, 0),   NewArray8Short(-2, -3, 21, 60, 49, 7, -4, 0),
            NewArray8Short(-1, -4, 18, 59, 51, 9, -4, 0),   NewArray8Short(-1, -4, 16, 57, 53, 12, -4, -1),
            NewArray8Short(-1, -4, 14, 55, 55, 14, -4, -1), NewArray8Short(-1, -4, 12, 53, 57, 16, -4, -1),
            NewArray8Short(0, -4, 9, 51, 59, 18, -4, -1),   NewArray8Short(0, -4, 7, 49, 60, 21, -3, -2),
            NewArray8Short(0, -4, 5, 46, 62, 24, -3, -2),   NewArray8Short(0, -4, 4, 43, 63, 26, -2, -2),
            NewArray8Short(0, -3, 2, 41, 63, 29, -2, -2),   NewArray8Short(0, -3, 1, 38, 64, 32, -1, -3)
        };

        private static Array8<short> NewArray8Short(short e0, short e1, short e2, short e3, short e4, short e5, short e6, short e7)
        {
            Array8<short> output = new Array8<short>();

            output[0] = e0;
            output[1] = e1;
            output[2] = e2;
            output[3] = e3;
            output[4] = e4;
            output[5] = e5;
            output[6] = e6;
            output[7] = e7;

            return output;
        }

        public static readonly Array8<short>[][] Vp9FilterKernels = new Array8<short>[][]
        {
            SubPelFilters8, SubPelFilters8Lp, SubPelFilters8S, BilinearFilters
        };

        // Scan

        private static readonly short[] DefaultScan4X4 = new short[]
        {
            0, 4, 1, 5, 8, 2, 12, 9, 3, 6, 13, 10, 7, 14, 11, 15,
        };

        private static readonly short[] ColScan4X4 = new short[]
        {
            0, 4, 8, 1, 12, 5, 9, 2, 13, 6, 10, 3, 7, 14, 11, 15,
        };

        private static readonly short[] RowScan4X4 = new short[]
        {
            0, 1, 4, 2, 5, 3, 6, 8, 9, 7, 12, 10, 13, 11, 14, 15,
        };

        private static readonly short[] DefaultScan8X8 = new short[]
        {
            0,  8,  1,  16, 9,  2,  17, 24, 10, 3,  18, 25, 32, 11, 4,  26,
            33, 19, 40, 12, 34, 27, 5,  41, 20, 48, 13, 35, 42, 28, 21, 6,
            49, 56, 36, 43, 29, 7,  14, 50, 57, 44, 22, 37, 15, 51, 58, 30,
            45, 23, 52, 59, 38, 31, 60, 53, 46, 39, 61, 54, 47, 62, 55, 63,
        };

        private static readonly short[] ColScan8X8 = new short[]
        {
            0,  8,  16, 1,  24, 9,  32, 17, 2,  40, 25, 10, 33, 18, 48, 3,
            26, 41, 11, 56, 19, 34, 4,  49, 27, 42, 12, 35, 20, 57, 50, 28,
            5,  43, 13, 36, 58, 51, 21, 44, 6,  29, 59, 37, 14, 52, 22, 7,
            45, 60, 30, 15, 38, 53, 23, 46, 31, 61, 39, 54, 47, 62, 55, 63,
        };

        private static readonly short[] RowScan8X8 = new short[]
        {
            0,  1,  2,  8,  9,  3,  16, 10, 4,  17, 11, 24, 5,  18, 25, 12,
            19, 26, 32, 6,  13, 20, 33, 27, 7,  34, 40, 21, 28, 41, 14, 35,
            48, 42, 29, 36, 49, 22, 43, 15, 56, 37, 50, 44, 30, 57, 23, 51,
            58, 45, 38, 52, 31, 59, 53, 46, 60, 39, 61, 47, 54, 55, 62, 63,
        };

        private static readonly short[] DefaultScan16X16 = new short[]
        {
            0,   16,  1,   32,  17,  2,   48,  33,  18,  3,   64,  34,  49,  19,  65,
            80,  50,  4,   35,  66,  20,  81,  96,  51,  5,   36,  82,  97,  67,  112,
            21,  52,  98,  37,  83,  113, 6,   68,  128, 53,  22,  99,  114, 84,  7,
            129, 38,  69,  100, 115, 144, 130, 85,  54,  23,  8,   145, 39,  70,  116,
            101, 131, 160, 146, 55,  86,  24,  71,  132, 117, 161, 40,  9,   102, 147,
            176, 162, 87,  56,  25,  133, 118, 177, 148, 72,  103, 41,  163, 10,  192,
            178, 88,  57,  134, 149, 119, 26,  164, 73,  104, 193, 42,  179, 208, 11,
            135, 89,  165, 120, 150, 58,  194, 180, 27,  74,  209, 105, 151, 136, 43,
            90,  224, 166, 195, 181, 121, 210, 59,  12,  152, 106, 167, 196, 75,  137,
            225, 211, 240, 182, 122, 91,  28,  197, 13,  226, 168, 183, 153, 44,  212,
            138, 107, 241, 60,  29,  123, 198, 184, 227, 169, 242, 76,  213, 154, 45,
            92,  14,  199, 139, 61,  228, 214, 170, 185, 243, 108, 77,  155, 30,  15,
            200, 229, 124, 215, 244, 93,  46,  186, 171, 201, 109, 140, 230, 62,  216,
            245, 31,  125, 78,  156, 231, 47,  187, 202, 217, 94,  246, 141, 63,  232,
            172, 110, 247, 157, 79,  218, 203, 126, 233, 188, 248, 95,  173, 142, 219,
            111, 249, 234, 158, 127, 189, 204, 250, 235, 143, 174, 220, 205, 159, 251,
            190, 221, 175, 236, 237, 191, 206, 252, 222, 253, 207, 238, 223, 254, 239,
            255,
        };

        private static readonly short[] ColScan16X16 = new short[]
        {
            0,   16,  32,  48,  1,   64,  17,  80,  33,  96,  49,  2,   65,  112, 18,
            81,  34,  128, 50,  97,  3,   66,  144, 19,  113, 35,  82,  160, 98,  51,
            129, 4,   67,  176, 20,  114, 145, 83,  36,  99,  130, 52,  192, 5,   161,
            68,  115, 21,  146, 84,  208, 177, 37,  131, 100, 53,  162, 224, 69,  6,
            116, 193, 147, 85,  22,  240, 132, 38,  178, 101, 163, 54,  209, 117, 70,
            7,   148, 194, 86,  179, 225, 23,  133, 39,  164, 8,   102, 210, 241, 55,
            195, 118, 149, 71,  180, 24,  87,  226, 134, 165, 211, 40,  103, 56,  72,
            150, 196, 242, 119, 9,   181, 227, 88,  166, 25,  135, 41,  104, 212, 57,
            151, 197, 120, 73,  243, 182, 136, 167, 213, 89,  10,  228, 105, 152, 198,
            26,  42,  121, 183, 244, 168, 58,  137, 229, 74,  214, 90,  153, 199, 184,
            11,  106, 245, 27,  122, 230, 169, 43,  215, 59,  200, 138, 185, 246, 75,
            12,  91,  154, 216, 231, 107, 28,  44,  201, 123, 170, 60,  247, 232, 76,
            139, 13,  92,  217, 186, 248, 155, 108, 29,  124, 45,  202, 233, 171, 61,
            14,  77,  140, 15,  249, 93,  30,  187, 156, 218, 46,  109, 125, 62,  172,
            78,  203, 31,  141, 234, 94,  47,  188, 63,  157, 110, 250, 219, 79,  126,
            204, 173, 142, 95,  189, 111, 235, 158, 220, 251, 127, 174, 143, 205, 236,
            159, 190, 221, 252, 175, 206, 237, 191, 253, 222, 238, 207, 254, 223, 239,
            255,
        };

        private static readonly short[] RowScan16X16 = new short[]
        {
            0,   1,   2,   16,  3,   17,  4,   18,  32,  5,   33,  19,  6,   34,  48,
            20,  49,  7,   35,  21,  50,  64,  8,   36,  65,  22,  51,  37,  80,  9,
            66,  52,  23,  38,  81,  67,  10,  53,  24,  82,  68,  96,  39,  11,  54,
            83,  97,  69,  25,  98,  84,  40,  112, 55,  12,  70,  99,  113, 85,  26,
            41,  56,  114, 100, 13,  71,  128, 86,  27,  115, 101, 129, 42,  57,  72,
            116, 14,  87,  130, 102, 144, 73,  131, 117, 28,  58,  15,  88,  43,  145,
            103, 132, 146, 118, 74,  160, 89,  133, 104, 29,  59,  147, 119, 44,  161,
            148, 90,  105, 134, 162, 120, 176, 75,  135, 149, 30,  60,  163, 177, 45,
            121, 91,  106, 164, 178, 150, 192, 136, 165, 179, 31,  151, 193, 76,  122,
            61,  137, 194, 107, 152, 180, 208, 46,  166, 167, 195, 92,  181, 138, 209,
            123, 153, 224, 196, 77,  168, 210, 182, 240, 108, 197, 62,  154, 225, 183,
            169, 211, 47,  139, 93,  184, 226, 212, 241, 198, 170, 124, 155, 199, 78,
            213, 185, 109, 227, 200, 63,  228, 242, 140, 214, 171, 186, 156, 229, 243,
            125, 94,  201, 244, 215, 216, 230, 141, 187, 202, 79,  172, 110, 157, 245,
            217, 231, 95,  246, 232, 126, 203, 247, 233, 173, 218, 142, 111, 158, 188,
            248, 127, 234, 219, 249, 189, 204, 143, 174, 159, 250, 235, 205, 220, 175,
            190, 251, 221, 191, 206, 236, 207, 237, 252, 222, 253, 223, 238, 239, 254,
            255,
        };

        private static readonly short[] DefaultScan32X32 = new short[]
        {
            0,    32,   1,    64,  33,   2,    96,   65,   34,   128,  3,    97,   66,
            160,  129,  35,   98,  4,    67,   130,  161,  192,  36,   99,   224,  5,
            162,  193,  68,   131, 37,   100,  225,  194,  256,  163,  69,   132,  6,
            226,  257,  288,  195, 101,  164,  38,   258,  7,    227,  289,  133,  320,
            70,   196,  165,  290, 259,  228,  39,   321,  102,  352,  8,    197,  71,
            134,  322,  291,  260, 353,  384,  229,  166,  103,  40,   354,  323,  292,
            135,  385,  198,  261, 72,   9,    416,  167,  386,  355,  230,  324,  104,
            293,  41,   417,  199, 136,  262,  387,  448,  325,  356,  10,   73,   418,
            231,  168,  449,  294, 388,  105,  419,  263,  42,   200,  357,  450,  137,
            480,  74,   326,  232, 11,   389,  169,  295,  420,  106,  451,  481,  358,
            264,  327,  201,  43,  138,  512,  482,  390,  296,  233,  170,  421,  75,
            452,  359,  12,   513, 265,  483,  328,  107,  202,  514,  544,  422,  391,
            453,  139,  44,   234, 484,  297,  360,  171,  76,   515,  545,  266,  329,
            454,  13,   423,  203, 108,  546,  485,  576,  298,  235,  140,  361,  330,
            172,  547,  45,   455, 267,  577,  486,  77,   204,  362,  608,  14,   299,
            578,  109,  236,  487, 609,  331,  141,  579,  46,   15,   173,  610,  363,
            78,   205,  16,   110, 237,  611,  142,  47,   174,  79,   206,  17,   111,
            238,  48,   143,  80,  175,  112,  207,  49,   18,   239,  81,   113,  19,
            50,   82,   114,  51,  83,   115,  640,  516,  392,  268,  144,  20,   672,
            641,  548,  517,  424, 393,  300,  269,  176,  145,  52,   21,   704,  673,
            642,  580,  549,  518, 456,  425,  394,  332,  301,  270,  208,  177,  146,
            84,   53,   22,   736, 705,  674,  643,  612,  581,  550,  519,  488,  457,
            426,  395,  364,  333, 302,  271,  240,  209,  178,  147,  116,  85,   54,
            23,   737,  706,  675, 613,  582,  551,  489,  458,  427,  365,  334,  303,
            241,  210,  179,  117, 86,   55,   738,  707,  614,  583,  490,  459,  366,
            335,  242,  211,  118, 87,   739,  615,  491,  367,  243,  119,  768,  644,
            520,  396,  272,  148, 24,   800,  769,  676,  645,  552,  521,  428,  397,
            304,  273,  180,  149, 56,   25,   832,  801,  770,  708,  677,  646,  584,
            553,  522,  460,  429, 398,  336,  305,  274,  212,  181,  150,  88,   57,
            26,   864,  833,  802, 771,  740,  709,  678,  647,  616,  585,  554,  523,
            492,  461,  430,  399, 368,  337,  306,  275,  244,  213,  182,  151,  120,
            89,   58,   27,   865, 834,  803,  741,  710,  679,  617,  586,  555,  493,
            462,  431,  369,  338, 307,  245,  214,  183,  121,  90,   59,   866,  835,
            742,  711,  618,  587, 494,  463,  370,  339,  246,  215,  122,  91,   867,
            743,  619,  495,  371, 247,  123,  896,  772,  648,  524,  400,  276,  152,
            28,   928,  897,  804, 773,  680,  649,  556,  525,  432,  401,  308,  277,
            184,  153,  60,   29,  960,  929,  898,  836,  805,  774,  712,  681,  650,
            588,  557,  526,  464, 433,  402,  340,  309,  278,  216,  185,  154,  92,
            61,   30,   992,  961, 930,  899,  868,  837,  806,  775,  744,  713,  682,
            651,  620,  589,  558, 527,  496,  465,  434,  403,  372,  341,  310,  279,
            248,  217,  186,  155, 124,  93,   62,   31,   993,  962,  931,  869,  838,
            807,  745,  714,  683, 621,  590,  559,  497,  466,  435,  373,  342,  311,
            249,  218,  187,  125, 94,   63,   994,  963,  870,  839,  746,  715,  622,
            591,  498,  467,  374, 343,  250,  219,  126,  95,   995,  871,  747,  623,
            499,  375,  251,  127, 900,  776,  652,  528,  404,  280,  156,  932,  901,
            808,  777,  684,  653, 560,  529,  436,  405,  312,  281,  188,  157,  964,
            933,  902,  840,  809, 778,  716,  685,  654,  592,  561,  530,  468,  437,
            406,  344,  313,  282, 220,  189,  158,  996,  965,  934,  903,  872,  841,
            810,  779,  748,  717, 686,  655,  624,  593,  562,  531,  500,  469,  438,
            407,  376,  345,  314, 283,  252,  221,  190,  159,  997,  966,  935,  873,
            842,  811,  749,  718, 687,  625,  594,  563,  501,  470,  439,  377,  346,
            315,  253,  222,  191, 998,  967,  874,  843,  750,  719,  626,  595,  502,
            471,  378,  347,  254, 223,  999,  875,  751,  627,  503,  379,  255,  904,
            780,  656,  532,  408, 284,  936,  905,  812,  781,  688,  657,  564,  533,
            440,  409,  316,  285, 968,  937,  906,  844,  813,  782,  720,  689,  658,
            596,  565,  534,  472, 441,  410,  348,  317,  286,  1000, 969,  938,  907,
            876,  845,  814,  783, 752,  721,  690,  659,  628,  597,  566,  535,  504,
            473,  442,  411,  380, 349,  318,  287,  1001, 970,  939,  877,  846,  815,
            753,  722,  691,  629, 598,  567,  505,  474,  443,  381,  350,  319,  1002,
            971,  878,  847,  754, 723,  630,  599,  506,  475,  382,  351,  1003, 879,
            755,  631,  507,  383, 908,  784,  660,  536,  412,  940,  909,  816,  785,
            692,  661,  568,  537, 444,  413,  972,  941,  910,  848,  817,  786,  724,
            693,  662,  600,  569, 538,  476,  445,  414,  1004, 973,  942,  911,  880,
            849,  818,  787,  756, 725,  694,  663,  632,  601,  570,  539,  508,  477,
            446,  415,  1005, 974, 943,  881,  850,  819,  757,  726,  695,  633,  602,
            571,  509,  478,  447, 1006, 975,  882,  851,  758,  727,  634,  603,  510,
            479,  1007, 883,  759, 635,  511,  912,  788,  664,  540,  944,  913,  820,
            789,  696,  665,  572, 541,  976,  945,  914,  852,  821,  790,  728,  697,
            666,  604,  573,  542, 1008, 977,  946,  915,  884,  853,  822,  791,  760,
            729,  698,  667,  636, 605,  574,  543,  1009, 978,  947,  885,  854,  823,
            761,  730,  699,  637, 606,  575,  1010, 979,  886,  855,  762,  731,  638,
            607,  1011, 887,  763, 639,  916,  792,  668,  948,  917,  824,  793,  700,
            669,  980,  949,  918, 856,  825,  794,  732,  701,  670,  1012, 981,  950,
            919,  888,  857,  826, 795,  764,  733,  702,  671,  1013, 982,  951,  889,
            858,  827,  765,  734, 703,  1014, 983,  890,  859,  766,  735,  1015, 891,
            767,  920,  796,  952, 921,  828,  797,  984,  953,  922,  860,  829,  798,
            1016, 985,  954,  923, 892,  861,  830,  799,  1017, 986,  955,  893,  862,
            831,  1018, 987,  894, 863,  1019, 895,  924,  956,  925,  988,  957,  926,
            1020, 989,  958,  927, 1021, 990,  959,  1022, 991,  1023,
        };

        // Neighborhood 2-tuples for various scans and blocksizes,
        // in {top, left} order for each position in corresponding scan order.
        private static readonly short[] DefaultScan4X4Neighbors = new short[]
        {
            0, 0, 0, 0, 0,  0, 1, 4, 4, 4,  1,  1, 8,  8,  5,  8, 2,
            2, 2, 5, 9, 12, 6, 9, 3, 6, 10, 13, 7, 10, 11, 14, 0, 0,
        };

        private static readonly short[] ColScan4X4Neighbors = new short[]
        {
            0, 0, 0, 0, 4, 4, 0, 0, 8, 8,  1,  1, 5, 5,  1,  1, 9,
            9, 2, 2, 6, 6, 2, 2, 3, 3, 10, 10, 7, 7, 11, 11, 0, 0,
        };

        private static readonly short[] RowScan4X4Neighbors = new short[]
        {
            0, 0, 0, 0, 0, 0, 1, 1,  4,  4,  2,  2,  5,  5,  4,  4, 8,
            8, 6, 6, 8, 8, 9, 9, 12, 12, 10, 10, 13, 13, 14, 14, 0, 0,
        };

        private static readonly short[] ColScan8X8Neighbors = new short[]
        {
            0,  0,  0,  0,  8,  8,  0,  0,  16, 16, 1,  1,  24, 24, 9,  9,  1,  1,  32,
            32, 17, 17, 2,  2,  25, 25, 10, 10, 40, 40, 2,  2,  18, 18, 33, 33, 3,  3,
            48, 48, 11, 11, 26, 26, 3,  3,  41, 41, 19, 19, 34, 34, 4,  4,  27, 27, 12,
            12, 49, 49, 42, 42, 20, 20, 4,  4,  35, 35, 5,  5,  28, 28, 50, 50, 43, 43,
            13, 13, 36, 36, 5,  5,  21, 21, 51, 51, 29, 29, 6,  6,  44, 44, 14, 14, 6,
            6,  37, 37, 52, 52, 22, 22, 7,  7,  30, 30, 45, 45, 15, 15, 38, 38, 23, 23,
            53, 53, 31, 31, 46, 46, 39, 39, 54, 54, 47, 47, 55, 55, 0,  0,
        };

        private static readonly short[] RowScan8X8Neighbors = new short[]
        {
            0,  0,  0,  0,  1,  1,  0,  0,  8,  8,  2,  2,  8,  8,  9,  9,  3,  3,  16,
            16, 10, 10, 16, 16, 4,  4,  17, 17, 24, 24, 11, 11, 18, 18, 25, 25, 24, 24,
            5,  5,  12, 12, 19, 19, 32, 32, 26, 26, 6,  6,  33, 33, 32, 32, 20, 20, 27,
            27, 40, 40, 13, 13, 34, 34, 40, 40, 41, 41, 28, 28, 35, 35, 48, 48, 21, 21,
            42, 42, 14, 14, 48, 48, 36, 36, 49, 49, 43, 43, 29, 29, 56, 56, 22, 22, 50,
            50, 57, 57, 44, 44, 37, 37, 51, 51, 30, 30, 58, 58, 52, 52, 45, 45, 59, 59,
            38, 38, 60, 60, 46, 46, 53, 53, 54, 54, 61, 61, 62, 62, 0,  0,
        };

        private static readonly short[] DefaultScan8X8Neighbors = new short[]
        {
            0,  0,  0,  0,  0,  0,  8,  8,  1,  8,  1,  1,  9,  16, 16, 16, 2,  9,  2,
            2,  10, 17, 17, 24, 24, 24, 3,  10, 3,  3,  18, 25, 25, 32, 11, 18, 32, 32,
            4,  11, 26, 33, 19, 26, 4,  4,  33, 40, 12, 19, 40, 40, 5,  12, 27, 34, 34,
            41, 20, 27, 13, 20, 5,  5,  41, 48, 48, 48, 28, 35, 35, 42, 21, 28, 6,  6,
            6,  13, 42, 49, 49, 56, 36, 43, 14, 21, 29, 36, 7,  14, 43, 50, 50, 57, 22,
            29, 37, 44, 15, 22, 44, 51, 51, 58, 30, 37, 23, 30, 52, 59, 45, 52, 38, 45,
            31, 38, 53, 60, 46, 53, 39, 46, 54, 61, 47, 54, 55, 62, 0,  0,
        };

        private static readonly short[] ColScan16X16Neighbors = new short[]
        {
            0,   0,   0,   0,   16,  16,  32,  32,  0,   0,   48,  48,  1,   1,   64,
            64,  17,  17,  80,  80,  33,  33,  1,   1,   49,  49,  96,  96,  2,   2,
            65,  65,  18,  18,  112, 112, 34,  34,  81,  81,  2,   2,   50,  50,  128,
            128, 3,   3,   97,  97,  19,  19,  66,  66,  144, 144, 82,  82,  35,  35,
            113, 113, 3,   3,   51,  51,  160, 160, 4,   4,   98,  98,  129, 129, 67,
            67,  20,  20,  83,  83,  114, 114, 36,  36,  176, 176, 4,   4,   145, 145,
            52,  52,  99,  99,  5,   5,   130, 130, 68,  68,  192, 192, 161, 161, 21,
            21,  115, 115, 84,  84,  37,  37,  146, 146, 208, 208, 53,  53,  5,   5,
            100, 100, 177, 177, 131, 131, 69,  69,  6,   6,   224, 224, 116, 116, 22,
            22,  162, 162, 85,  85,  147, 147, 38,  38,  193, 193, 101, 101, 54,  54,
            6,   6,   132, 132, 178, 178, 70,  70,  163, 163, 209, 209, 7,   7,   117,
            117, 23,  23,  148, 148, 7,   7,   86,  86,  194, 194, 225, 225, 39,  39,
            179, 179, 102, 102, 133, 133, 55,  55,  164, 164, 8,   8,   71,  71,  210,
            210, 118, 118, 149, 149, 195, 195, 24,  24,  87,  87,  40,  40,  56,  56,
            134, 134, 180, 180, 226, 226, 103, 103, 8,   8,   165, 165, 211, 211, 72,
            72,  150, 150, 9,   9,   119, 119, 25,  25,  88,  88,  196, 196, 41,  41,
            135, 135, 181, 181, 104, 104, 57,  57,  227, 227, 166, 166, 120, 120, 151,
            151, 197, 197, 73,  73,  9,   9,   212, 212, 89,  89,  136, 136, 182, 182,
            10,  10,  26,  26,  105, 105, 167, 167, 228, 228, 152, 152, 42,  42,  121,
            121, 213, 213, 58,  58,  198, 198, 74,  74,  137, 137, 183, 183, 168, 168,
            10,  10,  90,  90,  229, 229, 11,  11,  106, 106, 214, 214, 153, 153, 27,
            27,  199, 199, 43,  43,  184, 184, 122, 122, 169, 169, 230, 230, 59,  59,
            11,  11,  75,  75,  138, 138, 200, 200, 215, 215, 91,  91,  12,  12,  28,
            28,  185, 185, 107, 107, 154, 154, 44,  44,  231, 231, 216, 216, 60,  60,
            123, 123, 12,  12,  76,  76,  201, 201, 170, 170, 232, 232, 139, 139, 92,
            92,  13,  13,  108, 108, 29,  29,  186, 186, 217, 217, 155, 155, 45,  45,
            13,  13,  61,  61,  124, 124, 14,  14,  233, 233, 77,  77,  14,  14,  171,
            171, 140, 140, 202, 202, 30,  30,  93,  93,  109, 109, 46,  46,  156, 156,
            62,  62,  187, 187, 15,  15,  125, 125, 218, 218, 78,  78,  31,  31,  172,
            172, 47,  47,  141, 141, 94,  94,  234, 234, 203, 203, 63,  63,  110, 110,
            188, 188, 157, 157, 126, 126, 79,  79,  173, 173, 95,  95,  219, 219, 142,
            142, 204, 204, 235, 235, 111, 111, 158, 158, 127, 127, 189, 189, 220, 220,
            143, 143, 174, 174, 205, 205, 236, 236, 159, 159, 190, 190, 221, 221, 175,
            175, 237, 237, 206, 206, 222, 222, 191, 191, 238, 238, 207, 207, 223, 223,
            239, 239, 0,   0,
        };

        private static readonly short[] RowScan16X16Neighbors = new short[]
        {
            0,   0,   0,   0,   1,   1,   0,   0,   2,   2,   16,  16,  3,   3,   17,
            17,  16,  16,  4,   4,   32,  32,  18,  18,  5,   5,   33,  33,  32,  32,
            19,  19,  48,  48,  6,   6,   34,  34,  20,  20,  49,  49,  48,  48,  7,
            7,   35,  35,  64,  64,  21,  21,  50,  50,  36,  36,  64,  64,  8,   8,
            65,  65,  51,  51,  22,  22,  37,  37,  80,  80,  66,  66,  9,   9,   52,
            52,  23,  23,  81,  81,  67,  67,  80,  80,  38,  38,  10,  10,  53,  53,
            82,  82,  96,  96,  68,  68,  24,  24,  97,  97,  83,  83,  39,  39,  96,
            96,  54,  54,  11,  11,  69,  69,  98,  98,  112, 112, 84,  84,  25,  25,
            40,  40,  55,  55,  113, 113, 99,  99,  12,  12,  70,  70,  112, 112, 85,
            85,  26,  26,  114, 114, 100, 100, 128, 128, 41,  41,  56,  56,  71,  71,
            115, 115, 13,  13,  86,  86,  129, 129, 101, 101, 128, 128, 72,  72,  130,
            130, 116, 116, 27,  27,  57,  57,  14,  14,  87,  87,  42,  42,  144, 144,
            102, 102, 131, 131, 145, 145, 117, 117, 73,  73,  144, 144, 88,  88,  132,
            132, 103, 103, 28,  28,  58,  58,  146, 146, 118, 118, 43,  43,  160, 160,
            147, 147, 89,  89,  104, 104, 133, 133, 161, 161, 119, 119, 160, 160, 74,
            74,  134, 134, 148, 148, 29,  29,  59,  59,  162, 162, 176, 176, 44,  44,
            120, 120, 90,  90,  105, 105, 163, 163, 177, 177, 149, 149, 176, 176, 135,
            135, 164, 164, 178, 178, 30,  30,  150, 150, 192, 192, 75,  75,  121, 121,
            60,  60,  136, 136, 193, 193, 106, 106, 151, 151, 179, 179, 192, 192, 45,
            45,  165, 165, 166, 166, 194, 194, 91,  91,  180, 180, 137, 137, 208, 208,
            122, 122, 152, 152, 208, 208, 195, 195, 76,  76,  167, 167, 209, 209, 181,
            181, 224, 224, 107, 107, 196, 196, 61,  61,  153, 153, 224, 224, 182, 182,
            168, 168, 210, 210, 46,  46,  138, 138, 92,  92,  183, 183, 225, 225, 211,
            211, 240, 240, 197, 197, 169, 169, 123, 123, 154, 154, 198, 198, 77,  77,
            212, 212, 184, 184, 108, 108, 226, 226, 199, 199, 62,  62,  227, 227, 241,
            241, 139, 139, 213, 213, 170, 170, 185, 185, 155, 155, 228, 228, 242, 242,
            124, 124, 93,  93,  200, 200, 243, 243, 214, 214, 215, 215, 229, 229, 140,
            140, 186, 186, 201, 201, 78,  78,  171, 171, 109, 109, 156, 156, 244, 244,
            216, 216, 230, 230, 94,  94,  245, 245, 231, 231, 125, 125, 202, 202, 246,
            246, 232, 232, 172, 172, 217, 217, 141, 141, 110, 110, 157, 157, 187, 187,
            247, 247, 126, 126, 233, 233, 218, 218, 248, 248, 188, 188, 203, 203, 142,
            142, 173, 173, 158, 158, 249, 249, 234, 234, 204, 204, 219, 219, 174, 174,
            189, 189, 250, 250, 220, 220, 190, 190, 205, 205, 235, 235, 206, 206, 236,
            236, 251, 251, 221, 221, 252, 252, 222, 222, 237, 237, 238, 238, 253, 253,
            254, 254, 0,   0,
        };

        private static readonly short[] DefaultScan16X16Neighbors = new short[]
        {
            0,   0,   0,   0,   0,   0,   16,  16,  1,   16,  1,   1,   32,  32,  17,
            32,  2,   17,  2,   2,   48,  48,  18,  33,  33,  48,  3,   18,  49,  64,
            64,  64,  34,  49,  3,   3,   19,  34,  50,  65,  4,   19,  65,  80,  80,
            80,  35,  50,  4,   4,   20,  35,  66,  81,  81,  96,  51,  66,  96,  96,
            5,   20,  36,  51,  82,  97,  21,  36,  67,  82,  97,  112, 5,   5,   52,
            67,  112, 112, 37,  52,  6,   21,  83,  98,  98,  113, 68,  83,  6,   6,
            113, 128, 22,  37,  53,  68,  84,  99,  99,  114, 128, 128, 114, 129, 69,
            84,  38,  53,  7,   22,  7,   7,   129, 144, 23,  38,  54,  69,  100, 115,
            85,  100, 115, 130, 144, 144, 130, 145, 39,  54,  70,  85,  8,   23,  55,
            70,  116, 131, 101, 116, 145, 160, 24,  39,  8,   8,   86,  101, 131, 146,
            160, 160, 146, 161, 71,  86,  40,  55,  9,   24,  117, 132, 102, 117, 161,
            176, 132, 147, 56,  71,  87,  102, 25,  40,  147, 162, 9,   9,   176, 176,
            162, 177, 72,  87,  41,  56,  118, 133, 133, 148, 103, 118, 10,  25,  148,
            163, 57,  72,  88,  103, 177, 192, 26,  41,  163, 178, 192, 192, 10,  10,
            119, 134, 73,  88,  149, 164, 104, 119, 134, 149, 42,  57,  178, 193, 164,
            179, 11,  26,  58,  73,  193, 208, 89,  104, 135, 150, 120, 135, 27,  42,
            74,  89,  208, 208, 150, 165, 179, 194, 165, 180, 105, 120, 194, 209, 43,
            58,  11,  11,  136, 151, 90,  105, 151, 166, 180, 195, 59,  74,  121, 136,
            209, 224, 195, 210, 224, 224, 166, 181, 106, 121, 75,  90,  12,  27,  181,
            196, 12,  12,  210, 225, 152, 167, 167, 182, 137, 152, 28,  43,  196, 211,
            122, 137, 91,  106, 225, 240, 44,  59,  13,  28,  107, 122, 182, 197, 168,
            183, 211, 226, 153, 168, 226, 241, 60,  75,  197, 212, 138, 153, 29,  44,
            76,  91,  13,  13,  183, 198, 123, 138, 45,  60,  212, 227, 198, 213, 154,
            169, 169, 184, 227, 242, 92,  107, 61,  76,  139, 154, 14,  29,  14,  14,
            184, 199, 213, 228, 108, 123, 199, 214, 228, 243, 77,  92,  30,  45,  170,
            185, 155, 170, 185, 200, 93,  108, 124, 139, 214, 229, 46,  61,  200, 215,
            229, 244, 15,  30,  109, 124, 62,  77,  140, 155, 215, 230, 31,  46,  171,
            186, 186, 201, 201, 216, 78,  93,  230, 245, 125, 140, 47,  62,  216, 231,
            156, 171, 94,  109, 231, 246, 141, 156, 63,  78,  202, 217, 187, 202, 110,
            125, 217, 232, 172, 187, 232, 247, 79,  94,  157, 172, 126, 141, 203, 218,
            95,  110, 233, 248, 218, 233, 142, 157, 111, 126, 173, 188, 188, 203, 234,
            249, 219, 234, 127, 142, 158, 173, 204, 219, 189, 204, 143, 158, 235, 250,
            174, 189, 205, 220, 159, 174, 220, 235, 221, 236, 175, 190, 190, 205, 236,
            251, 206, 221, 237, 252, 191, 206, 222, 237, 207, 222, 238, 253, 223, 238,
            239, 254, 0,   0,
        };

        private static readonly short[] DefaultScan32X32Neighbors = new short[]
        {
            0,   0,    0,   0,    0,   0,    32,  32,   1,   32,  1,   1,    64,  64,
            33,  64,   2,   33,   96,  96,   2,   2,    65,  96,  34,  65,   128, 128,
            97,  128,  3,   34,   66,  97,   3,   3,    35,  66,  98,  129,  129, 160,
            160, 160,  4,   35,   67,  98,   192, 192,  4,   4,   130, 161,  161, 192,
            36,  67,   99,  130,  5,   36,   68,  99,   193, 224, 162, 193,  224, 224,
            131, 162,  37,  68,   100, 131,  5,   5,    194, 225, 225, 256,  256, 256,
            163, 194,  69,  100,  132, 163,  6,   37,   226, 257, 6,   6,    195, 226,
            257, 288,  101, 132,  288, 288,  38,  69,   164, 195, 133, 164,  258, 289,
            227, 258,  196, 227,  7,   38,   289, 320,  70,  101, 320, 320,  7,   7,
            165, 196,  39,  70,   102, 133,  290, 321,  259, 290, 228, 259,  321, 352,
            352, 352,  197, 228,  134, 165,  71,  102,  8,   39,  322, 353,  291, 322,
            260, 291,  103, 134,  353, 384,  166, 197,  229, 260, 40,  71,   8,   8,
            384, 384,  135, 166,  354, 385,  323, 354,  198, 229, 292, 323,  72,  103,
            261, 292,  9,   40,   385, 416,  167, 198,  104, 135, 230, 261,  355, 386,
            416, 416,  293, 324,  324, 355,  9,   9,    41,  72,  386, 417,  199, 230,
            136, 167,  417, 448,  262, 293,  356, 387,  73,  104, 387, 418,  231, 262,
            10,  41,   168, 199,  325, 356,  418, 449,  105, 136, 448, 448,  42,  73,
            294, 325,  200, 231,  10,  10,   357, 388,  137, 168, 263, 294,  388, 419,
            74,  105,  419, 450,  449, 480,  326, 357,  232, 263, 295, 326,  169, 200,
            11,  42,   106, 137,  480, 480,  450, 481,  358, 389, 264, 295,  201, 232,
            138, 169,  389, 420,  43,  74,   420, 451,  327, 358, 11,  11,   481, 512,
            233, 264,  451, 482,  296, 327,  75,  106,  170, 201, 482, 513,  512, 512,
            390, 421,  359, 390,  421, 452,  107, 138,  12,  43,  202, 233,  452, 483,
            265, 296,  328, 359,  139, 170,  44,  75,   483, 514, 513, 544,  234, 265,
            297, 328,  422, 453,  12,  12,   391, 422,  171, 202, 76,  107,  514, 545,
            453, 484,  544, 544,  266, 297,  203, 234,  108, 139, 329, 360,  298, 329,
            140, 171,  515, 546,  13,  44,   423, 454,  235, 266, 545, 576,  454, 485,
            45,  76,   172, 203,  330, 361,  576, 576,  13,  13,  267, 298,  546, 577,
            77,  108,  204, 235,  455, 486,  577, 608,  299, 330, 109, 140,  547, 578,
            14,  45,   14,  14,   141, 172,  578, 609,  331, 362, 46,  77,   173, 204,
            15,  15,   78,  109,  205, 236,  579, 610,  110, 141, 15,  46,   142, 173,
            47,  78,   174, 205,  16,  16,   79,  110,  206, 237, 16,  47,   111, 142,
            48,  79,   143, 174,  80,  111,  175, 206,  17,  48,  17,  17,   207, 238,
            49,  80,   81,  112,  18,  18,   18,  49,   50,  81,  82,  113,  19,  50,
            51,  82,   83,  114,  608, 608,  484, 515,  360, 391, 236, 267,  112, 143,
            19,  19,   640, 640,  609, 640,  516, 547,  485, 516, 392, 423,  361, 392,
            268, 299,  237, 268,  144, 175,  113, 144,  20,  51,  20,  20,   672, 672,
            641, 672,  610, 641,  548, 579,  517, 548,  486, 517, 424, 455,  393, 424,
            362, 393,  300, 331,  269, 300,  238, 269,  176, 207, 145, 176,  114, 145,
            52,  83,   21,  52,   21,  21,   704, 704,  673, 704, 642, 673,  611, 642,
            580, 611,  549, 580,  518, 549,  487, 518,  456, 487, 425, 456,  394, 425,
            363, 394,  332, 363,  301, 332,  270, 301,  239, 270, 208, 239,  177, 208,
            146, 177,  115, 146,  84,  115,  53,  84,   22,  53,  22,  22,   705, 736,
            674, 705,  643, 674,  581, 612,  550, 581,  519, 550, 457, 488,  426, 457,
            395, 426,  333, 364,  302, 333,  271, 302,  209, 240, 178, 209,  147, 178,
            85,  116,  54,  85,   23,  54,   706, 737,  675, 706, 582, 613,  551, 582,
            458, 489,  427, 458,  334, 365,  303, 334,  210, 241, 179, 210,  86,  117,
            55,  86,   707, 738,  583, 614,  459, 490,  335, 366, 211, 242,  87,  118,
            736, 736,  612, 643,  488, 519,  364, 395,  240, 271, 116, 147,  23,  23,
            768, 768,  737, 768,  644, 675,  613, 644,  520, 551, 489, 520,  396, 427,
            365, 396,  272, 303,  241, 272,  148, 179,  117, 148, 24,  55,   24,  24,
            800, 800,  769, 800,  738, 769,  676, 707,  645, 676, 614, 645,  552, 583,
            521, 552,  490, 521,  428, 459,  397, 428,  366, 397, 304, 335,  273, 304,
            242, 273,  180, 211,  149, 180,  118, 149,  56,  87,  25,  56,   25,  25,
            832, 832,  801, 832,  770, 801,  739, 770,  708, 739, 677, 708,  646, 677,
            615, 646,  584, 615,  553, 584,  522, 553,  491, 522, 460, 491,  429, 460,
            398, 429,  367, 398,  336, 367,  305, 336,  274, 305, 243, 274,  212, 243,
            181, 212,  150, 181,  119, 150,  88,  119,  57,  88,  26,  57,   26,  26,
            833, 864,  802, 833,  771, 802,  709, 740,  678, 709, 647, 678,  585, 616,
            554, 585,  523, 554,  461, 492,  430, 461,  399, 430, 337, 368,  306, 337,
            275, 306,  213, 244,  182, 213,  151, 182,  89,  120, 58,  89,   27,  58,
            834, 865,  803, 834,  710, 741,  679, 710,  586, 617, 555, 586,  462, 493,
            431, 462,  338, 369,  307, 338,  214, 245,  183, 214, 90,  121,  59,  90,
            835, 866,  711, 742,  587, 618,  463, 494,  339, 370, 215, 246,  91,  122,
            864, 864,  740, 771,  616, 647,  492, 523,  368, 399, 244, 275,  120, 151,
            27,  27,   896, 896,  865, 896,  772, 803,  741, 772, 648, 679,  617, 648,
            524, 555,  493, 524,  400, 431,  369, 400,  276, 307, 245, 276,  152, 183,
            121, 152,  28,  59,   28,  28,   928, 928,  897, 928, 866, 897,  804, 835,
            773, 804,  742, 773,  680, 711,  649, 680,  618, 649, 556, 587,  525, 556,
            494, 525,  432, 463,  401, 432,  370, 401,  308, 339, 277, 308,  246, 277,
            184, 215,  153, 184,  122, 153,  60,  91,   29,  60,  29,  29,   960, 960,
            929, 960,  898, 929,  867, 898,  836, 867,  805, 836, 774, 805,  743, 774,
            712, 743,  681, 712,  650, 681,  619, 650,  588, 619, 557, 588,  526, 557,
            495, 526,  464, 495,  433, 464,  402, 433,  371, 402, 340, 371,  309, 340,
            278, 309,  247, 278,  216, 247,  185, 216,  154, 185, 123, 154,  92,  123,
            61,  92,   30,  61,   30,  30,   961, 992,  930, 961, 899, 930,  837, 868,
            806, 837,  775, 806,  713, 744,  682, 713,  651, 682, 589, 620,  558, 589,
            527, 558,  465, 496,  434, 465,  403, 434,  341, 372, 310, 341,  279, 310,
            217, 248,  186, 217,  155, 186,  93,  124,  62,  93,  31,  62,   962, 993,
            931, 962,  838, 869,  807, 838,  714, 745,  683, 714, 590, 621,  559, 590,
            466, 497,  435, 466,  342, 373,  311, 342,  218, 249, 187, 218,  94,  125,
            63,  94,   963, 994,  839, 870,  715, 746,  591, 622, 467, 498,  343, 374,
            219, 250,  95,  126,  868, 899,  744, 775,  620, 651, 496, 527,  372, 403,
            248, 279,  124, 155,  900, 931,  869, 900,  776, 807, 745, 776,  652, 683,
            621, 652,  528, 559,  497, 528,  404, 435,  373, 404, 280, 311,  249, 280,
            156, 187,  125, 156,  932, 963,  901, 932,  870, 901, 808, 839,  777, 808,
            746, 777,  684, 715,  653, 684,  622, 653,  560, 591, 529, 560,  498, 529,
            436, 467,  405, 436,  374, 405,  312, 343,  281, 312, 250, 281,  188, 219,
            157, 188,  126, 157,  964, 995,  933, 964,  902, 933, 871, 902,  840, 871,
            809, 840,  778, 809,  747, 778,  716, 747,  685, 716, 654, 685,  623, 654,
            592, 623,  561, 592,  530, 561,  499, 530,  468, 499, 437, 468,  406, 437,
            375, 406,  344, 375,  313, 344,  282, 313,  251, 282, 220, 251,  189, 220,
            158, 189,  127, 158,  965, 996,  934, 965,  903, 934, 841, 872,  810, 841,
            779, 810,  717, 748,  686, 717,  655, 686,  593, 624, 562, 593,  531, 562,
            469, 500,  438, 469,  407, 438,  345, 376,  314, 345, 283, 314,  221, 252,
            190, 221,  159, 190,  966, 997,  935, 966,  842, 873, 811, 842,  718, 749,
            687, 718,  594, 625,  563, 594,  470, 501,  439, 470, 346, 377,  315, 346,
            222, 253,  191, 222,  967, 998,  843, 874,  719, 750, 595, 626,  471, 502,
            347, 378,  223, 254,  872, 903,  748, 779,  624, 655, 500, 531,  376, 407,
            252, 283,  904, 935,  873, 904,  780, 811,  749, 780, 656, 687,  625, 656,
            532, 563,  501, 532,  408, 439,  377, 408,  284, 315, 253, 284,  936, 967,
            905, 936,  874, 905,  812, 843,  781, 812,  750, 781, 688, 719,  657, 688,
            626, 657,  564, 595,  533, 564,  502, 533,  440, 471, 409, 440,  378, 409,
            316, 347,  285, 316,  254, 285,  968, 999,  937, 968, 906, 937,  875, 906,
            844, 875,  813, 844,  782, 813,  751, 782,  720, 751, 689, 720,  658, 689,
            627, 658,  596, 627,  565, 596,  534, 565,  503, 534, 472, 503,  441, 472,
            410, 441,  379, 410,  348, 379,  317, 348,  286, 317, 255, 286,  969, 1000,
            938, 969,  907, 938,  845, 876,  814, 845,  783, 814, 721, 752,  690, 721,
            659, 690,  597, 628,  566, 597,  535, 566,  473, 504, 442, 473,  411, 442,
            349, 380,  318, 349,  287, 318,  970, 1001, 939, 970, 846, 877,  815, 846,
            722, 753,  691, 722,  598, 629,  567, 598,  474, 505, 443, 474,  350, 381,
            319, 350,  971, 1002, 847, 878,  723, 754,  599, 630, 475, 506,  351, 382,
            876, 907,  752, 783,  628, 659,  504, 535,  380, 411, 908, 939,  877, 908,
            784, 815,  753, 784,  660, 691,  629, 660,  536, 567, 505, 536,  412, 443,
            381, 412,  940, 971,  909, 940,  878, 909,  816, 847, 785, 816,  754, 785,
            692, 723,  661, 692,  630, 661,  568, 599,  537, 568, 506, 537,  444, 475,
            413, 444,  382, 413,  972, 1003, 941, 972,  910, 941, 879, 910,  848, 879,
            817, 848,  786, 817,  755, 786,  724, 755,  693, 724, 662, 693,  631, 662,
            600, 631,  569, 600,  538, 569,  507, 538,  476, 507, 445, 476,  414, 445,
            383, 414,  973, 1004, 942, 973,  911, 942,  849, 880, 818, 849,  787, 818,
            725, 756,  694, 725,  663, 694,  601, 632,  570, 601, 539, 570,  477, 508,
            446, 477,  415, 446,  974, 1005, 943, 974,  850, 881, 819, 850,  726, 757,
            695, 726,  602, 633,  571, 602,  478, 509,  447, 478, 975, 1006, 851, 882,
            727, 758,  603, 634,  479, 510,  880, 911,  756, 787, 632, 663,  508, 539,
            912, 943,  881, 912,  788, 819,  757, 788,  664, 695, 633, 664,  540, 571,
            509, 540,  944, 975,  913, 944,  882, 913,  820, 851, 789, 820,  758, 789,
            696, 727,  665, 696,  634, 665,  572, 603,  541, 572, 510, 541,  976, 1007,
            945, 976,  914, 945,  883, 914,  852, 883,  821, 852, 790, 821,  759, 790,
            728, 759,  697, 728,  666, 697,  635, 666,  604, 635, 573, 604,  542, 573,
            511, 542,  977, 1008, 946, 977,  915, 946,  853, 884, 822, 853,  791, 822,
            729, 760,  698, 729,  667, 698,  605, 636,  574, 605, 543, 574,  978, 1009,
            947, 978,  854, 885,  823, 854,  730, 761,  699, 730, 606, 637,  575, 606,
            979, 1010, 855, 886,  731, 762,  607, 638,  884, 915, 760, 791,  636, 667,
            916, 947,  885, 916,  792, 823,  761, 792,  668, 699, 637, 668,  948, 979,
            917, 948,  886, 917,  824, 855,  793, 824,  762, 793, 700, 731,  669, 700,
            638, 669,  980, 1011, 949, 980,  918, 949,  887, 918, 856, 887,  825, 856,
            794, 825,  763, 794,  732, 763,  701, 732,  670, 701, 639, 670,  981, 1012,
            950, 981,  919, 950,  857, 888,  826, 857,  795, 826, 733, 764,  702, 733,
            671, 702,  982, 1013, 951, 982,  858, 889,  827, 858, 734, 765,  703, 734,
            983, 1014, 859, 890,  735, 766,  888, 919,  764, 795, 920, 951,  889, 920,
            796, 827,  765, 796,  952, 983,  921, 952,  890, 921, 828, 859,  797, 828,
            766, 797,  984, 1015, 953, 984,  922, 953,  891, 922, 860, 891,  829, 860,
            798, 829,  767, 798,  985, 1016, 954, 985,  923, 954, 861, 892,  830, 861,
            799, 830,  986, 1017, 955, 986,  862, 893,  831, 862, 987, 1018, 863, 894,
            892, 923,  924, 955,  893, 924,  956, 987,  925, 956, 894, 925,  988, 1019,
            957, 988,  926, 957,  895, 926,  989, 1020, 958, 989, 927, 958,  990, 1021,
            959, 990,  991, 1022, 0,   0,
        };

        private static readonly short[] Vp9DefaultIscan4X4 = new short[]
        {
            0, 2, 5, 8, 1, 3, 9, 12, 4, 7, 11, 14, 6, 10, 13, 15,
        };

        private static readonly short[] Vp9ColIscan4X4 = new short[]
        {
            0, 3, 7, 11, 1, 5, 9, 12, 2, 6, 10, 14, 4, 8, 13, 15,
        };

        private static readonly short[] Vp9RowIscan4X4 = new short[]
        {
            0, 1, 3, 5, 2, 4, 6, 9, 7, 8, 11, 13, 10, 12, 14, 15,
        };

        private static readonly short[] Vp9ColIscan8X8 = new short[]
        {
            0,  3,  8,  15, 22, 32, 40, 47, 1,  5,  11, 18, 26, 34, 44, 51,
            2,  7,  13, 20, 28, 38, 46, 54, 4,  10, 16, 24, 31, 41, 50, 56,
            6,  12, 21, 27, 35, 43, 52, 58, 9,  17, 25, 33, 39, 48, 55, 60,
            14, 23, 30, 37, 45, 53, 59, 62, 19, 29, 36, 42, 49, 57, 61, 63,
        };

        private static readonly short[] Vp9RowIscan8X8 = new short[]
        {
            0,  1,  2,  5,  8,  12, 19, 24, 3,  4,  7,  10, 15, 20, 30, 39,
            6,  9,  13, 16, 21, 27, 37, 46, 11, 14, 17, 23, 28, 34, 44, 52,
            18, 22, 25, 31, 35, 41, 50, 57, 26, 29, 33, 38, 43, 49, 55, 59,
            32, 36, 42, 47, 51, 54, 60, 61, 40, 45, 48, 53, 56, 58, 62, 63,
        };

        private static readonly short[] Vp9DefaultIscan8X8 = new short[]
        {
            0,  2,  5,  9,  14, 22, 31, 37, 1,  4,  8,  13, 19, 26, 38, 44,
            3,  6,  10, 17, 24, 30, 42, 49, 7,  11, 15, 21, 29, 36, 47, 53,
            12, 16, 20, 27, 34, 43, 52, 57, 18, 23, 28, 35, 41, 48, 56, 60,
            25, 32, 39, 45, 50, 55, 59, 62, 33, 40, 46, 51, 54, 58, 61, 63,
        };

        private static readonly short[] Vp9ColIscan16X16 = new short[]
        {
            0,  4,  11,  20,  31,  43,  59,  75,  85,  109, 130, 150, 165, 181, 195, 198,
            1,  6,  14,  23,  34,  47,  64,  81,  95,  114, 135, 153, 171, 188, 201, 212,
            2,  8,  16,  25,  38,  52,  67,  83,  101, 116, 136, 157, 172, 190, 205, 216,
            3,  10, 18,  29,  41,  55,  71,  89,  103, 119, 141, 159, 176, 194, 208, 218,
            5,  12, 21,  32,  45,  58,  74,  93,  104, 123, 144, 164, 179, 196, 210, 223,
            7,  15, 26,  37,  49,  63,  78,  96,  112, 129, 146, 166, 182, 200, 215, 228,
            9,  19, 28,  39,  54,  69,  86,  102, 117, 132, 151, 170, 187, 206, 220, 230,
            13, 24, 35,  46,  60,  73,  91,  108, 122, 137, 154, 174, 189, 207, 224, 235,
            17, 30, 40,  53,  66,  82,  98,  115, 126, 142, 161, 180, 197, 213, 227, 237,
            22, 36, 48,  62,  76,  92,  105, 120, 133, 147, 167, 186, 203, 219, 232, 240,
            27, 44, 56,  70,  84,  99,  113, 127, 140, 156, 175, 193, 209, 226, 236, 244,
            33, 51, 68,  79,  94,  110, 125, 138, 149, 162, 184, 202, 217, 229, 241, 247,
            42, 61, 77,  90,  106, 121, 134, 148, 160, 173, 191, 211, 225, 238, 245, 251,
            50, 72, 87,  100, 118, 128, 145, 158, 168, 183, 204, 222, 233, 242, 249, 253,
            57, 80, 97,  111, 131, 143, 155, 169, 178, 192, 214, 231, 239, 246, 250, 254,
            65, 88, 107, 124, 139, 152, 163, 177, 185, 199, 221, 234, 243, 248, 252, 255,
        };

        private static readonly short[] Vp9RowIscan16X16 = new short[]
        {
            0,   1,   2,   4,   6,   9,   12,  17,  22,  29,  36,  43,  54,  64,  76,
            86,  3,   5,   7,   11,  15,  19,  25,  32,  38,  48,  59,  68,  84,  99,
            115, 130, 8,   10,  13,  18,  23,  27,  33,  42,  51,  60,  72,  88,  103,
            119, 142, 167, 14,  16,  20,  26,  31,  37,  44,  53,  61,  73,  85,  100,
            116, 135, 161, 185, 21,  24,  30,  35,  40,  47,  55,  65,  74,  81,  94,
            112, 133, 154, 179, 205, 28,  34,  39,  45,  50,  58,  67,  77,  87,  96,
            106, 121, 146, 169, 196, 212, 41,  46,  49,  56,  63,  70,  79,  90,  98,
            107, 122, 138, 159, 182, 207, 222, 52,  57,  62,  69,  75,  83,  93,  102,
            110, 120, 134, 150, 176, 195, 215, 226, 66,  71,  78,  82,  91,  97,  108,
            113, 127, 136, 148, 168, 188, 202, 221, 232, 80,  89,  92,  101, 105, 114,
            125, 131, 139, 151, 162, 177, 192, 208, 223, 234, 95,  104, 109, 117, 123,
            128, 143, 144, 155, 165, 175, 190, 206, 219, 233, 239, 111, 118, 124, 129,
            140, 147, 157, 164, 170, 181, 191, 203, 224, 230, 240, 243, 126, 132, 137,
            145, 153, 160, 174, 178, 184, 197, 204, 216, 231, 237, 244, 246, 141, 149,
            156, 166, 172, 180, 189, 199, 200, 210, 220, 228, 238, 242, 249, 251, 152,
            163, 171, 183, 186, 193, 201, 211, 214, 218, 227, 236, 245, 247, 252, 253,
            158, 173, 187, 194, 198, 209, 213, 217, 225, 229, 235, 241, 248, 250, 254,
            255,
        };

        private static readonly short[] Vp9DefaultIscan16X16 = new short[]
        {
            0,   2,   5,   9,   17,  24,  36,  44,  55,  72,  88,  104, 128, 143, 166,
            179, 1,   4,   8,   13,  20,  30,  40,  54,  66,  79,  96,  113, 141, 154,
            178, 196, 3,   7,   11,  18,  25,  33,  46,  57,  71,  86,  101, 119, 148,
            164, 186, 201, 6,   12,  16,  23,  31,  39,  53,  64,  78,  92,  110, 127,
            153, 169, 193, 208, 10,  14,  19,  28,  37,  47,  58,  67,  84,  98,  114,
            133, 161, 176, 198, 214, 15,  21,  26,  34,  43,  52,  65,  77,  91,  106,
            120, 140, 165, 185, 205, 221, 22,  27,  32,  41,  48,  60,  73,  85,  99,
            116, 130, 151, 175, 190, 211, 225, 29,  35,  42,  49,  59,  69,  81,  95,
            108, 125, 139, 155, 182, 197, 217, 229, 38,  45,  51,  61,  68,  80,  93,
            105, 118, 134, 150, 168, 191, 207, 223, 234, 50,  56,  63,  74,  83,  94,
            109, 117, 129, 147, 163, 177, 199, 213, 228, 238, 62,  70,  76,  87,  97,
            107, 122, 131, 145, 159, 172, 188, 210, 222, 235, 242, 75,  82,  90,  102,
            112, 124, 138, 146, 157, 173, 187, 202, 219, 230, 240, 245, 89,  100, 111,
            123, 132, 142, 156, 167, 180, 189, 203, 216, 231, 237, 246, 250, 103, 115,
            126, 136, 149, 162, 171, 183, 194, 204, 215, 224, 236, 241, 248, 252, 121,
            135, 144, 158, 170, 181, 192, 200, 209, 218, 227, 233, 243, 244, 251, 254,
            137, 152, 160, 174, 184, 195, 206, 212, 220, 226, 232, 239, 247, 249, 253,
            255,
        };

        private static readonly short[] Vp9DefaultIscan32X32 = new short[]
        {
            0,    2,    5,    10,   17,   25,   38,   47,   62,   83,   101,  121,  145,
            170,  193,  204,  210,  219,  229,  233,  245,  257,  275,  299,  342,  356,
            377,  405,  455,  471,  495,  527,  1,    4,    8,    15,   22,   30,   45,
            58,   74,   92,   112,  133,  158,  184,  203,  215,  222,  228,  234,  237,
            256,  274,  298,  317,  355,  376,  404,  426,  470,  494,  526,  551,  3,
            7,    12,   18,   28,   36,   52,   64,   82,   102,  118,  142,  164,  189,
            208,  217,  224,  231,  235,  238,  273,  297,  316,  329,  375,  403,  425,
            440,  493,  525,  550,  567,  6,    11,   16,   23,   31,   43,   60,   73,
            90,   109,  126,  150,  173,  196,  211,  220,  226,  232,  236,  239,  296,
            315,  328,  335,  402,  424,  439,  447,  524,  549,  566,  575,  9,    14,
            19,   29,   37,   50,   65,   78,   95,   116,  134,  157,  179,  201,  214,
            223,  244,  255,  272,  295,  341,  354,  374,  401,  454,  469,  492,  523,
            582,  596,  617,  645,  13,   20,   26,   35,   44,   54,   72,   85,   105,
            123,  140,  163,  182,  205,  216,  225,  254,  271,  294,  314,  353,  373,
            400,  423,  468,  491,  522,  548,  595,  616,  644,  666,  21,   27,   33,
            42,   53,   63,   80,   94,   113,  132,  151,  172,  190,  209,  218,  227,
            270,  293,  313,  327,  372,  399,  422,  438,  490,  521,  547,  565,  615,
            643,  665,  680,  24,   32,   39,   48,   57,   71,   88,   104,  120,  139,
            159,  178,  197,  212,  221,  230,  292,  312,  326,  334,  398,  421,  437,
            446,  520,  546,  564,  574,  642,  664,  679,  687,  34,   40,   46,   56,
            68,   81,   96,   111,  130,  147,  167,  186,  243,  253,  269,  291,  340,
            352,  371,  397,  453,  467,  489,  519,  581,  594,  614,  641,  693,  705,
            723,  747,  41,   49,   55,   67,   77,   91,   107,  124,  138,  161,  177,
            194,  252,  268,  290,  311,  351,  370,  396,  420,  466,  488,  518,  545,
            593,  613,  640,  663,  704,  722,  746,  765,  51,   59,   66,   76,   89,
            99,   119,  131,  149,  168,  181,  200,  267,  289,  310,  325,  369,  395,
            419,  436,  487,  517,  544,  563,  612,  639,  662,  678,  721,  745,  764,
            777,  61,   69,   75,   87,   100,  114,  129,  144,  162,  180,  191,  207,
            288,  309,  324,  333,  394,  418,  435,  445,  516,  543,  562,  573,  638,
            661,  677,  686,  744,  763,  776,  783,  70,   79,   86,   97,   108,  122,
            137,  155,  242,  251,  266,  287,  339,  350,  368,  393,  452,  465,  486,
            515,  580,  592,  611,  637,  692,  703,  720,  743,  788,  798,  813,  833,
            84,   93,   103,  110,  125,  141,  154,  171,  250,  265,  286,  308,  349,
            367,  392,  417,  464,  485,  514,  542,  591,  610,  636,  660,  702,  719,
            742,  762,  797,  812,  832,  848,  98,   106,  115,  127,  143,  156,  169,
            185,  264,  285,  307,  323,  366,  391,  416,  434,  484,  513,  541,  561,
            609,  635,  659,  676,  718,  741,  761,  775,  811,  831,  847,  858,  117,
            128,  136,  148,  160,  175,  188,  198,  284,  306,  322,  332,  390,  415,
            433,  444,  512,  540,  560,  572,  634,  658,  675,  685,  740,  760,  774,
            782,  830,  846,  857,  863,  135,  146,  152,  165,  241,  249,  263,  283,
            338,  348,  365,  389,  451,  463,  483,  511,  579,  590,  608,  633,  691,
            701,  717,  739,  787,  796,  810,  829,  867,  875,  887,  903,  153,  166,
            174,  183,  248,  262,  282,  305,  347,  364,  388,  414,  462,  482,  510,
            539,  589,  607,  632,  657,  700,  716,  738,  759,  795,  809,  828,  845,
            874,  886,  902,  915,  176,  187,  195,  202,  261,  281,  304,  321,  363,
            387,  413,  432,  481,  509,  538,  559,  606,  631,  656,  674,  715,  737,
            758,  773,  808,  827,  844,  856,  885,  901,  914,  923,  192,  199,  206,
            213,  280,  303,  320,  331,  386,  412,  431,  443,  508,  537,  558,  571,
            630,  655,  673,  684,  736,  757,  772,  781,  826,  843,  855,  862,  900,
            913,  922,  927,  240,  247,  260,  279,  337,  346,  362,  385,  450,  461,
            480,  507,  578,  588,  605,  629,  690,  699,  714,  735,  786,  794,  807,
            825,  866,  873,  884,  899,  930,  936,  945,  957,  246,  259,  278,  302,
            345,  361,  384,  411,  460,  479,  506,  536,  587,  604,  628,  654,  698,
            713,  734,  756,  793,  806,  824,  842,  872,  883,  898,  912,  935,  944,
            956,  966,  258,  277,  301,  319,  360,  383,  410,  430,  478,  505,  535,
            557,  603,  627,  653,  672,  712,  733,  755,  771,  805,  823,  841,  854,
            882,  897,  911,  921,  943,  955,  965,  972,  276,  300,  318,  330,  382,
            409,  429,  442,  504,  534,  556,  570,  626,  652,  671,  683,  732,  754,
            770,  780,  822,  840,  853,  861,  896,  910,  920,  926,  954,  964,  971,
            975,  336,  344,  359,  381,  449,  459,  477,  503,  577,  586,  602,  625,
            689,  697,  711,  731,  785,  792,  804,  821,  865,  871,  881,  895,  929,
            934,  942,  953,  977,  981,  987,  995,  343,  358,  380,  408,  458,  476,
            502,  533,  585,  601,  624,  651,  696,  710,  730,  753,  791,  803,  820,
            839,  870,  880,  894,  909,  933,  941,  952,  963,  980,  986,  994,  1001,
            357,  379,  407,  428,  475,  501,  532,  555,  600,  623,  650,  670,  709,
            729,  752,  769,  802,  819,  838,  852,  879,  893,  908,  919,  940,  951,
            962,  970,  985,  993,  1000, 1005, 378,  406,  427,  441,  500,  531,  554,
            569,  622,  649,  669,  682,  728,  751,  768,  779,  818,  837,  851,  860,
            892,  907,  918,  925,  950,  961,  969,  974,  992,  999,  1004, 1007, 448,
            457,  474,  499,  576,  584,  599,  621,  688,  695,  708,  727,  784,  790,
            801,  817,  864,  869,  878,  891,  928,  932,  939,  949,  976,  979,  984,
            991,  1008, 1010, 1013, 1017, 456,  473,  498,  530,  583,  598,  620,  648,
            694,  707,  726,  750,  789,  800,  816,  836,  868,  877,  890,  906,  931,
            938,  948,  960,  978,  983,  990,  998,  1009, 1012, 1016, 1020, 472,  497,
            529,  553,  597,  619,  647,  668,  706,  725,  749,  767,  799,  815,  835,
            850,  876,  889,  905,  917,  937,  947,  959,  968,  982,  989,  997,  1003,
            1011, 1015, 1019, 1022, 496,  528,  552,  568,  618,  646,  667,  681,  724,
            748,  766,  778,  814,  834,  849,  859,  888,  904,  916,  924,  946,  958,
            967,  973,  988,  996,  1002, 1006, 1014, 1018, 1021, 1023,
        };

        public class ScanOrder
        {
            public short[] Scan { get; }
            public short[] IScan { get; }
            public short[] Neighbors { get; }

            public ScanOrder(short[] scan, short[] iScan, short[] neighbors)
            {
                Scan = scan;
                IScan = iScan;
                Neighbors = neighbors;
            }
        }

        public static readonly ScanOrder[] Vp9DefaultScanOrders = new ScanOrder[]
        {
            new ScanOrder(DefaultScan4X4, Vp9DefaultIscan4X4, DefaultScan4X4Neighbors),
            new ScanOrder(DefaultScan8X8, Vp9DefaultIscan8X8, DefaultScan8X8Neighbors),
            new ScanOrder(DefaultScan16X16, Vp9DefaultIscan16X16, DefaultScan16X16Neighbors),
            new ScanOrder(DefaultScan32X32, Vp9DefaultIscan32X32, DefaultScan32X32Neighbors)
        };

        public static readonly ScanOrder[][] Vp9ScanOrders = new ScanOrder[][]
        {
            new ScanOrder[]
            { // TX_4X4
                new ScanOrder(DefaultScan4X4, Vp9DefaultIscan4X4, DefaultScan4X4Neighbors),
                new ScanOrder(RowScan4X4, Vp9RowIscan4X4, RowScan4X4Neighbors),
                new ScanOrder(ColScan4X4, Vp9ColIscan4X4, ColScan4X4Neighbors),
                new ScanOrder(DefaultScan4X4, Vp9DefaultIscan4X4, DefaultScan4X4Neighbors)
            },
            new ScanOrder[]
            { // TX_8X8
                new ScanOrder(DefaultScan8X8, Vp9DefaultIscan8X8, DefaultScan8X8Neighbors),
                new ScanOrder(RowScan8X8, Vp9RowIscan8X8, RowScan8X8Neighbors),
                new ScanOrder(ColScan8X8, Vp9ColIscan8X8, ColScan8X8Neighbors),
                new ScanOrder(DefaultScan8X8, Vp9DefaultIscan8X8, DefaultScan8X8Neighbors)
            },
            new ScanOrder[]
            { // TX_16X16
                new ScanOrder(DefaultScan16X16, Vp9DefaultIscan16X16, DefaultScan16X16Neighbors),
                new ScanOrder(RowScan16X16, Vp9RowIscan16X16, RowScan16X16Neighbors),
                new ScanOrder(ColScan16X16, Vp9ColIscan16X16, ColScan16X16Neighbors),
                new ScanOrder(DefaultScan16X16, Vp9DefaultIscan16X16, DefaultScan16X16Neighbors)
            },
            new ScanOrder[]
            { // TX_32X32
                new ScanOrder(DefaultScan32X32, Vp9DefaultIscan32X32, DefaultScan32X32Neighbors),
                new ScanOrder(DefaultScan32X32, Vp9DefaultIscan32X32, DefaultScan32X32Neighbors),
                new ScanOrder(DefaultScan32X32, Vp9DefaultIscan32X32, DefaultScan32X32Neighbors),
                new ScanOrder(DefaultScan32X32, Vp9DefaultIscan32X32, DefaultScan32X32Neighbors)
            }
        };

        // Entropy MV

        public static readonly sbyte[] Vp9MvJointTree = new sbyte[]
        {
            -(sbyte)MvJointType.MvJointZero, 2, -(sbyte)MvJointType.MvJointHnzvz, 4, -(sbyte)MvJointType.MvJointHzvnz, -(sbyte)MvJointType.MvJointHnzvnz
        };

        public static readonly sbyte[] Vp9MvClassTree = new sbyte[]
        {
            -(sbyte)MvClassType.MvClass0,
            2,
            -(sbyte)MvClassType.MvClass1,
            4,
            6,
            8,
            -(sbyte)MvClassType.MvClass2,
            -(sbyte)MvClassType.MvClass3,
            10,
            12,
            -(sbyte)MvClassType.MvClass4,
            -(sbyte)MvClassType.MvClass5,
            -(sbyte)MvClassType.MvClass6,
            14,
            16,
            18,
            -(sbyte)MvClassType.MvClass7,
            -(sbyte)MvClassType.MvClass8,
            -(sbyte)MvClassType.MvClass9,
            -(sbyte)MvClassType.MvClass10,
        };

        public static readonly sbyte[] Vp9MvFPTree = new sbyte[] { -0, 2, -1, 4, -2, -3 };

        // Entropy

        public static readonly byte[] Vp9Cat1Prob = new byte[] { 159 };
        public static readonly byte[] Vp9Cat2Prob = new byte[] { 165, 145 };
        public static readonly byte[] Vp9Cat3Prob = new byte[] { 173, 148, 140 };
        public static readonly byte[] Vp9Cat4Prob = new byte[] { 176, 155, 140, 135 };
        public static readonly byte[] Vp9Cat5Prob = new byte[] { 180, 157, 141, 134, 130 };
        public static readonly byte[] Vp9Cat6Prob = new byte[] { 254, 254, 254, 252, 249, 243, 230, 196, 177, 153, 140, 133, 130, 129 };

        public static readonly byte[] Vp9Cat6ProbHigh12 = new byte[]
        {
            255, 255, 255, 255, 254, 254, 54, 252, 249, 243, 230, 196, 177, 153, 140, 133, 130, 129
        };

        private static readonly byte[] Vp9CoefbandTrans8X8Plus = new byte[]
        {
            0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5,
            // Beyond MAXBAND_INDEX+1 all values are filled as 5
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
        };

        private static readonly byte[] Vp9CoefbandTrans4X4 = new byte[]
        {
            0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5,
        };

        public static byte[] get_band_translate(TxSize txSize)
        {
            return txSize == TxSize.Tx4x4 ? Vp9CoefbandTrans4X4 : Vp9CoefbandTrans8X8Plus;
        }

        public static readonly byte[][] Vp9Pareto8Full = new byte[][]
        {
            new byte[] { 3, 86, 128, 6, 86, 23, 88, 29 },
            new byte[] { 6, 86, 128, 11, 87, 42, 91, 52 },
            new byte[] { 9, 86, 129, 17, 88, 61, 94, 76 },
            new byte[] { 12, 86, 129, 22, 88, 77, 97, 93 },
            new byte[] { 15, 87, 129, 28, 89, 93, 100, 110 },
            new byte[] { 17, 87, 129, 33, 90, 105, 103, 123 },
            new byte[] { 20, 88, 130, 38, 91, 118, 106, 136 },
            new byte[] { 23, 88, 130, 43, 91, 128, 108, 146 },
            new byte[] { 26, 89, 131, 48, 92, 139, 111, 156 },
            new byte[] { 28, 89, 131, 53, 93, 147, 114, 163 },
            new byte[] { 31, 90, 131, 58, 94, 156, 117, 171 },
            new byte[] { 34, 90, 131, 62, 94, 163, 119, 177 },
            new byte[] { 37, 90, 132, 66, 95, 171, 122, 184 },
            new byte[] { 39, 90, 132, 70, 96, 177, 124, 189 },
            new byte[] { 42, 91, 132, 75, 97, 183, 127, 194 },
            new byte[] { 44, 91, 132, 79, 97, 188, 129, 198 },
            new byte[] { 47, 92, 133, 83, 98, 193, 132, 202 },
            new byte[] { 49, 92, 133, 86, 99, 197, 134, 205 },
            new byte[] { 52, 93, 133, 90, 100, 201, 137, 208 },
            new byte[] { 54, 93, 133, 94, 100, 204, 139, 211 },
            new byte[] { 57, 94, 134, 98, 101, 208, 142, 214 },
            new byte[] { 59, 94, 134, 101, 102, 211, 144, 216 },
            new byte[] { 62, 94, 135, 105, 103, 214, 146, 218 },
            new byte[] { 64, 94, 135, 108, 103, 216, 148, 220 },
            new byte[] { 66, 95, 135, 111, 104, 219, 151, 222 },
            new byte[] { 68, 95, 135, 114, 105, 221, 153, 223 },
            new byte[] { 71, 96, 136, 117, 106, 224, 155, 225 },
            new byte[] { 73, 96, 136, 120, 106, 225, 157, 226 },
            new byte[] { 76, 97, 136, 123, 107, 227, 159, 228 },
            new byte[] { 78, 97, 136, 126, 108, 229, 160, 229 },
            new byte[] { 80, 98, 137, 129, 109, 231, 162, 231 },
            new byte[] { 82, 98, 137, 131, 109, 232, 164, 232 },
            new byte[] { 84, 98, 138, 134, 110, 234, 166, 233 },
            new byte[] { 86, 98, 138, 137, 111, 235, 168, 234 },
            new byte[] { 89, 99, 138, 140, 112, 236, 170, 235 },
            new byte[] { 91, 99, 138, 142, 112, 237, 171, 235 },
            new byte[] { 93, 100, 139, 145, 113, 238, 173, 236 },
            new byte[] { 95, 100, 139, 147, 114, 239, 174, 237 },
            new byte[] { 97, 101, 140, 149, 115, 240, 176, 238 },
            new byte[] { 99, 101, 140, 151, 115, 241, 177, 238 },
            new byte[] { 101, 102, 140, 154, 116, 242, 179, 239 },
            new byte[] { 103, 102, 140, 156, 117, 242, 180, 239 },
            new byte[] { 105, 103, 141, 158, 118, 243, 182, 240 },
            new byte[] { 107, 103, 141, 160, 118, 243, 183, 240 },
            new byte[] { 109, 104, 141, 162, 119, 244, 185, 241 },
            new byte[] { 111, 104, 141, 164, 119, 244, 186, 241 },
            new byte[] { 113, 104, 142, 166, 120, 245, 187, 242 },
            new byte[] { 114, 104, 142, 168, 121, 245, 188, 242 },
            new byte[] { 116, 105, 143, 170, 122, 246, 190, 243 },
            new byte[] { 118, 105, 143, 171, 122, 246, 191, 243 },
            new byte[] { 120, 106, 143, 173, 123, 247, 192, 244 },
            new byte[] { 121, 106, 143, 175, 124, 247, 193, 244 },
            new byte[] { 123, 107, 144, 177, 125, 248, 195, 244 },
            new byte[] { 125, 107, 144, 178, 125, 248, 196, 244 },
            new byte[] { 127, 108, 145, 180, 126, 249, 197, 245 },
            new byte[] { 128, 108, 145, 181, 127, 249, 198, 245 },
            new byte[] { 130, 109, 145, 183, 128, 249, 199, 245 },
            new byte[] { 132, 109, 145, 184, 128, 249, 200, 245 },
            new byte[] { 134, 110, 146, 186, 129, 250, 201, 246 },
            new byte[] { 135, 110, 146, 187, 130, 250, 202, 246 },
            new byte[] { 137, 111, 147, 189, 131, 251, 203, 246 },
            new byte[] { 138, 111, 147, 190, 131, 251, 204, 246 },
            new byte[] { 140, 112, 147, 192, 132, 251, 205, 247 },
            new byte[] { 141, 112, 147, 193, 132, 251, 206, 247 },
            new byte[] { 143, 113, 148, 194, 133, 251, 207, 247 },
            new byte[] { 144, 113, 148, 195, 134, 251, 207, 247 },
            new byte[] { 146, 114, 149, 197, 135, 252, 208, 248 },
            new byte[] { 147, 114, 149, 198, 135, 252, 209, 248 },
            new byte[] { 149, 115, 149, 199, 136, 252, 210, 248 },
            new byte[] { 150, 115, 149, 200, 137, 252, 210, 248 },
            new byte[] { 152, 115, 150, 201, 138, 252, 211, 248 },
            new byte[] { 153, 115, 150, 202, 138, 252, 212, 248 },
            new byte[] { 155, 116, 151, 204, 139, 253, 213, 249 },
            new byte[] { 156, 116, 151, 205, 139, 253, 213, 249 },
            new byte[] { 158, 117, 151, 206, 140, 253, 214, 249 },
            new byte[] { 159, 117, 151, 207, 141, 253, 215, 249 },
            new byte[] { 161, 118, 152, 208, 142, 253, 216, 249 },
            new byte[] { 162, 118, 152, 209, 142, 253, 216, 249 },
            new byte[] { 163, 119, 153, 210, 143, 253, 217, 249 },
            new byte[] { 164, 119, 153, 211, 143, 253, 217, 249 },
            new byte[] { 166, 120, 153, 212, 144, 254, 218, 250 },
            new byte[] { 167, 120, 153, 212, 145, 254, 219, 250 },
            new byte[] { 168, 121, 154, 213, 146, 254, 220, 250 },
            new byte[] { 169, 121, 154, 214, 146, 254, 220, 250 },
            new byte[] { 171, 122, 155, 215, 147, 254, 221, 250 },
            new byte[] { 172, 122, 155, 216, 147, 254, 221, 250 },
            new byte[] { 173, 123, 155, 217, 148, 254, 222, 250 },
            new byte[] { 174, 123, 155, 217, 149, 254, 222, 250 },
            new byte[] { 176, 124, 156, 218, 150, 254, 223, 250 },
            new byte[] { 177, 124, 156, 219, 150, 254, 223, 250 },
            new byte[] { 178, 125, 157, 220, 151, 254, 224, 251 },
            new byte[] { 179, 125, 157, 220, 151, 254, 224, 251 },
            new byte[] { 180, 126, 157, 221, 152, 254, 225, 251 },
            new byte[] { 181, 126, 157, 221, 152, 254, 225, 251 },
            new byte[] { 183, 127, 158, 222, 153, 254, 226, 251 },
            new byte[] { 184, 127, 158, 223, 154, 254, 226, 251 },
            new byte[] { 185, 128, 159, 224, 155, 255, 227, 251 },
            new byte[] { 186, 128, 159, 224, 155, 255, 227, 251 },
            new byte[] { 187, 129, 160, 225, 156, 255, 228, 251 },
            new byte[] { 188, 130, 160, 225, 156, 255, 228, 251 },
            new byte[] { 189, 131, 160, 226, 157, 255, 228, 251 },
            new byte[] { 190, 131, 160, 226, 158, 255, 228, 251 },
            new byte[] { 191, 132, 161, 227, 159, 255, 229, 251 },
            new byte[] { 192, 132, 161, 227, 159, 255, 229, 251 },
            new byte[] { 193, 133, 162, 228, 160, 255, 230, 252 },
            new byte[] { 194, 133, 162, 229, 160, 255, 230, 252 },
            new byte[] { 195, 134, 163, 230, 161, 255, 231, 252 },
            new byte[] { 196, 134, 163, 230, 161, 255, 231, 252 },
            new byte[] { 197, 135, 163, 231, 162, 255, 231, 252 },
            new byte[] { 198, 135, 163, 231, 162, 255, 231, 252 },
            new byte[] { 199, 136, 164, 232, 163, 255, 232, 252 },
            new byte[] { 200, 136, 164, 232, 164, 255, 232, 252 },
            new byte[] { 201, 137, 165, 233, 165, 255, 233, 252 },
            new byte[] { 201, 137, 165, 233, 165, 255, 233, 252 },
            new byte[] { 202, 138, 166, 233, 166, 255, 233, 252 },
            new byte[] { 203, 138, 166, 233, 166, 255, 233, 252 },
            new byte[] { 204, 139, 166, 234, 167, 255, 234, 252 },
            new byte[] { 205, 139, 166, 234, 167, 255, 234, 252 },
            new byte[] { 206, 140, 167, 235, 168, 255, 235, 252 },
            new byte[] { 206, 140, 167, 235, 168, 255, 235, 252 },
            new byte[] { 207, 141, 168, 236, 169, 255, 235, 252 },
            new byte[] { 208, 141, 168, 236, 170, 255, 235, 252 },
            new byte[] { 209, 142, 169, 237, 171, 255, 236, 252 },
            new byte[] { 209, 143, 169, 237, 171, 255, 236, 252 },
            new byte[] { 210, 144, 169, 237, 172, 255, 236, 252 },
            new byte[] { 211, 144, 169, 237, 172, 255, 236, 252 },
            new byte[] { 212, 145, 170, 238, 173, 255, 237, 252 },
            new byte[] { 213, 145, 170, 238, 173, 255, 237, 252 },
            new byte[] { 214, 146, 171, 239, 174, 255, 237, 253 },
            new byte[] { 214, 146, 171, 239, 174, 255, 237, 253 },
            new byte[] { 215, 147, 172, 240, 175, 255, 238, 253 },
            new byte[] { 215, 147, 172, 240, 175, 255, 238, 253 },
            new byte[] { 216, 148, 173, 240, 176, 255, 238, 253 },
            new byte[] { 217, 148, 173, 240, 176, 255, 238, 253 },
            new byte[] { 218, 149, 173, 241, 177, 255, 239, 253 },
            new byte[] { 218, 149, 173, 241, 178, 255, 239, 253 },
            new byte[] { 219, 150, 174, 241, 179, 255, 239, 253 },
            new byte[] { 219, 151, 174, 241, 179, 255, 239, 253 },
            new byte[] { 220, 152, 175, 242, 180, 255, 240, 253 },
            new byte[] { 221, 152, 175, 242, 180, 255, 240, 253 },
            new byte[] { 222, 153, 176, 242, 181, 255, 240, 253 },
            new byte[] { 222, 153, 176, 242, 181, 255, 240, 253 },
            new byte[] { 223, 154, 177, 243, 182, 255, 240, 253 },
            new byte[] { 223, 154, 177, 243, 182, 255, 240, 253 },
            new byte[] { 224, 155, 178, 244, 183, 255, 241, 253 },
            new byte[] { 224, 155, 178, 244, 183, 255, 241, 253 },
            new byte[] { 225, 156, 178, 244, 184, 255, 241, 253 },
            new byte[] { 225, 157, 178, 244, 184, 255, 241, 253 },
            new byte[] { 226, 158, 179, 244, 185, 255, 242, 253 },
            new byte[] { 227, 158, 179, 244, 185, 255, 242, 253 },
            new byte[] { 228, 159, 180, 245, 186, 255, 242, 253 },
            new byte[] { 228, 159, 180, 245, 186, 255, 242, 253 },
            new byte[] { 229, 160, 181, 245, 187, 255, 242, 253 },
            new byte[] { 229, 160, 181, 245, 187, 255, 242, 253 },
            new byte[] { 230, 161, 182, 246, 188, 255, 243, 253 },
            new byte[] { 230, 162, 182, 246, 188, 255, 243, 253 },
            new byte[] { 231, 163, 183, 246, 189, 255, 243, 253 },
            new byte[] { 231, 163, 183, 246, 189, 255, 243, 253 },
            new byte[] { 232, 164, 184, 247, 190, 255, 243, 253 },
            new byte[] { 232, 164, 184, 247, 190, 255, 243, 253 },
            new byte[] { 233, 165, 185, 247, 191, 255, 244, 253 },
            new byte[] { 233, 165, 185, 247, 191, 255, 244, 253 },
            new byte[] { 234, 166, 185, 247, 192, 255, 244, 253 },
            new byte[] { 234, 167, 185, 247, 192, 255, 244, 253 },
            new byte[] { 235, 168, 186, 248, 193, 255, 244, 253 },
            new byte[] { 235, 168, 186, 248, 193, 255, 244, 253 },
            new byte[] { 236, 169, 187, 248, 194, 255, 244, 253 },
            new byte[] { 236, 169, 187, 248, 194, 255, 244, 253 },
            new byte[] { 236, 170, 188, 248, 195, 255, 245, 253 },
            new byte[] { 236, 170, 188, 248, 195, 255, 245, 253 },
            new byte[] { 237, 171, 189, 249, 196, 255, 245, 254 },
            new byte[] { 237, 172, 189, 249, 196, 255, 245, 254 },
            new byte[] { 238, 173, 190, 249, 197, 255, 245, 254 },
            new byte[] { 238, 173, 190, 249, 197, 255, 245, 254 },
            new byte[] { 239, 174, 191, 249, 198, 255, 245, 254 },
            new byte[] { 239, 174, 191, 249, 198, 255, 245, 254 },
            new byte[] { 240, 175, 192, 249, 199, 255, 246, 254 },
            new byte[] { 240, 176, 192, 249, 199, 255, 246, 254 },
            new byte[] { 240, 177, 193, 250, 200, 255, 246, 254 },
            new byte[] { 240, 177, 193, 250, 200, 255, 246, 254 },
            new byte[] { 241, 178, 194, 250, 201, 255, 246, 254 },
            new byte[] { 241, 178, 194, 250, 201, 255, 246, 254 },
            new byte[] { 242, 179, 195, 250, 202, 255, 246, 254 },
            new byte[] { 242, 180, 195, 250, 202, 255, 246, 254 },
            new byte[] { 242, 181, 196, 250, 203, 255, 247, 254 },
            new byte[] { 242, 181, 196, 250, 203, 255, 247, 254 },
            new byte[] { 243, 182, 197, 251, 204, 255, 247, 254 },
            new byte[] { 243, 183, 197, 251, 204, 255, 247, 254 },
            new byte[] { 244, 184, 198, 251, 205, 255, 247, 254 },
            new byte[] { 244, 184, 198, 251, 205, 255, 247, 254 },
            new byte[] { 244, 185, 199, 251, 206, 255, 247, 254 },
            new byte[] { 244, 185, 199, 251, 206, 255, 247, 254 },
            new byte[] { 245, 186, 200, 251, 207, 255, 247, 254 },
            new byte[] { 245, 187, 200, 251, 207, 255, 247, 254 },
            new byte[] { 246, 188, 201, 252, 207, 255, 248, 254 },
            new byte[] { 246, 188, 201, 252, 207, 255, 248, 254 },
            new byte[] { 246, 189, 202, 252, 208, 255, 248, 254 },
            new byte[] { 246, 190, 202, 252, 208, 255, 248, 254 },
            new byte[] { 247, 191, 203, 252, 209, 255, 248, 254 },
            new byte[] { 247, 191, 203, 252, 209, 255, 248, 254 },
            new byte[] { 247, 192, 204, 252, 210, 255, 248, 254 },
            new byte[] { 247, 193, 204, 252, 210, 255, 248, 254 },
            new byte[] { 248, 194, 205, 252, 211, 255, 248, 254 },
            new byte[] { 248, 194, 205, 252, 211, 255, 248, 254 },
            new byte[] { 248, 195, 206, 252, 212, 255, 249, 254 },
            new byte[] { 248, 196, 206, 252, 212, 255, 249, 254 },
            new byte[] { 249, 197, 207, 253, 213, 255, 249, 254 },
            new byte[] { 249, 197, 207, 253, 213, 255, 249, 254 },
            new byte[] { 249, 198, 208, 253, 214, 255, 249, 254 },
            new byte[] { 249, 199, 209, 253, 214, 255, 249, 254 },
            new byte[] { 250, 200, 210, 253, 215, 255, 249, 254 },
            new byte[] { 250, 200, 210, 253, 215, 255, 249, 254 },
            new byte[] { 250, 201, 211, 253, 215, 255, 249, 254 },
            new byte[] { 250, 202, 211, 253, 215, 255, 249, 254 },
            new byte[] { 250, 203, 212, 253, 216, 255, 249, 254 },
            new byte[] { 250, 203, 212, 253, 216, 255, 249, 254 },
            new byte[] { 251, 204, 213, 253, 217, 255, 250, 254 },
            new byte[] { 251, 205, 213, 253, 217, 255, 250, 254 },
            new byte[] { 251, 206, 214, 254, 218, 255, 250, 254 },
            new byte[] { 251, 206, 215, 254, 218, 255, 250, 254 },
            new byte[] { 252, 207, 216, 254, 219, 255, 250, 254 },
            new byte[] { 252, 208, 216, 254, 219, 255, 250, 254 },
            new byte[] { 252, 209, 217, 254, 220, 255, 250, 254 },
            new byte[] { 252, 210, 217, 254, 220, 255, 250, 254 },
            new byte[] { 252, 211, 218, 254, 221, 255, 250, 254 },
            new byte[] { 252, 212, 218, 254, 221, 255, 250, 254 },
            new byte[] { 253, 213, 219, 254, 222, 255, 250, 254 },
            new byte[] { 253, 213, 220, 254, 222, 255, 250, 254 },
            new byte[] { 253, 214, 221, 254, 223, 255, 250, 254 },
            new byte[] { 253, 215, 221, 254, 223, 255, 250, 254 },
            new byte[] { 253, 216, 222, 254, 224, 255, 251, 254 },
            new byte[] { 253, 217, 223, 254, 224, 255, 251, 254 },
            new byte[] { 253, 218, 224, 254, 225, 255, 251, 254 },
            new byte[] { 253, 219, 224, 254, 225, 255, 251, 254 },
            new byte[] { 254, 220, 225, 254, 225, 255, 251, 254 },
            new byte[] { 254, 221, 226, 254, 225, 255, 251, 254 },
            new byte[] { 254, 222, 227, 255, 226, 255, 251, 254 },
            new byte[] { 254, 223, 227, 255, 226, 255, 251, 254 },
            new byte[] { 254, 224, 228, 255, 227, 255, 251, 254 },
            new byte[] { 254, 225, 229, 255, 227, 255, 251, 254 },
            new byte[] { 254, 226, 230, 255, 228, 255, 251, 254 },
            new byte[] { 254, 227, 230, 255, 229, 255, 251, 254 },
            new byte[] { 255, 228, 231, 255, 230, 255, 251, 254 },
            new byte[] { 255, 229, 232, 255, 230, 255, 251, 254 },
            new byte[] { 255, 230, 233, 255, 231, 255, 252, 254 },
            new byte[] { 255, 231, 234, 255, 231, 255, 252, 254 },
            new byte[] { 255, 232, 235, 255, 232, 255, 252, 254 },
            new byte[] { 255, 233, 236, 255, 232, 255, 252, 254 },
            new byte[] { 255, 235, 237, 255, 233, 255, 252, 254 },
            new byte[] { 255, 236, 238, 255, 234, 255, 252, 254 },
            new byte[] { 255, 238, 240, 255, 235, 255, 252, 255 },
            new byte[] { 255, 239, 241, 255, 235, 255, 252, 254 },
            new byte[] { 255, 241, 243, 255, 236, 255, 252, 254 },
            new byte[] { 255, 243, 245, 255, 237, 255, 252, 254 },
            new byte[] { 255, 246, 247, 255, 239, 255, 253, 255 },
        };

        /* Array indices are identical to previously-existing INTRAMODECONTEXTNODES. */
        public static readonly sbyte[] Vp9IntraModeTree = new sbyte[]
        {
            -(sbyte)PredictionMode.DcPred,   2,                                 /* 0 = DC_NODE */
            -(sbyte)PredictionMode.TmPred,   4,                                 /* 1 = TM_NODE */
            -(sbyte)PredictionMode.VPred,    6,                                 /* 2 = V_NODE */
            8,                                 12,                                /* 3 = COM_NODE */
            -(sbyte)PredictionMode.HPred,    10,                                /* 4 = H_NODE */
            -(sbyte)PredictionMode.D135Pred, -(sbyte)PredictionMode.D117Pred, /* 5 = D135_NODE */
            -(sbyte)PredictionMode.D45Pred,  14,                                /* 6 = D45_NODE */
            -(sbyte)PredictionMode.D63Pred,  16,                                /* 7 = D63_NODE */
            -(sbyte)PredictionMode.D153Pred, -(sbyte)PredictionMode.D207Pred  /* 8 = D153_NODE */
        };

        public static readonly sbyte[] Vp9InterModeTree = new sbyte[]
        {
            -((sbyte)PredictionMode.ZeroMv - (sbyte)PredictionMode. NearestMv), 2,
            0, 4,
            -((sbyte)PredictionMode.NearMv - (sbyte)PredictionMode.NearestMv),
            -((sbyte)PredictionMode.NewMv - (sbyte)PredictionMode.NearestMv)
        };

        public static readonly sbyte[] Vp9PartitionTree = new sbyte[]
        {
            -(sbyte)PartitionType.PartitionNone, 2, -(sbyte)PartitionType.PartitionHorz, 4, -(sbyte)PartitionType.PartitionVert, -(sbyte)PartitionType.PartitionSplit
        };

        public static readonly sbyte[] Vp9SwitchableInterpTree = new sbyte[]
        {
            -Constants.EightTap, 2, -Constants.EightTapSmooth, -Constants.EightTapSharp
        };

        public static readonly sbyte[] Vp9SegmentTree = new sbyte[]
        {
            2, 4, 6, 8, 10, 12, 0, -1, -2, -3, -4, -5, -6, -7
        };

        // MV Ref

        // This is used to figure out a context for the ref blocks. The code flattens
        // an array that would have 3 possible counts (0, 1 & 2) for 3 choices by
        // adding 9 for each intra block, 3 for each zero mv and 1 for each new
        // motion vector. This single number is then converted into a context
        // with a single lookup ( CounterToContext ).
        public static readonly int[] Mode2Counter = new int[]
        {
            9,  // DC_PRED
            9,  // V_PRED
            9,  // H_PRED
            9,  // D45_PRED
            9,  // D135_PRED
            9,  // D117_PRED
            9,  // D153_PRED
            9,  // D207_PRED
            9,  // D63_PRED
            9,  // TM_PRED
            0,  // NEARESTMV
            0,  // NEARMV
            3,  // ZEROMV
            1,  // NEWMV
        };

        // There are 3^3 different combinations of 3 counts that can be either 0,1 or
        // 2. However the actual count can never be greater than 2 so the highest
        // counter we need is 18. 9 is an invalid counter that's never used.
        public static readonly MotionVectorContext[] CounterToContext = new MotionVectorContext[]
        {
            MotionVectorContext.BothPredicted,     // 0
            MotionVectorContext.NewPlusNonIntra,   // 1
            MotionVectorContext.BothNew,           // 2
            MotionVectorContext.ZeroPlusPredicted, // 3
            MotionVectorContext.NewPlusNonIntra,   // 4
            MotionVectorContext.InvalidCase,       // 5
            MotionVectorContext.BothZero,          // 6
            MotionVectorContext.InvalidCase,       // 7
            MotionVectorContext.InvalidCase,       // 8
            MotionVectorContext.IntraPlusNonIntra, // 9
            MotionVectorContext.IntraPlusNonIntra, // 10
            MotionVectorContext.InvalidCase,       // 11
            MotionVectorContext.IntraPlusNonIntra, // 12
            MotionVectorContext.InvalidCase,       // 13
            MotionVectorContext.InvalidCase,       // 14
            MotionVectorContext.InvalidCase,       // 15
            MotionVectorContext.InvalidCase,       // 16
            MotionVectorContext.InvalidCase,       // 17
            MotionVectorContext.BothIntra          // 18
        };

        public static readonly Position[][] MvRefBlocks = new Position[][]
        {
            // 4X4
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, -1 ),
            new Position( -2, 0 ),
            new Position( 0, -2 ),
            new Position( -2, -1 ),
            new Position( -1, -2 ),
            new Position( -2, -2 ) },
            // 4X8
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, -1 ),
            new Position( -2, 0 ),
            new Position( 0, -2 ),
            new Position( -2, -1 ),
            new Position( -1, -2 ),
            new Position( -2, -2 ) },
            // 8X4
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, -1 ),
            new Position( -2, 0 ),
            new Position( 0, -2 ),
            new Position( -2, -1 ),
            new Position( -1, -2 ),
            new Position( -2, -2 ) },
            // 8X8
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, -1 ),
            new Position( -2, 0 ),
            new Position( 0, -2 ),
            new Position( -2, -1 ),
            new Position( -1, -2 ),
            new Position( -2, -2 ) },
            // 8X16
            new Position[] { new Position( 0, -1 ),
            new Position( -1, 0 ),
            new Position( 1, -1 ),
            new Position( -1, -1 ),
            new Position( 0, -2 ),
            new Position( -2, 0 ),
            new Position( -2, -1 ),
            new Position( -1, -2 ) },
            // 16X8
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, 1 ),
            new Position( -1, -1 ),
            new Position( -2, 0 ),
            new Position( 0, -2 ),
            new Position( -1, -2 ),
            new Position( -2, -1 ) },
            // 16X16
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, 1 ),
            new Position( 1, -1 ),
            new Position( -1, -1 ),
            new Position( -3, 0 ),
            new Position( 0, -3 ),
            new Position( -3, -3 ) },
            // 16X32
            new Position[] { new Position( 0, -1 ),
            new Position( -1, 0 ),
            new Position( 2, -1 ),
            new Position( -1, -1 ),
            new Position( -1, 1 ),
            new Position( 0, -3 ),
            new Position( -3, 0 ),
            new Position( -3, -3 ) },
            // 32X16
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, 2 ),
            new Position( -1, -1 ),
            new Position( 1, -1 ),
            new Position( -3, 0 ),
            new Position( 0, -3 ),
            new Position( -3, -3 ) },
            // 32X32
            new Position[] { new Position( -1, 1 ),
            new Position( 1, -1 ),
            new Position( -1, 2 ),
            new Position( 2, -1 ),
            new Position( -1, -1 ),
            new Position( -3, 0 ),
            new Position( 0, -3 ),
            new Position( -3, -3 ) },
            // 32X64
            new Position[] { new Position( 0, -1 ),
            new Position( -1, 0 ),
            new Position( 4, -1 ),
            new Position( -1, 2 ),
            new Position( -1, -1 ),
            new Position( 0, -3 ),
            new Position( -3, 0 ),
            new Position( 2, -1 ) },
            // 64X32
            new Position[] { new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, 4 ),
            new Position( 2, -1 ),
            new Position( -1, -1 ),
            new Position( -3, 0 ),
            new Position( 0, -3 ),
            new Position( -1, 2 ) },
            // 64X64
            new Position[] { new Position( -1, 3 ),
            new Position( 3, -1 ),
            new Position( -1, 4 ),
            new Position( 4, -1 ),
            new Position( -1, -1 ),
            new Position( -1, 0 ),
            new Position( 0, -1 ),
            new Position( -1, 6 ) }
        };
    }
}
