using System;

namespace GemuBoi.net
{
    public class Registers
    {
        public byte a, f, b, c, d, e, h, l;
        public ushort pc, sp;

        public ushort af {
            get {
               return Makeushort(a, f);
            }
            set {
                a = LeastSigByte(value);
                f = MostSigByte(value);
            }
        }

        public ushort bc {
            get {
                return Makeushort(b, c);
            } set {
                b = LeastSigByte(value);
                c = MostSigByte(value);
            }
        }

        public ushort de
        {
            get
            {
                return Makeushort(d, e);
            }
            set
            {
                d = LeastSigByte(value);
                e = MostSigByte(value);
            }
        }

        public ushort hl
        {
            get
            {
                return Makeushort(h, l);
            }
            set
            {
                h = LeastSigByte(value);
                l = MostSigByte(value);
            }
        }

        //gameboy is little endian
        private byte LeastSigByte(ushort value) => (byte)(0xFF & (value >> 8));

        private byte MostSigByte(ushort value) => (byte)(0xFF & value);

        private ushort Makeushort(byte lsb, byte msb) => (ushort)((lsb << 8) ^ msb);
        

        public Registers()
        {
            Reset();
        }

        public void Reset()
        {
            a = f = b = c = d = e = h = l = 0;
            sp = pc = 0;
        }

    }
}
