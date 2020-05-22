using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Implementeringsprojekt {
    public class RunTimeTester {
        private IEnumerable<Tuple<ulong, int>> stream;
        private Func<ulong, int, BigInteger> methodToTest;
        private string name;
        

        public RunTimeTester(int n, int l, Func<ulong, int, BigInteger> _methodToTest, string _name) {
            stream = Stream.CreateStream( n, l );
            methodToTest = _methodToTest;
            name = _name;
        }

        private BigInteger calculateSum() {
            BigInteger sum = 0;
            foreach (Tuple<ulong, int> row in stream) {
                sum += methodToTest(row.Item1, row.Item2);
            }

            return sum;
        }

        public void RunTimer() {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            BigInteger sum = calculateSum();
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            Console.WriteLine($"{name}, time in miliseconds: {time.TotalMilliseconds}");
        }
        
    }
}