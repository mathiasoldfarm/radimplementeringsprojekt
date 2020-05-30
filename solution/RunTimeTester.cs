using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Implementeringsprojekt {
    public class RunTimeTester {
        private IEnumerable<Tuple<ulong, int>> stream;
        private Func<ulong, int, UInt64> methodToTest;
        private string name;
        private int _l;
        

        public RunTimeTester(int n, int l, Func<ulong, int, UInt64> _methodToTest, string _name) {
            stream = Stream.CreateStream( n, l );
            methodToTest = _methodToTest;
            name = _name;
            _l = l;
        }

        public UInt64 calculateSum() {
            UInt64 sum = 0;
            foreach (Tuple<ulong, int> row in stream) {
                sum += methodToTest(row.Item1, _l);
            }

            return sum;
        }

        public void RunTimer() {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            UInt64 sum = calculateSum();
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            Console.WriteLine($"{name}, time in miliseconds: {time.TotalMilliseconds}");
        }
    }
}