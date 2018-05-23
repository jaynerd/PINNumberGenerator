using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  @author Namyoon Kim    j4yn3rd@gmail.com
 * 
 *  This class generates a batch consisting unique number of PINs without
 *  those numbers not following the given conditions.
 *  Base sorted number of list will not be manipulated after its initial
 *  declaration. Only the copy of the original sorted numbers list will be
 *  manupulated to keep the uniqueness of each PIN numbers.
 *  
 **/

namespace PINNumberGenerator
{
    public class PINGenerator
    {
        private List<String> pins;
        private const int BATCH_SIZE = 1000;

        // Setting the fundametal list of sorted numbers.
        public PINGenerator(List<String> pins)
        {
            this.pins = pins;
        }

        // Instantiating a new batch of PINs from the pre-sorted list of
        // possible numbers. Therfore, random function will choose a value
        // between its upper limit, the total length of possible numbers.
        // After making a choice, the chosen number will be excluded from
        // the temp sorted list to avoid any duplicates in the batch.
        public List<String> GetNewBatch()
        {
            var pinList = new List<String>(pins);
            var pinBatch = new List<String>();
            Random rand = new Random();
            for (int i = 0; i < BATCH_SIZE; i++)
            {
                int index = rand.Next(0, pinList.Count);
                String targetPin = pinList[index];
                pinBatch.Add(targetPin);
                pinList.Remove(targetPin);
            }
            return pinBatch;
        }
    }
}
