using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        public static int GcdEuclid(int a, int b)
        {
            if (a == 1 || b == 1)
            {
                return 1;
            }
            int temp = 0;
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

        public static int EuclidTotient(int n)
        {
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (GcdEuclid(i, n) == 1)
                {
                    result++;
                }
            }

            return result;

        }
        static void Main(string[] args)
        {
            int value, bound;
            Console.Write("Value=");
            value = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bound=");
            bound = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < bound; i++)
            {
                if (EuclidTotient(i) == value)
                {
                    Console.WriteLine(i);
                    
                }
            }
            Console.WriteLine(EuclidTotient(100));
            Console.ReadLine();
        }
    }
}
