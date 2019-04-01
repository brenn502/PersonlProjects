using System;
namespace DynamicProgramming
{
    static class Fibonacci
    {
        /// <summary>
        /// Bottom up approach to fibonacci
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ulong Calculate(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {     
                ulong first = 1;
                ulong second = 1;
                ulong temp;

                for (int count = 2; count < n; count++)
                {
                    temp = first + second;
                    first = second;
                    second = temp;
                }

                return second;
            }
        }
    }
}
