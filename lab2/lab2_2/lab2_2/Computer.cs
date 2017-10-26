using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace lab2_2
{
    class Computer
    {

        public int gcdScaderi(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;

        }
        public int gcdEuclid(int a, int b)
        {
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
        public int gcdFor(int a, int b)
        {
            int d = 1;
            int aux;
            if (a > b)
                aux = a;
            else
            {
                aux = b;
            }
            for (int i = 1; i < Convert.ToInt32(Math.Sqrt(aux)); i++)
            {
                if (aux % i == 0)
                {
                    d = i;
                }
            }

            return d;
        }
        public BigInteger gcdNrMari(BigInteger a , BigInteger b)
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
    }
}
