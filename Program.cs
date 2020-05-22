using System;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {
            int n = 1000000;
            int l = 20;
            RunTimeTester testMultiplyShit = new RunTimeTester(
                n,
                l,
                HashChaining.MultiplyShift,
                "Multiply Shift"
            );
            RunTimeTester testMultiplyModPrime = new RunTimeTester(
                n,
                l,
                HashChaining.MultiplyModPrime,
                "Multiply Mod Prime"
            );
            
            //testMultiplyShit.RunTimer();
            //testMultiplyModPrime.RunTimer();
            
            Hashtable hashtable = new Hashtable(
                l,
                HashChaining.MultiplyShift
            );

            IEnumerable<Tuple<ulong, int>> stream = Stream.CreateStream( n, l );
            foreach (Tuple<ulong, int> data in stream) {
                hashtable.set(data.Item1, data.Item2);
            }
        }
    }
}
