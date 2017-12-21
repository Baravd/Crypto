using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n, B;
            Console.WriteLine("n=");
            n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine("B=");
            B = BigInteger.Parse(Console.ReadLine());

            //generate random between [2 and n) 


            BigInteger a = BigInteger.Parse("2");

            List<BigInteger> predefinedNumbers = new List<BigInteger>();

/*

            predefinedNumbers.Add(BigInteger.Parse("4204458777"));
            predefinedNumbers.Add(BigInteger.Parse("8921796065"));
            predefinedNumbers.Add(BigInteger.Parse("1241143"));
            predefinedNumbers.Add(BigInteger.Parse("6057318955"));
            predefinedNumbers.Add(BigInteger.Parse("1281936157"));
            predefinedNumbers.Add(BigInteger.Parse("8733973167"));
            predefinedNumbers.Add(BigInteger.Parse("1033554461"));
            predefinedNumbers.Add(BigInteger.Parse("7986611107"));
            predefinedNumbers.Add(BigInteger.Parse("7460145079"));
            predefinedNumbers.Add(BigInteger.Parse("9218338053"));
            predefinedNumbers.Add(BigInteger.Parse("1275948761"));
*/

            var watch = System.Diagnostics.Stopwatch.StartNew();
            //B = 13;

            foreach (var predefinedNumber in predefinedNumbers)
            {
                computeClassicalFactorization(predefinedNumber);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            watch2.Start();
            BigInteger k = lcmForList(generateBoundList(B));
            Console.WriteLine("!!!!!k=" + k);
            foreach (var predefinedNumber in predefinedNumbers)
            {
                computePollardP1(a, k, predefinedNumber, B);
                a = BigInteger.Parse("2");
            }
            watch2.Stop();
            //var elapsedMs2 = watch.ElapsedMilliseconds;
            var elapsedMs2 = watch2.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            Console.WriteLine("Time For classic=" + elapsedMs * 10000);
            Console.WriteLine("Time For Pollar p-1=" + elapsedMs2 * 10000);


            BigInteger b = BigInteger.Parse("2");
            Console.WriteLine("-----Read numbers-----");
            computePollardP1(b, k, n, B);
            Console.ReadLine();
        }

        private static void computeClassicalFactorization(BigInteger value)
        {
            BigInteger aux = BigInteger.Parse("2");
            for (BigInteger i = 0; i < value; i++)
            {
                if (value % aux == 0)
                {
                    Console.WriteLine("Divissor=" + aux);
                    return;
                }
                aux = aux + 1;
            }
        }

        private static bool isPrime(BigInteger x)
        {
            for (BigInteger i = 2; i < x / 2; i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }

        private static void computePollardP1(BigInteger a, BigInteger k, BigInteger n, BigInteger bound)
        {
            BigInteger aux = 2;
            while (aux < bound)
            {
                //a = BigInteger.Pow(aux, k) % n;
                a = BigInteger.ModPow(aux, k, n);
                BigInteger d = gcdNrMari(a - 1, n);
                if (d == 1 || d == n)
                {
                    //a = BigInteger.Add(aux,BigInteger.Parse("1"));
                    aux++;
                    Console.WriteLine("Failure we try with a=" + a.ToString());
                }
                else
                {
                    Console.WriteLine("D=" + d.ToString());
                    //Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("Please Run again with another Bound");
            //Console.ReadLine();
        }

        private static List<BigInteger> generateBoundList(BigInteger bound)
        {
            List<BigInteger> integers = new List<BigInteger>();
            for (BigInteger i = 1; i <= bound; i++)
            {
                integers.Add(i);
            }
            return integers;
        }

        public static BigInteger gcdNrMari(BigInteger a, BigInteger b)
        {
            BigInteger temp = 0;
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public static BigInteger cmmmc(BigInteger a, BigInteger b)
        {
            //return a * b / gcdNrMari(a, b);
            return a * b / BigInteger.GreatestCommonDivisor(a, b);
        }

        private static BigInteger lcmForList(List<BigInteger> values)
        {
            BigInteger aux = values[0];
            BigInteger lcm = aux;
            values.RemoveAt(0);
            while (values.Count > 0)
            {
                aux = values[0];
                lcm = cmmmc(lcm, aux);
                values.RemoveAt(0);
            }
            return lcm;
        }
    }
}