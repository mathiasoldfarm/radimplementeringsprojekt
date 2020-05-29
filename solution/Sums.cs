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

        public static BigInteger squareSum () {
            BigInteger squareSum = 0;
            foreach (List<CustomTuple<UInt64, int>> list in hashtable.hashtable) {
                if ( list != null) {
                    foreach (CustomTuple<UInt64, int> keyValue in list) {
                        squareSum +=  BigInteger.Pow(keyValue.Item2, 2);
                    }   
                }
            }

            return squareSum;
        }

        public static BigInteger meanSquareError(BigInteger[] c, BigInteger s){
            BigInteger mse = 0;
            foreach (BigInteger x in c) {
                mse += (BigInteger.Pow((x - s),2))/100;
            }
            
            return mse;
        }

        public static int[] median(BigInteger[] c) {
            int[] medians = new int[9];
            List<int[]> groups = new List<int[]>();
            for (int i = 0; i < 9; i++) {
                int[] group = new int[11];
                for (int j = 0; j < 11; j++){
                    group[j] = (int) c[(i*11)+j];
                }
                groups.Add(group);
            }

            int index = 0;
            foreach (int[] group in groups) {
                Array.Sort(group);
                medians[index] = group[5];
                index++;
            }

            return medians;

            /*
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
            */
        }
    }
}