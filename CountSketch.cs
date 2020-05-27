using System;
using System.Collections.Generic;
using System.Numerics;

namespace Implementeringsprojekt{

    static class CountSketch{

        public static BigInteger fourUniversal(BigInteger x) {
            int k = 4;
            BigInteger a1 = HashChaining.binaryStringToBigInt("01110100010111100111001110000001111111101101100101100000010110101001100011000001100110111");
            BigInteger a2 = HashChaining.binaryStringToBigInt("10011100010101111010100010100010100001001100100111110001011011101011001011111100100011010");
            BigInteger a3 = HashChaining.binaryStringToBigInt("10010001111000101001000110100001000010111110111011101101111011100000110011101011100010100");
            BigInteger a4 = HashChaining. binaryStringToBigInt("10110000111010001000000000010110111111001100001100011110011101110001101011010101010110001");
            
            
            BigInteger[] a = new BigInteger[4] {a1,a2,a3,a4};
            
            int b = 89;
            BigInteger y = a[k-1];
            BigInteger p = (BigInteger)Math.Pow(2,b)-1;

            for (int i = k-2; i > -1; i--) {
                y = y * x + a[i];
                y = (y & p) + (y >> b);
            }
            if ( y >= p) {
                y = y - p;
            }

            return y;
        }

        public static Tuple<BigInteger, BigInteger> CountSketchHash(Func<BigInteger, BigInteger> g, BigInteger x, BigInteger m) {
            int q = 89;
            BigInteger k = m;
            
            BigInteger gx = g(x);
            BigInteger hx = gx & (k - 1);
            BigInteger bx = gx >> (q - 1);
            BigInteger sx = 1 - 2 * bx;
            
            return new Tuple<BigInteger, BigInteger>(hx, sx);
        }

        public static BigInteger CountSketchAlgorithm(IEnumerable<Tuple<ulong, int>> stream) {
            UInt64 m = 4;
            BigInteger [] c = new BigInteger[m];
            for (UInt64 i = 0; i < m; i++) {
                c[i] = 0;
            }

            foreach (Tuple<ulong, int> data in stream) {
                Tuple<BigInteger, BigInteger>
                    hx_sx = CountSketchHash(CountSketch.fourUniversal, data.Item1, m);
                BigInteger hx = hx_sx.Item1;
                BigInteger sx = hx_sx.Item2;

                c[(UInt64)hx] += sx * data.Item2;
            }

            BigInteger X = 0;
            
            for (UInt64 i = 0; i < m; i++) {
                X += BigInteger.Pow(c[i], 2);
            }

            return X;

        }
    }

}