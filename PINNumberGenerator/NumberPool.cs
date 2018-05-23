using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  @author Namyoon Kim    j4yn3rd@gmail.com
 * 
 *  This class sorts out list of given numbers from the range of min to max.
 *  Numbers will be sorted based on the rules mention in the main class of the
 *  application.
 *  
 **/

namespace PINNumberGenerator
{
    public class NumberPool
    {
        private int min;
        private int max;
        private const int DIGITS = 4;

        // Setting min and max range of the number list.
        public NumberPool(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        // Returns every single whole numbers between the given range.
        // To make the PIN to have leading zeros, every numbers will be
        // converted to a 4 digits string.
        public List<String> GetRawNumberPool()
        {
            string number = null;
            List<String> numberList = new List<String>();

            // Add every single numbers in the form of 4 digits strings.
            for (int i = min; i <= max; i++)
            {
                number = i.ToString().PadLeft(DIGITS, '0');
                numberList.Add(number);
            }
            return numberList;
        }

        // Sorting out the list of whole numbers from min to max.
        public List<String> GetSortedNumberPool(List<String> numberList)
        {
            bool isRepeated = false;
            bool isIncreasing = false;
            List<String> sortedNumberList = new List<String>();
            for (int i = 0; i < numberList.Count; i++)
            {
                // Every 4 digits long PIN number candidates from the given
                // list with repeated identical characters will not be included.
                isRepeated = CheckRepeatedDigits(numberList[i]);
                if (!isRepeated)
                {
                    // Every 4 digits long PIN number candidates from the given
                    // list with consecutively increasing characters (three or more)
                    // will not be included to the final version of the number list.
                    isIncreasing = CheckIncreasingDigits(numberList[i]);
                    if (!isIncreasing)
                    {
                        sortedNumberList.Add(numberList[i]);
                    }
                }
            }
            return sortedNumberList;
        }

        private Boolean CheckRepeatedDigits(String number)
        {
            // If repeated, stops further process and returns true.
            bool flag = false;
            char prevDigit = number[0];

            // Checking every digits.
            for (int i = 1; i < number.Length; i++)
            {
                char curDigit = number[i];
                if (prevDigit == curDigit)
                {
                    flag = true;
                    return flag;
                }
                prevDigit = curDigit;
            }
            return flag;
        }

        private Boolean CheckIncreasingDigits(String number)
        {
            // If consecutively increasing, further process will be
            // interrupted and true flag will be returned.
            bool flag = false;
            char prevDigit = number[0];
            for (int i = 1; i < number.Length; i++)
            {
                // Checking every digits until it reaches just before the last
                // digit of the string.
                if (i != number.Length - 1)
                {
                    char curDigit = number[i];
                    char nextDigit = number[i + 1];
                    if (curDigit - prevDigit == 1 && nextDigit - curDigit == 1)
                    {
                        flag = true;
                        return flag;
                    }
                    prevDigit = curDigit;
                }
            }
            return flag;
        }
    }
}
