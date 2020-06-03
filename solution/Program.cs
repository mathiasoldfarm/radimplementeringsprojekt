using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            int n = (int)Math.Pow(2, 24) * 5;

            int l = 25;
            int s = 10000000;

            IEnumerable<Tuple<ulong, int>> stream = Stream.CreateStream(s, l);
            
            stopwatch.Start();
            BigInteger sum = HashChaining.calculateSum(HashChaining.MultiplyShift, stream, l);
            stopwatch.Stop();
            Console.WriteLine($"Runtime MultiplyShift: {stopwatch.Elapsed}, sum: {sum}");
            stopwatch.Reset();
            
            stopwatch.Start();
            sum = HashChaining.calculateSum(HashChaining.MultiplyModPrime, stream, l);
            stopwatch.Stop();
            Console.WriteLine($"Runtime MultiplyModPrime: {stopwatch.Elapsed}, sum: {sum}");
            stopwatch.Reset();
            
            stopwatch.Start();
            sum = HashChaining.calculateSum(CountSketch.fourUniversal, stream);
            stopwatch.Stop();
            Console.WriteLine($"Runtime FourUniversal: {stopwatch.Elapsed}, sum: {sum}");
            stopwatch.Reset();
            
            stopwatch.Start();
            sum = HashChaining.calculateSum(CountSketch.CountSketchHash, 25, stream);
            stopwatch.Stop();
            Console.WriteLine($"Runtime FourUniversal: {stopwatch.Elapsed}, sum: {sum}");
            stopwatch.Reset();

            int[] ls = new int[] { 4, 6, 10, 14, 18, 20, 24 };

            foreach (int _l in ls) {
            
                // Opg. 3
                // Testing small stream, few different keys, and Multiply Shift
                stopwatch.Start();
                Sums.createHashTable(n, _l, HashChaining.MultiplyShift);
                BigInteger squareSum1 = Sums.squareSum();
                stopwatch.Stop();
                TimeSpan time1 = stopwatch.Elapsed;
                stopwatch.Reset();


                // Testing small stream, few different keys, and Multiply Mod Prime
                stopwatch.Start();
                Sums.createHashTable(n, _l, HashChaining.MultiplyModPrime);
                BigInteger squareSum2 = Sums.squareSum();
                stopwatch.Stop();
                TimeSpan time2 = stopwatch.Elapsed;
                stopwatch.Reset();

                Console.WriteLine($"Multiply Shift, l = {_l}, S = {squareSum1}, Time = {time1} ");   
                Console.WriteLine($"Multiply Mod Prime, l = {_l}, S = {squareSum2}, Time = {time2} ");

                double diff = time2 / time1;
                Console.WriteLine(diff);
                Console.WriteLine("");
            }
            int smallN = (int)Math.Pow(2, 17) * 5;
            int smallL = 17;
            
            stopwatch.Start();
            Sums.createHashTable(smallN, smallL, HashChaining.MultiplyShift);
            BigInteger squareSum = Sums.squareSum();
            stopwatch.Stop();
            Console.WriteLine($"Time for squaresum, l = 17: s = {squareSum}, time: {stopwatch.Elapsed}");
            stopwatch.Reset();

            int[] ts = new int[] { 10, 15, 20, 25 };

            for (int i = 0; i < ts.Length; i++) {
                int t = ts[i];
                int number_experiments = 100;
                BigInteger[] experiments = new BigInteger[number_experiments];

                for (int j = 0; j < number_experiments; j++) {
                    BigInteger X = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                    experiments[j] = X;
                }
                
                stopwatch.Start();
                BigInteger test = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                stopwatch.Stop();

                Console.WriteLine(
                    $"MSE: {Sums.meanSquareError(experiments, squareSum)} {stopwatch.Elapsed / 100}");
                Console.WriteLine("");
                stopwatch.Reset();
                
                int[] medians = Sums.median(experiments);
            
                using (System.IO.StreamWriter file = new System.IO.StreamWriter($"../results/medians-{i}.txt")) {
                    foreach (int median in medians) {
                        file.WriteLine(median);
                    }
                }

                Array.Sort(experiments);
            
                using (System.IO.StreamWriter file = new System.IO.StreamWriter($"../results/experiments-result-{i}.txt")) {
                    foreach (BigInteger result in experiments) {
                        file.WriteLine(result);
                    }
                }
            
                using (System.IO.StreamWriter file = new System.IO.StreamWriter($"../results/squaresum-{i}.txt")) {
                    file.WriteLine(squareSum);
                }
            }


            n = (int)Math.Pow(2, 24)*5;
            l = 24;
            
            stopwatch.Start();
            Sums.createHashTable(n, l, HashChaining.MultiplyShift);
            squareSum = Sums.squareSum();
            stopwatch.Stop();
            Console.WriteLine($"Time for squaresum, l = 17: s = {squareSum}, time: {stopwatch.Elapsed}");
            stopwatch.Reset();
            
            for (int i = 0; i < ts.Length; i++) {
                int t = ts[i];
                int number_experiments = 3;
                BigInteger[] experiments = new BigInteger[number_experiments];

                for (int j = 0; j < number_experiments; j++) {
                    BigInteger X = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                    experiments[j] = X;
                }
                
                stopwatch.Start();
                BigInteger test = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                stopwatch.Stop();

                Console.WriteLine(
                    $"MSE: {Sums.meanSquareError(experiments, squareSum)} {stopwatch.Elapsed / 100}");
                Console.WriteLine("");
                stopwatch.Reset();
            }
        }
    }
}
