using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Criptology
{
    public class MathOpers
    {
        public static BigInteger gsd(BigInteger m, BigInteger n)
        {
            while (m != 0 && n != 0)
            {
                if (m >= n)
                    m %= n;
                else
                    n %= m;
            }
            return m + n;
        }

        public static BigInteger Jacobi(BigInteger a, BigInteger b)
        {
            if (gsd(a, b) != 1) return 0;
            else
            {
                long r = 1;
                if (a < 0)
                {
                    a = -a;
                    if (b % 4 == 3)
                        r = -r;
                }
                do
                {
                    BigInteger t = 0;
                    while (a % 2 == 0)
                    {
                        t += 1;
                        a /= 2;
                    }
                    if (t % 2 == 1 && (b % 8 == 3 || b % 8 == 5))
                        r = -r;
                    if (a % 4 == 3 && b % 4 == 3)
                        r = -r;
                    BigInteger c = a;
                    a = b % c;
                    b = c;
                }
                while (a != 0);
                return r;
            }
        }

        public static BigInteger BigRandom(BigInteger min, BigInteger max)
        {
            BigInteger byten = (max - min);
            byte[] bytes = byten.ToByteArray();
            Thread.Sleep(50);
            Random rand = new Random();

            rand.NextBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F;


            return (new BigInteger(bytes) % byten) + min;
        }

        public static bool IsProbable(BigInteger numb, int k)
        {
            for (int i = 0; i < k; i++)
            {
                BigInteger a = BigRandom(2, numb);
                BigInteger temp1 = BigInteger.ModPow(a, (numb - 1) / 2, numb);
                BigInteger temp2 = (numb + Jacobi(a, numb)) % numb;

                if ((gsd(a, numb) > 1) || (temp1 != temp2))
                {
                    return false;
                }

            }
            return true;
        }
    }
}
