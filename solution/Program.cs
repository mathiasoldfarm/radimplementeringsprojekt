using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();

            int l = 15;
            int s = 10000000;

            int smallL = 8;
            int bigL = 15;
            int testSmall = (int)Math.Pow(2,smallL)*5; 
            int testBig = (int)Math.Pow(2,bigL)*5;

            int manyKeys = 12;
            int bigStream = (int)Math.Pow(2,manyKeys)*5;
        
            // Opg. 1c
            RunTimeTester test1 = new RunTimeTester(s,l,HashChaining.MultiplyShift,"Multiply Shift");
            RunTimeTester test2 = new RunTimeTester(s,l,HashChaining.MultiplyModPrime,"Multiply Mod Prime");
            test1.RunTimer();
            test2.RunTimer();
            stopwatch.Reset();
            // Opg. 3
            // Testing small stream, few different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(testSmall, smallL, HashChaining.MultiplyShift);
            BigInteger squareSum1 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time1 = stopwatch.Elapsed;
            stopwatch.Reset();


            // Testing small stream, few different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(testSmall, smallL, HashChaining.MultiplyModPrime);
            BigInteger squareSum2 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time2 = stopwatch.Elapsed;
            stopwatch.Reset();
            
            // Testing small stream, many different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(testSmall, bigL, HashChaining.MultiplyShift);
            BigInteger squareSum3 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time3 = stopwatch.Elapsed;
            stopwatch.Reset();

            // Testing small stream, many different keys, and Multiply Mod prime
            stopwatch.Start();
            Sums.createHashTable(testSmall, bigL, HashChaining.MultiplyModPrime);
            BigInteger squareSum4 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time4 = stopwatch.Elapsed;
            stopwatch.Reset();

            // Testing big stream, few different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(testBig, smallL, HashChaining.MultiplyShift);
            BigInteger squareSum5 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time5 = stopwatch.Elapsed;
            stopwatch.Reset();

            // Testing big stream, few different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(testBig, smallL, HashChaining.MultiplyModPrime);
            BigInteger squareSum6 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time6 = stopwatch.Elapsed;
            stopwatch.Reset();

            // Testing big stream, many diferent keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(testBig, bigL, HashChaining.MultiplyShift);
            BigInteger squareSum7 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time7 = stopwatch.Elapsed;
            stopwatch.Reset();

            // Testing big stream, many different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(testBig, bigL, HashChaining.MultiplyModPrime);
            BigInteger squareSum8 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time8 = stopwatch.Elapsed;
            stopwatch.Reset();


            Console.WriteLine($"Multiply Shift, small stream, few keys: S = {squareSum1}, Time = {time1} ");
            Console.WriteLine($"Multiply Shift, small stream, many keys: S = {squareSum3}, Time = {time3} ");
            Console.WriteLine($"Multiply Shift, big stream, few keys: S = {squareSum5}, Time = {time5} ");
            Console.WriteLine($"Multiply Shift, big stream, many keys: S = {squareSum7}, Time = {time7} ");         
            Console.WriteLine($"Multiply Mod Prime, small stream, few keys: S = {squareSum2}, Time = {time2} ");
            Console.WriteLine($"Multiply Mod Prime, small stream, many keys: S = {squareSum4}, Time = {time4} ");   
            Console.WriteLine($"Multiply Mod Prime, big stream, few keys: S = {squareSum6}, Time = {time6} ");            
            Console.WriteLine($"Multiply Mod Prime, big stream, many keys: S = {squareSum8}, Time = {time8} ");



            /*
            int[] ts = new int[] { 5, 10, 20 };

            for (int i = 0; i < ts.Length; i++) {
                int t = ts[i];
                int n = 100;
                BigInteger[] experiments = new BigInteger[n];

                for (int j = 0; j < n; j++) {
                    BigInteger X = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                    experiments[j] = X;
                }
                
                stopwatch.Start();
                BigInteger test = CountSketch.CountSketchAlgorithm(Sums.stream, t);
                stopwatch.Stop();

                Console.WriteLine(
                    $"MSE: {Sums.meanSquareError(experiments, squareSum)} {stopwatch.Elapsed / 100}");
                Console.WriteLine("");
                
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
            
            
            IEnumerable<Tuple<ulong, int>> stream = Stream.CreateStream(6, 2);
            foreach (Tuple<ulong, int> tple in stream) {
                Console.WriteLine(tple);
            }
            Console.WriteLine("");
            stream = Stream.CreateStream(6, 2);
            foreach (Tuple<ulong, int> tple in stream) {
                Console.WriteLine(tple);
            }
            */
        }
    }
}
