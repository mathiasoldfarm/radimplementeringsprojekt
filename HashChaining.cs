using System;
using System.Numerics;

namespace Implementeringsprojekt {
    static class HashChaining {
        private static BigInteger a = binaryStringToBigInteger("10111011111000111000110001011001100010101101111101110001001011001011100000110110010110100");
        private static BigInteger b = binaryStringToBigInteger("11101111111001100111111010010100000001011111010001010111101101110110110111011010111101100");

        public static BigInteger MultiplyShit(ulong x, int l) {
            ulong a = 0b1101010110100001000101100010000011111111000011110000101010111101;
            return ( a * x ) >> (64 - l);
        }

        private static BigInteger modulusP(BigInteger x, BigInteger p, int q) {
            BigInteger y = (x&p) + (x >> q);
            if ( y >= p ) {
                y -= p;
            }
            return y;
        }

        private static BigInteger binaryStringToBigInteger (string bitString) {
            BigInteger result = 0;
            
            foreach(char c in bitString) {
                result <<= 1;
                result += c == '1' ? 1 : 0;
            }

            return result;
        }

        public static BigInteger MultiplyModPrime(ulong x, int l) {
            int q = 89;
            BigInteger p = (2^q)-1;
            BigInteger result = modulusP(a*x+b, p, q);
            return result & ( (2^l) - 1 );
        }
    }
}