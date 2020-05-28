using System;
using System.Collections.Generic;
using System.Numerics;

namespace Implementeringsprojekt {
    static class Sums {
        public static Hashtable hashtable { get; private set; }
        public static IEnumerable<Tuple<ulong, int>> stream { get; private set; }
        
        public static void createHashTable(int n, int l, Func<ulong, int, UInt64> hashFunction) {
            hashtable = new Hashtable(
                l,
                hashFunction
            );
            stream = Stream.CreateStream(n, l);
            
            foreach (Tuple<ulong, int> data in stream) {
                hashtable.increment(data.Item1, data.Item2);
            }
        }

        public static UInt64 squareSum () {
            UInt64 squareSum = 0;
            foreach (List<CustomTuple<UInt64, int>> list in hashtable.hashtable) {
                if ( list != null) {
                    foreach (CustomTuple<UInt64, int> keyValue in list) {
                        squareSum += (UInt64) Math.Pow(keyValue.Item2, 2);
                    }   
                }
            }

            return squareSum;
        }

        public static BigInteger meanSquareError(BigInteger[] c, BigInteger s){
            BigInteger mse = 0;
            foreach (BigInteger x in c) {
                Console.WriteLine($"{x-s}");
                mse += (BigInteger.Pow((x - s),2))/100;
            }
            
            return mse;
        }

        public static void median(BigInteger[]c) {
            BigInteger[,] g = new BigInteger[9,11];
            BigInteger[] median = new BigInteger[9];
            for (int i = 0; i < 9; i++){
                for (int j = 0; j < 11; j++){
                    g[i,j] = c[j];
                }
            }
            for (int k = 0; k < 9; k++){
                median[k] = g[k,7];
            }
            Array.Sort(median);
            Console.WriteLine(median.ToString());
        }
    }
}