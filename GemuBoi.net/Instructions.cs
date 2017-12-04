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

        public static Instruction Ox0_0_noop = (mem, regs) => 4;

        public static Instruction Ox0_1_LD_BC_D16 = (mem, regs) => {
            regs.b = mem.readByte(++regs.pc);
            regs.c = mem.readByte(++regs.pc);
            regs.pc++;
            return 12;
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

