using System;
using System.Numerics;

namespace Implementeringsprojekt {
    class HashChaining {

        public BigInteger MultiplyShit(BigInteger a, int l, BigInteger x) {
            return ( a * x ) >> (64 - l);
        }

        private BigInteger modulusP(BigInteger x, BigInteger p, int q) {
            BigInteger y = (x&p) + (x >> q);
            if ( y >= p ) {
                y -= p;
            }
            return y;
        }

        public BigInteger MultiplyModPrime(BigInteger a, BigInteger b, BigInteger l, BigInteger x) {
            int q = 89;
            BigInteger p = 2^q-1;
            BigInteger result = modulusP(a*x+b, p, q);
            return result & ( 2^l-1 );
        }
    }
}