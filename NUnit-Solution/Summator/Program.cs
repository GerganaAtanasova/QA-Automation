using System;

namespace Summator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int result = Summator.Sum(new int[] { 1, 2, 3 });
            Console.WriteLine(result);
        }
    }
}
