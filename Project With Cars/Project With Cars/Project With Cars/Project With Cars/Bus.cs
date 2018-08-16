using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Bus : Car
    {
        private readonly int maxnumberofseats;

        public Bus(string mark,  string model, double price, int numberofseats, double maxfuel, double maxspeed):base(mark,  model, price, maxfuel, maxspeed)
        {
            this.NumberOfSeats = numberofseats;
            this.maxnumberofseats = 20;
            maxspeed = 100;
        }

        public int NumberOfSeats
        {
            get
            {
                return numberofseats;
            }
            set
            {
                if( value >= maxnumberofseats)
                {
                    numberofseats = maxnumberofseats;
                }
                numberofseats = value;
            }
        }

        public static void VievCharacteristics(Bus c)
        {
            Console.WriteLine($"Mark - {c.mark} , Model - {c.model} , Number of seats - {c.numberofseats}  , Maxfuel - {c.maxfuel} , Maxspeed - {c.maxspeed} , Price - {c.price} ");
        }
    }
}
