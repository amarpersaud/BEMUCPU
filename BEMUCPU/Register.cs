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
    public class Register : BInt
    {
        /// <summary>
        /// Name of the Register. Not necessary, just useful for
        /// keeping track of things.
        /// </summary>
        public string Name;

        /// <summary>
        /// Output enabled
        /// </summary>
        private bool _oe;

        /// <summary>
        /// Output enabled.
        /// </summary>
        public bool OutputEnable
        {
            set
            {
                _oe = value;
                BUS = (Bus)(BUS | this); //Bitwise ORs the bus and the register's value.
                //TODO : Decide how to reset the Bus after output has been disabled without
                //interfering with other things that may be outputting to the bus
                //simultaneously.
            }
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
        public Register(int size, string Name) : base(size)
        {
            this.Name = Name;
        }
       
    }
}
