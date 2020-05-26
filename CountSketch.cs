using System;
using System.Collections.Generic;

namespace Implementeringsprojekt{

    static class CountSketch{

        public static UInt64 fourUniversal(UInt64 x) {
            int k = 4;
            UInt64[] a = new UInt64[k];
            int b = 89;
            UInt64 y = a[k-1];
            UInt64 p = (UInt64)Math.Pow(2,b)-1;

            for (int i = k-2; i > -1; i--) {
                y = y * x + a[i];
                y = (y & p) + (y >> b);
            }
            if ( y >= p){
                y = y - p;
            }

            return y;
        }

        public static Tuple<UInt64, UInt64> CountSketchHash(Func<UInt64, UInt64> g, UInt64 x) {
            int q = 89;
            UInt64 k = 4;
            
            UInt64 gx = g(x);
            UInt64 hx = gx & (k - 1);
            UInt64 bx = gx << (q - 1);
            UInt64 sx = 1 - 2 * bx;
            
            return new Tuple<UInt64, UInt64>(hx, sx);
        }

        public static UInt64 CountSketchAlgorithm(UInt64 m, IEnumerable<Tuple<ulong, int>> stream) {
            UInt64 [] c = new UInt64[m];
            for (UInt64 i = 0; i < m; i++) {
                c[i] = 0;
            }

            foreach (Tuple<ulong, int> data in stream) {
                Tuple<UInt64, UInt64>
                    hx_sx = CountSketchHash(CountSketch.fourUniversal, data.Item1);
                UInt64 hx = hx_sx.Item1;
                UInt64 sx = hx_sx.Item2;

                c[hx] = c[hx] + sx * (UInt64)data.Item2;
            }

            UInt64 X = 0;
            
            for (UInt64 i = 0; i < m; i++) {
                X += (UInt64) Math.Pow(c[i], 2);
            }

            return X;

        }
    }

}