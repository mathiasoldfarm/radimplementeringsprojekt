using System;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    static class Sums {
        public static Hashtable hashtable { get; private set; }
        private static IEnumerable<Tuple<ulong, int>> stream;
        
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
    }
}