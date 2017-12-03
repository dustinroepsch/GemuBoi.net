using System;

namespace GemuBoi.net
{
    /*
     * An Instruction takes memory and Registers, and returns the number of clock cycles
     * it took to execute
     */

    public class InstructionDecoder
    {

        public static Instructions.Instruction Decode(Memory memory, ushort pc)
        {
            return (mem, regs) => 4;
        }
    }
}
