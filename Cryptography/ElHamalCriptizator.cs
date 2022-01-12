using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Criptology
{
    public class ElHamalCriptizator : ICriptyzator
    {

        public string Ecrypt(string text, object key)
        {
            BigInteger p = ((BigInteger[])key)[0];
            BigInteger g = ((BigInteger[])key)[1];
            BigInteger Y = ((BigInteger[])key)[3];
            BigInteger K;
            do
            {
                K = MathOpers.BigRandom(2, p - 1);
            }
            while (BigInteger.GreatestCommonDivisor(K, p - 1) != 1);

            return BigInteger.ModPow(g, K, p).ToString() + " " + ((BigInteger.ModPow(Y, K, p) * (BigInteger.Parse(text))) % p).ToString();

        }

        public string Dcrypt(string text, object key)
        {

            BigInteger p = ((BigInteger[])key)[0];
            BigInteger X = ((BigInteger[])key)[1];
            BigInteger a = BigInteger.Parse(text.Split(' ')[0]);
            BigInteger b = BigInteger.Parse(text.Split(' ')[1]);
            return ((BigInteger.ModPow(a, p - X - 1, p) * (b)) % p).ToString();
        }


        public string Replace(string text, string str1, string str2)
        {
            throw new NotImplementedException();
        }


        
    }
}
