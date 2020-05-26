using System;

namespace Implementeringsprojekt{

    static class CountSketch{

        public static UInt64 fourUniversal(UInt64[] a, UInt64 x){
            UInt64 y = a[3];
            UInt64 p = (UInt64)Math.Pow(2,89)-1;

            for (int i = 2; i > -1; i--){
                y = y * x + a[i];
                y = (y & p) + (y >> 89);
            }
            if ( y >= p){
                y = y - p;
            }

            return y;
        }
    }

}