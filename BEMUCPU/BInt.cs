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

        #region Converters

        /// <summary>
        /// Convert to a UInt32
        /// </summary>
        /// <returns>UInt32 representation</returns>
        public uint ToUInt32()
        {
            uint res = 0;
            for (int i = 0; i < this.Size && i < 32; i++)
            {
                uint val = this[i] ? 1u : 0u;    //1 or 0 if bit is 1 or 0 / true or false
                res |= val << i;                 //Shift it by which bit it is.
            }
            return res;
        }

        /// <summary>
        /// Create a BInt from a uint32
        /// </summary>
        /// <param name="a">Number to create BInt from</param>
        /// <returns>BInt with bitpattern of given uint32</returns>
        public static BInt FromUInt32(uint a)
        {
            BInt res = new BInt(32);
            res.Reset();
            for (int i = 0; i < 32; i++)
            {
                //Shift integer over by i bits, and it with 0x0001,
                //If its equal to 1 then true, false otherwise from reset.
                res[i] = (((a >> i) & 1u) == 1u);
            }
            return res;
        }

        /// <summary>
        /// Create BInt from UInt32
        /// </summary>
        /// <param name="a">Number to create BInt from</param>
        /// <param name="size">Size of the BInt. Caps at 32</param>
        /// <returns>BInt not more than 32 bits with bitpattern of given uint32</returns>
        public static BInt FromUInt32(uint a, int size)
        {
            BInt res = new BInt(size);
            res.Reset();
            for (int i = 0; i < size && i < 32; i++)
            {
                //Shift integer over by i bits, and it with 0x0001,
                //If its equal to 1 then true, false otherwise from reset.
                res[i] = (((a >> i) & 1u) == 1u);
            }
            return res;
        }
        #endregion Converters

        #region Operators

        /// <summary>
        /// Bitwise And two BInts together
        /// </summary>
        /// <param name="a">First BInt</param>
        /// <param name="b">Second BInt</param>
        /// <returns>Bitwise And of two BInts</returns>
        public static BInt operator &(BInt a, BInt b)
        {

            BInt c = new BInt(a.Size);
            for(int i = 0; i < a.Size; i++)
            {
                c[i] = a[i] && b[i];
            }
            return c;
        }

        /// <summary>
        /// Bitwise And BInt and single bit.
        /// </summary>
        /// <param name="a">First BInt</param>
        /// <param name="b">Second BInt</param>
        /// <returns>Bitwise And</returns>
        public static BInt operator &(BInt a, bool b)
        {

            BInt c = new BInt(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                c[i] = a[i] && b;
            }
            return c;
        }

        /// <summary>
        /// Bitwise OR two BInts together
        /// </summary>
        /// <param name="a">First BInt</param>
        /// <param name="b">Second BInt</param>
        /// <returns>Bitwise OR of two BInts</returns>
        public static BInt operator |(BInt a, BInt b)
        {

            BInt c = new BInt(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                c[i] = a[i] || b[i];
            }
            return c;
        }

        /// <summary>
        /// Bitwise Or BInt and single bit.
        /// </summary>
        /// <param name="a">First BInt</param>
        /// <param name="b">Second BInt</param>
        /// <returns>Bitwise Or</returns>
        public static BInt operator |(BInt a, bool b)
        {

            BInt c = new BInt(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                c[i] = a[i] || b;
            }
            return c;
        }
        #endregion Operators
    }
}
