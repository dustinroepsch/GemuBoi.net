using System;

//reg.a = 0x14
//reg.f = 0xc4
//print reg.af -> 0x14c4

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

        public void setZ(bool v)
        {
            if (v) {
                f |= 0b1000_0000;
            } else {
                f &= 0b0111_1111;
            }
        }

        public void setH(bool v) {
            if (v) {
                f |= 0b0010_0000;
            } else {
                f &= 0b1101_1111;
            }
        }

        public void setN(bool v) {
            if (v) {
                f |= 0b0100_0000;
            } else {
                f &= 0b1011_1111;
            }
        }


        public void setC(bool v) {
            if (v) {
                f |= 0b0001_0000;
            } else {
                f &= 0b1110_1111;
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
