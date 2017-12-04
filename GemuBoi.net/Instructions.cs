using System;
namespace GemuBoi.net
{
    public class Instructions
    {
        /*
         * An Instruction takes memory and Registers, and returns the number of clock cycles
         * it took to execute
         */
        public delegate int Instruction(Memory mem, Registers regs);

        public static int LD_XY_D16(Memory mem, Registers regs, ref byte x, ref byte y) {
            x = mem.readByte(++regs.pc);
            y = mem.readByte(++regs.pc);
            regs.pc++;
            return 12;
        }

        public static int LD_D_S(Memory mem, Registers regs, ref byte destination, ref byte source) {
            destination = source;
            regs.pc++;
            return 4;
        }


        public static Instruction Ox0_0_noop = (mem, regs) => 4;

        public static Instruction Ox0_1_LD_BC_D16 = (mem, regs) => {
            return LD_XY_D16(mem, regs, ref regs.b, ref regs.c);
        };

        public static Instruction Ox1_1_LD_DE_D16 = (mem, regs) =>
        {
            return LD_XY_D16(mem, regs, ref regs.d, ref regs.e);
        };

        public static Instruction Ox2_1_LD_HL_D16 = (mem, regs) => {
            return LD_XY_D16(mem, regs, ref regs.h, ref regs.l);
        };

        public static Instruction Ox3_1_LD_SP_D16 = (mem, regs) => 
        {
            byte lsb = mem.readByte(++regs.pc);
            byte msb = mem.readByte(++regs.pc);
            regs.pc++;
            regs.sp = Registers.Makeushort(lsb, msb);
            return 12;
        };

        public static Instruction Ox4_1_LD_B_C = (mem, regs) => {
            return LD_D_S(mem, regs, ref regs.b, ref regs.c);
        };


        public static Instruction Ox0_2_LD_M_BC_A = (mem, regs) => {
            mem.writeByte(regs.bc, regs.a);
            regs.pc++;
            return 8;
        };

        public static Instruction Ox0_3_INC_BC = (mem, regs) => {
            regs.bc++;
            regs.pc++;
            return 8;
        };

        public static Instruction Ox0_4_INC_B = (mem, regs) =>
        {
            regs.setH(checkHalfCarry(regs.b, 1));
            regs.b++;
            regs.setZ(regs.b == 0);
            regs.setN(false);
            return 4;
        };

        public static Instruction Ox0_5_DEC_B = (mem, regs) => {
            regs.setH(checkHalfCarry(regs.b, 1));
            regs.b--;
            regs.setZ(regs.b == 0);
            regs.setN(true);
        };



        private static bool checkHalfCarry(byte a, byte b)
        {
            return (((a & 0xF) + (b & 0xF)) & 0x10) == 0x10;
        }
    }
    }

