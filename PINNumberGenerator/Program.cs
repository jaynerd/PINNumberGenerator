using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  @author Namyoon Kim    j4yn3rd@gmail.com
 * 
 *  This console application basically generates a unique batch of PINs (size of 1000).
 *  Each PIN number is created by following few simple rules.
 *  #1 A leading zero PIN should be available.
 *  #2 No two or more identical numbers should appear consecutively.
 *  #3 No three or more increasing numbers like 123 should be appeared consecutively.
 *  
 **/

namespace PINNumberGenerator
{
    class Program
    {
        // Main thread starts here.
        static void Main(string[] args)
        {
            // Making a number pool starting from 0000, to 9999.
            NumberPool numberPool = new NumberPool(0, 9999);

            // Getting a whole raw number list.
            List<String> numbers = numberPool.GetRawNumberPool();

            // Start the sorting process following pre-defined rules.
            // List of numbers returned from GetSortedNumberPool will exclude any
            // unnecessary numbers from the given raw list.
            numbers = numberPool.GetSortedNumberPool(numbers);

            // Instantiating a pin generator with sorted list of numbers.
            List<String> pinBatch = new List<String>();
            PINGenerator pinGenerator = new PINGenerator(numbers);

            // Asking for inputs to generate the batch or exit the application.
            while (true)
            {
                Console.WriteLine("Press 'N' to create a new PIN batch. 'X' to exit.");
                String input = Console.ReadLine();
                int counter = 0;

                // If the right input "N" is received.
                if (String.Compare(input, "n", true) == 0)
                {
                    Console.WriteLine("Getting a new batch of unique PINs.");

                    // Getting a new batch of PINs.
                    pinBatch = pinGenerator.GetNewBatch();
                    for (int i = 0; i < pinBatch.Count; i++)
                    {
                        Console.Write(pinBatch[i] + "    ");
                        if (counter % 5 == 0)
                        {
                            Console.WriteLine("");
                        }
                        counter++;
                    }
                }
                else if (String.Compare(input, "x", true) == 0)
                {
                    // Exiting the console when user presses "X".
                    Environment.Exit(0);
                }

                Console.WriteLine("");
                Console.WriteLine("End of the process.");
            }
        }
    }
}
