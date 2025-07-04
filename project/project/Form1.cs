using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        uint H0 = 0x6a09e667;
        uint H1 = 0xbb67ae85;
        uint H2 = 0x3c6ef372;
        uint H3 = 0xa54ff53a;
        uint H4 = 0x510e527f;
        uint H5 = 0x9b05688c;
        uint H6 = 0x1f83d9ab;
        uint H7 = 0x5be0cd19;

        private static readonly uint[] K = {
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5,
        0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3,
        0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc,
        0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7,
        0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13,
        0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3,
        0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5,
        0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208,
        0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
    };

        private uint Rotr(uint a, int b)
        {
            return ((a >> b) | (a << 32 - b));
        }

        private uint S0(uint a)
        {
            return Rotr(a, 7) ^ Rotr(a, 18) ^ (a >> 3);
        }

        private uint S1(uint a)
        {
            return Rotr(a, 17) ^ Rotr(a, 19) ^ (a >> 10);
        }

        private uint E0(uint a)
        {
            return Rotr(a, 2) ^ Rotr(a, 13) ^ Rotr(a, 22);
        }

        private uint E1(uint a)
        {
            return Rotr(a, 6) ^ Rotr(a, 11) ^ Rotr(a, 25);
        }

        private uint Ch(uint a, uint b, uint c)
        {
            return (a & b) ^ ((~a) & c);
        }

        private uint Maj(uint a, uint b, uint c)
        {
            return (a & b) ^ (a & c) ^ (b & c);
        }

        public List<uint> normVid(string message)
        {
            List<byte> bytes = new List<byte>();

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            bytes.AddRange(messageBytes);

            bytes.Add(0x80);

            while ((bytes.Count * 8) % 512 != 448)
            {
                bytes.Add(0x00);
            }

            ulong bitLength = (ulong)messageBytes.Length * 8;
            bytes.AddRange(BitConverter.GetBytes(bitLength).Reverse());

            List<uint> blocks = new List<uint>();
            for (int i = 0; i < bytes.Count; i += 4)
            {
                uint block = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (i + j < bytes.Count)
                    {
                        block |= (uint)(bytes[i + j] << ((3 - j) * 8));
                    }
                }
                blocks.Add(block);
            }
            return blocks;
        }

        private void goHash_Click(object sender, EventArgs j)
        {
            H0 = 0x6a09e667;
            H1 = 0xbb67ae85;
            H2 = 0x3c6ef372;
            H3 = 0xa54ff53a;
            H4 = 0x510e527f;
            H5 = 0x9b05688c;
            H6 = 0x1f83d9ab;
            H7 = 0x5be0cd19;

            uint a = H0;
            uint b = H1;
            uint c = H2;
            uint d = H3;
            uint e = H4;
            uint f = H5;
            uint g = H6;
            uint h = H7;

            List<uint> blocks = normVid(text.Text);

            uint[] W = new uint[64];

            for (int i = 0; i < 64; i++)
            {
                if (i < 16)
                {
                    W[i] = blocks[i];
                }
                else
                {
                    W[i] = W[i - 16] + S0(W[i - 15]) + W[i - 7] + S1(W[i - 2]);
                }

                uint T1 = h + E1(e) + Ch(e, f, g) + K[i] + W[i];
                uint T2 = E0(a) + Maj(a, b, c);
                h = g;
                g = f;
                f = e;
                e = d + T1;
                d = c;
                c = b;
                b = a;
                a = T1 + T2;
            }

            H0 += a;
            H1 += b;
            H2 += c;
            H3 += d;
            H4 += e;
            H5 += f;
            H6 += g;
            H7 += h;

            result.Text = Convert.ToString(H0, 16) + Convert.ToString(H1, 16) + Convert.ToString(H2, 16) + Convert.ToString(H3, 16) + Convert.ToString(H4, 16) + Convert.ToString(H5, 16) + Convert.ToString(H6, 16) + Convert.ToString(H7, 16);
        }
    }
}
