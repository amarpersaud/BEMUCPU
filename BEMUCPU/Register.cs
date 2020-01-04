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
