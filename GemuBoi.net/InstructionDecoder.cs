using System;
namespace GemuBoi.net
{
    public class InstructionDecoder
    {
        private Instructions.Instruction[] prefixedInstructions;
        private Instructions.Instruction[] unprefixedInstructions;

        public InstructionDecoder() {
            prefixedInstructions = mapPrefixedInstructions();
            unprefixedInstructions = mapUnprefixedInstructions();
        }

        private Instructions.Instruction[] mapUnprefixedInstructions()
        {
            Instructions.Instruction[] instructions = new Instructions.Instruction[256];

            instructions[0x00] = Instructions.Ox0_0_noop;

            instructions[0x01] = Instructions.Ox0_1_LD_BC_D16;

            instructions[0x02] = Instructions.Ox0_2_LD_M_BC_A;

            instructions[0x03] = Instructions.Ox0_3_INC_BC;

            instructions[0x04] = Instructions.Ox0_4_INC_B;

            instructions[0x05] = Instructions.Ox0_5_DEC_B;


            return instructions;
        }

        private Instructions.Instruction[] mapPrefixedInstructions()
        {
            throw new NotImplementedException();
        }
    }
}
