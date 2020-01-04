using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEMUCPU
{
    public class BInt
    {        
        /// <summary>
        /// Underlying values.
        /// </summary>
        private bool[] Values;

        /// <summary>
        /// Create BInt
        /// </summary>
        /// <param name="size"></param>
        public BInt(int size)
        {
            Values = new bool[size];
        }

        /// <summary>
        /// Size of the register in bits
        /// </summary>
        public int Size
        {
            get { return Values.Length; }
        }

        /// <summary>
        /// Get/set the bit at [index]
        /// </summary>
        /// <param name="index">Bit to get/set</param>
        /// <returns>Bit at [index]</returns>
        public bool this[int index]
        {
            get
            {
                return Values[index];
            }
            set
            {
                Values[index] = value;
            }
        }

        /// <summary>
        /// Reset the values This is unused on registers because
        /// the octal D-Flip flops used don't have a reset pin; just 
        /// power, ground, 8 inputs, 8 outputs, clock, and output enable
        /// </summary>
        private void Reset()
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = false;
            }
        }
    }
}
