using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retele_Token_Ring
{
    public class Computer
    {
        private static Random r = new Random();
        public string IpAddress { get; set; }
        public string Buffer { get; set; }

        public Computer()
        {
            IpAddress = "";
            Buffer = "(null)";

            byte tempVal = (byte)r.Next(0, 256);                 // First
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Second
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Third
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Fourth
            IpAddress = IpAddress + tempVal.ToString();         // Number

           
        }

        public void GenerateNewIp()
        {
            IpAddress = "";
            byte tempVal = (byte)r.Next(0, 256);                 // First
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Second
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Third
            IpAddress = IpAddress + tempVal.ToString() + ".";   // Number

            tempVal = (byte)r.Next(0, 256);                      // Fourth
            IpAddress = IpAddress + tempVal.ToString();         // Number
        }

        public override string ToString()
        {
            return $"({IpAddress}) -> {Buffer}";
        }

        ~Computer()
        {
            IpAddress = null;
            Buffer = null;
        }
    }
}
