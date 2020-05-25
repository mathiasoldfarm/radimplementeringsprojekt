using System;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {
            
            int n = 1000;
            int l = 8;
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

            Sums.createHashTable(n, l, HashChaining.MultiplyShift);
            UInt64 squareSum = Sums.squareSum();
            
            Console.WriteLine(squareSum);
            //Sums.hashtable.print();

        }
    }
}
