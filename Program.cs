using System;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {
            IEnumerable<Tuple<ulong, int>> stream = Stream.CreateStream( 1000, 5 );
            foreach (var row in stream) {
                Console.WriteLine(row);
            }
        }
    }
}
