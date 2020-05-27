using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Implementeringsprojekt {
    class Program {
        static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();

            int testN = 1000;
            int testL = 4;
            
            int smallStream = 100000;
            int bigStream = 10000;
            int fewKeys = 4;
            int manyKeys = 4;
            /*
            // Opg. 1c
            RunTimeTester test1 = new RunTimeTester(testN,testL,HashChaining.MultiplyShift,"Multiply Shift");
            RunTimeTester test2 = new RunTimeTester(testN,testL,HashChaining.MultiplyModPrime,"Multiply Mod Prime");
            test1.RunTimer();
            test2.RunTimer();
            // Opg. 3
            // Testing small stream, few different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(smallStream, fewKeys, HashChaining.MultiplyShift);
            UInt64 squareSum1 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time1 = stopwatch.Elapsed;


            // Testing small stream, few different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(smallStream, fewKeys, HashChaining.MultiplyModPrime);
            UInt64 squareSum2 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time2 = stopwatch.Elapsed;
            
            // Testing small stream, many different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(smallStream, manyKeys, HashChaining.MultiplyShift);
            UInt64 squareSum3 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time3 = stopwatch.Elapsed;

            // Testing small stream, many different keys, and Multiply Mod prime
            stopwatch.Start();
            Sums.createHashTable(smallStream, manyKeys, HashChaining.MultiplyModPrime);
            UInt64 squareSum4 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time4 = stopwatch.Elapsed;

            // Testing big stream, few different keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(bigStream, fewKeys, HashChaining.MultiplyShift);
            UInt64 squareSum5 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time5 = stopwatch.Elapsed;

            // Testing big stream, few different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(bigStream, fewKeys, HashChaining.MultiplyModPrime);
            UInt64 squareSum6 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time6 = stopwatch.Elapsed;

            // Testing big stream, many diferent keys, and Multiply Shift
            stopwatch.Start();
            Sums.createHashTable(bigStream, manyKeys, HashChaining.MultiplyShift);
            UInt64 squareSum7 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time7 = stopwatch.Elapsed;

            // Testing big stream, many different keys, and Multiply Mod Prime
            stopwatch.Start();
            Sums.createHashTable(bigStream, manyKeys, HashChaining.MultiplyShift);
            UInt64 squareSum8 = Sums.squareSum();
            stopwatch.Stop();
            TimeSpan time8 = stopwatch.Elapsed;


            Console.WriteLine($"Small stream, few keys, multShift. S = {squareSum1}, Time = {time1} ");
            Console.WriteLine($"Small stream, few keys, multModPrime. S = {squareSum2}, Time = {time2} ");
            Console.WriteLine($"Small stream, many keys, multShift. S = {squareSum3}, Time = {time3} ");
            Console.WriteLine($"Small stream, many keys, multModPrime. S = {squareSum4}, Time = {time4} ");            
            Console.WriteLine($"Big stream, few keys, multShift. S = {squareSum5}, Time = {time5} ");
            Console.WriteLine($"Big stream, few keys, multModPrime. S = {squareSum6}, Time = {time6} ");            
            Console.WriteLine($"Big stream, many keys, multShift. S = {squareSum7}, Time = {time7} ");
            Console.WriteLine($"Big stream, many keys, multModPrime. S = {squareSum8}, Time = {time8} ");
            */

            stopwatch.Start();
            Sums.createHashTable(bigStream, manyKeys, HashChaining.MultiplyShift);
            UInt64 squareSum = Sums.squareSum();
            stopwatch.Stop();
            Console.WriteLine($"{squareSum}: {stopwatch.Elapsed}");

            int n = 1;
            UInt64[] experiments = new UInt64[n];
            for (int i = 0; i < n; i++) {
                BigInteger X = CountSketch.CountSketchAlgorithm(Sums.stream);
                //experiments[i] = X;
                Console.WriteLine(X);
            }

        }
    }
}
