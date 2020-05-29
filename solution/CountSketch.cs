using System;
using System.Collections.Generic;
using System.Numerics;

namespace Implementeringsprojekt{

    static class CountSketch{

        public static BigInteger fourUniversal(BigInteger x, BigInteger[] a, BigInteger p) {
            
            int k = a.Length;
            
            BigInteger y = a[k-1];
            

            for (int i = k-2; i > -1; i--) {
                y = y * x + a[i];
                y = (y & p) + (y >> 89);
            }
            if ( y >= p) {
                y = y - p;
            }

            return y;
        }

        public static Tuple<UInt64, BigInteger> CountSketchHash(Func<BigInteger, BigInteger[], BigInteger, BigInteger> g, BigInteger x, BigInteger k, BigInteger[] a, BigInteger p) {
            int q = 89;
            
            BigInteger gx = g(x, a, p);
            UInt64 hx = (UInt64)(gx & (k - 1));
            BigInteger bx = gx >> (q - 1);
            BigInteger sx = 1 - 2 * bx;
            
            return new Tuple<UInt64, BigInteger>(hx, sx);
        }

        public static BigInteger CountSketchAlgorithm(IEnumerable<Tuple<ulong, int>> stream, int t) {
            UInt64 m = (UInt64)Math.Pow(2,t);

            BigInteger [] c = new BigInteger[m];
            for (UInt64 i = 0; i < m; i++) {
                c[i] = 0;
            }
            BigInteger p = (BigInteger)Math.Pow(2,89)-1;
            
            int k = 4;
            Random random = new Random();
            byte[] data = new byte[11];
            
            BigInteger[] a = new BigInteger[k];
            for (int i = 0; i < k; i++) {
                random.NextBytes(data);
                a[i] = new BigInteger(data);
            }

            foreach (Tuple<ulong, int> row in stream) {
                Tuple<UInt64, BigInteger>
                    hx_sx = CountSketchHash(CountSketch.fourUniversal, row.Item1, m, a, p);
                UInt64 hx = hx_sx.Item1;
                BigInteger sx = hx_sx.Item2;

                c[hx] += sx * row.Item2;
            }

            BigInteger X = 0;
            
            for (UInt64 i = 0; i < m; i++) {
                BigInteger ci = c[i];
                if (ci != 0) {
                    X += BigInteger.Pow(ci, 2);   
                }
            }

            return X;
        }
    }

}