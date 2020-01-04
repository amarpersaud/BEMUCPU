using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEMUCPU
{
    /// <summary>
    /// Representation of the SN74AHCT374 
    /// Octal Edge-Triggered D-Type Flip Flops used
    /// as registers in the CPU.
    /// 
    /// Positive edge triggered.
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Underlying values.
        /// </summary>
        private bool[] Values;

        /// <summary>
        /// Name of the Register. Not necessary, just useful for
        /// keeping track of things.
        /// </summary>
        public string Name;

        /// <summary>
        /// Output enabled.
        /// </summary>
        public bool OutputEnable
        {
            get;
            set;
        }

        /// <summary>
        /// Reference to the Bus.
        /// </summary>
        public Bus BUS;


        /// <summary>
        /// Create a register with [size] bits called [name]
        /// </summary>
        /// <param name="size">Number of bits</param>
        /// <param name="Name">Name of the register</param>
        public Register(int size, string Name)
        {
            Values = new bool[size];
            this.Name = Name;

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
        /// Reset the register. This is private/for debug use because
        /// the octal D-Flip flops used don't have a reset pin; just 
        /// power, ground, 8 inputs, 8 outputs, clock, and output enable
        /// </summary>
        private void Reset()
        {
            for(int i = 0; i < Values.Length; i++)
            {
                Values[i] = false;
            }
        }
    }
}
