using System;
namespace GemuBoi.net
{
    public class Instructions
    {
        public delegate int Instruction(Memory mem, Registers regs);

        Instruction noop => (mem, regs) => 4;
    }
}
