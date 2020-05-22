using System;
using System.Numerics;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {
            int n = 1000000;
            int l = 63;
            RunTimeTester testMultiplyShit = new RunTimeTester(
                n,
                l,
                HashChaining.MultiplyShit,
                "Multiply Shift"
            );
            RunTimeTester testMultiplyModPrime = new RunTimeTester(
                n,
                l,
                HashChaining.MultiplyModPrime,
                "Multiply Mod Prime"
            );
            
            testMultiplyShit.RunTimer();
            testMultiplyModPrime.RunTimer();
        }
    }
}
