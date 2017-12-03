using System;
namespace GemuBoi.net.Properties
{
    public interface IGBInstruction
    {
        int Execute(Registers regs, Memory mem);
    }
}
