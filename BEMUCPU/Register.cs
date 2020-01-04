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
    /// </summary>
    public class Register
    {
        private int[] Values;
        public string Name;

        public bool WriteEnable;

        public Bus BUS;


        public Register(int size, string Name)
        {
            Values = new int[size];
            this.Name = Name;

        }

        public int Size
        {
            get { return Values.Length; }
        }
        public int this[int index]
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
                Values[i] = 0;
            }
        }
    }
}
