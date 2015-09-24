using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DivisibleFunction_Level2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Check your number to see if it is divisible by 9");
            //Console.ReadLine();
            //Console.WriteLine("Please enter your number?");
            //var number = 0;
            //int.TryParse(Console.ReadLine(), out number);

            //Stopwatch bitShift_time = new Stopwatch();
            //Stopwatch whileLoop_time = new Stopwatch();
            //bitShift_time.Start();
            //bool isDivisibleBy9 = isDivby9(number);
            //bitShift_time.Stop();
            //whileLoop_time.Start();
            //bool isDivisible = isDivisibleBy(number, 9);
            //whileLoop_time.Stop();

            //if (isDivisibleBy9)
            //{
            //    Console.WriteLine("Your number is divisible by 9");
            //}
            //else
            //{
            //    Console.WriteLine("Your number is not divisible by 9");
            //}
            //Console.WriteLine("Elapsed time of Bit Shift: {0}", bitShift_time.Elapsed);
            //Console.WriteLine("Elapsed time of While Loop: {0}", whileLoop_time.Elapsed);
            //Console.ReadLine();

            Console.WriteLine("Testing two methods of checking divisibility on numbers 1 through 1000000, press any key to start");
            Console.ReadLine();
            TimeSpan whileloopAverageTime = runTimingTests_WhileLoop(9, 1000000);
            TimeSpan bitShiftAverageTime = runTimingTest_BitShift(1000000);
            Console.WriteLine("The While Loop took: {0}", whileloopAverageTime);
            Console.WriteLine("The Bit Shift Method took: {0}", bitShiftAverageTime);
            Console.ReadLine();
        }



        public static TimeSpan runTimingTests_WhileLoop(int divisor, int numberOfTests)
        {
            Stopwatch whileLoop_time = new Stopwatch();
            List<TimeSpan> test_times = new List<TimeSpan>();
            
            for (var i = 0; i < numberOfTests; i++)
            {
                whileLoop_time.Start();
                bool isDivisible = isDivisibleBy(i, divisor);
                whileLoop_time.Stop();
                test_times.Add(whileLoop_time.Elapsed);
                whileLoop_time.Reset();
            }
            TimeSpan total = new TimeSpan(Convert.ToInt64(test_times.Sum(i => i.Milliseconds)));
            return total;
        }

        public static TimeSpan runTimingTest_BitShift(int numberOfTests)
        {
            //automatically tests with 9 as the divisor
            Stopwatch bitShift_time = new Stopwatch();
            List<TimeSpan> test_times = new List<TimeSpan>();
            for (var i = 0; i < numberOfTests; i++)
            {
                bitShift_time.Start();
                bool isDivisible = isDivby9(i);
                bitShift_time.Stop();
                test_times.Add(bitShift_time.Elapsed);
                bitShift_time.Reset();
            }
            //TimeSpan timeAverage = TimeSpan.FromTicks(Convert.ToInt64(test_times.Average(i => i.TotalMilliseconds)));
            //return timeAverage;
            TimeSpan total = new TimeSpan(Convert.ToInt64(test_times.Sum(i => i.Milliseconds)));
            return total;
        }
    
        
        public static bool isDivisibleBy(int number, int divisor)
        {
            if (number < 9) 
            { 
                return false; 
            }
            int i = 0;
            while (i < number)
            {
                i += divisor;
            }
            return i == number;
        }

        public static bool isDivby9(int x)
        {
            if (x < 9)
            {
                return false;
            }
            int divby8;

            if (x >= 9)
            {
                divby8 = x >> 3;
                while (divby8 >= 9)
                {
                    divby8 = divby8 - 9;
                }
                return divby8 == (x - ((x >> 3) << 3));
            }
            return false;
        }

        //public static bool isDivisibleBy(int number, int divisor)
        //{
        //    for (int i = 0; i <= number; i += divisor)
        //    {
        //        if (i == number)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


        /// <summary>
        /// Original C code taken from CodeReview Question
        /// http://codereview.stackexchange.com/questions/85163/checking-if-a-number-is-divisible-by-9
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool isDivby9_OP(int x)
        {
            var status = false;
            int divby8 = 0;

            int orgx = x;
            if (x >= 9)
            {
                divby8 = x >> 3;
                int olddivby8 = divby8;
                while (divby8 >= 9)
                {
                    divby8 = divby8 - 9;
                }
                if (divby8 == (orgx - (olddivby8 << 3)))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                x = divby8;
            }

            return status;
        }

    }
}
