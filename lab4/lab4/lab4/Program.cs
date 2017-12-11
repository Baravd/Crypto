using System;
using System.Collections.Generic;
using System.Linq;
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

            int k = (int) lcmForList(generateBoundList(B));
            Console.WriteLine(k);
            List<BigInteger> predefinedNumbers= new List<BigInteger>();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            predefinedNumbers.Add(BigInteger.Parse("10001000002"));
            predefinedNumbers.Add(BigInteger.Parse("10001000004"));
            predefinedNumbers.Add(BigInteger.Parse("10001000006"));
            predefinedNumbers.Add(BigInteger.Parse("10001000008"));
            predefinedNumbers.Add(BigInteger.Parse("10001000010"));
            predefinedNumbers.Add(BigInteger.Parse("10001000030"));
            predefinedNumbers.Add(BigInteger.Parse("10001000045"));
            predefinedNumbers.Add(BigInteger.Parse("10001000096"));
            predefinedNumbers.Add(BigInteger.Parse("10001000034"));
            predefinedNumbers.Add(BigInteger.Parse("10001003245234"));
            watch.Stop();
            foreach (var predefinedNumber in predefinedNumbers)
            {
                //computePollardP1();
            }
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time="+elapsedMs);

            computePollardP1(a, k, n, B);
        }

        private static void computePollardP1(BigInteger a, int k, BigInteger n, BigInteger bound)
        {
            int aux = 2;
            while (aux < bound)
            {
                a = BigInteger.Pow(aux, k) % n;
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
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("Please Run again with another Bound");
            Console.ReadLine();
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
            return a * b / gcdNrMari(a, b);
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