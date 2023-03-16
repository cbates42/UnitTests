//found algorithm for finding if num is prime here: https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
//found divisors algorithm here: https://codereview.stackexchange.com/questions/237416/c-code-to-find-all-divisors-of-an-integer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UnitTests
{
    public class Utilities
    {

        public double FloorNum(double num)
        {
            return Math.Floor(num);
        }

        public string JoinString(string str1, string str2)
        {
            return $"{str1}, {str2}";
        }

        public string Hash(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool isPrime(int num)
        {
            if (num < 2)
            {
                return false;
            }
            for (int n = 2; n <= Math.Sqrt(num); n++)
            {
                if (num % n == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> GetNonPrimeDivisors(int num)
        {
            List<int> divisors = new List<int>();
            for(int n = 2; n <= num / 2; n++)
            {
                if(num % n == 0 && !isPrime(n))
                {
                    divisors.Add(n);
                }
            }
            return divisors;
        }

        
        
       public int Divide(int num1, int num2)
        {
            int bignum = Math.Max(num1, num2);
            int smallnum = Math.Min(num1, num2);
            return (int)Math.Floor((double)bignum / smallnum);
        }

        public Dictionary<int, int> GetNonPrimeDivisorsOrdered(int num)
        {
            Dictionary<int, int> divisors = new Dictionary<int, int>();
            for(int n = 1; n <= num / 2; n += 2)
            {
                if(num % n == 0 && !isPrime(n))
                {
                    divisors.Add(n, n);
                }
            }
            return divisors;
        }



    }
}
