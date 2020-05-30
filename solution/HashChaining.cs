using System;
using System.Numerics;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    static class HashChaining {
        private static UInt64 a = binaryStringToUInt64("10111011111000111000110001011001100010101101111101110001001011001011100000110110010110100");
        private static UInt64 b = binaryStringToUInt64("11101111111001100111111010010100000001011111010001010111101101110110110111011010111101100");

        public static UInt64 MultiplyShift(ulong x, int l) {
            UInt64 a = 0b1101010110100001000101100010000011111111000011110000101010111101;
            return ( a * x ) >> (64 - l);
        }

        private static BigInteger modulusP(UInt64 x, BigInteger p, int q) {
            BigInteger y = (x&p) + (x >> q);
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
            BigInteger p = BigInteger.Pow(2,q) - 1;
            BigInteger result = modulusP(a*x+b, p, q);
            return (UInt64)(result & ( BigInteger.Pow(2, l) - 1 ));
        }
        
        public static BigInteger calculateSum(Func<ulong, int, UInt64> methodToTest, IEnumerable<Tuple<ulong, int>> stream, int l) {
            BigInteger sum = 0;
            foreach (Tuple<ulong, int> row in stream) {
                sum += methodToTest(row.Item1, l);
            }

            return sum;
        }
    }
}