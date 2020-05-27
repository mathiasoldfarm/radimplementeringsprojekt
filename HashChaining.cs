using System;
using System.Numerics;

namespace Implementeringsprojekt {
    static class HashChaining {
        private static UInt64 a = binaryStringToUInt64("10111011111000111000110001011001100010101101111101110001001011001011100000110110010110100");
        private static UInt64 b = binaryStringToUInt64("11101111111001100111111010010100000001011111010001010111101101110110110111011010111101100");

        public static UInt64 MultiplyShift(ulong x, int l) {
            UInt64 a = 0b1101010110100001000101100010000011111111000011110000101010111101;
            return ( a * x ) >> (64 - l);
        }

        private static UInt64 modulusP(UInt64 x, UInt64 p, int q) {
            UInt64 y = (x&p) + (x >> q);
            if ( y >= p ) {
                y -= p;
            }
            return y;
        }

        public static UInt64 binaryStringToUInt64 (string bitString) {
            UInt64 result = 0;
            
            foreach(char c in bitString) {
                result <<= 1;
                result += (UInt64)(c == '1' ? 1 : 0);
            }

            return result;
        }
        
        public static BigInteger binaryStringToBigInt (string bitString) {
            BigInteger result = 0;
            
            foreach(char c in bitString) {
                result <<= 1;
                result += (c == '1' ? 1 : 0);
            }

            return result;
        }

        public static UInt64 MultiplyModPrime(ulong x, int l) {
            int q = 89;
            UInt64 p = (UInt64) (2^q)-1;
            UInt64 result = modulusP(a*x+b, p, q);
            return (result & (UInt64)( (2^l) - 1 ));
        }
    }
}