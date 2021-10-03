using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMI_APR3.Model
{
    class Sheet
    {
        public int Number { get; set; }
        public double Lenght { get; set; }
        public double Offset { get; set; }
        public double Position { get; set; }

        public Sheet() { }

        public Sheet(int number, double lenght, double offset, double position)
        {
            Number = number;
            Lenght = lenght;
            Offset = offset;
            Position = position;
        }
    }
}
