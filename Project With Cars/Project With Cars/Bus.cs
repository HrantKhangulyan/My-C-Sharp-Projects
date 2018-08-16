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

       

        public Bus(string mark,  string model, double price, int numberofseats, double fuel, double carspeed):base(mark,  model, price, fuel, carspeed)
        {
            this.maxfuel = 200;
            
            this.maxnumberofseats = 20;
            this.NumberOfSeats = numberofseats;          
            
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
                    return;
                }
                numberofseats = value;
            }
        }

        public static void VievCharacteristics(Bus c)
        {
            Console.WriteLine($"Mark - {c.mark} , Model - {c.model} , Number of seats - {c.NumberOfSeats}  , Maxfuel - {c.Fuel} , Maxspeed - {c.CarSpeed} , Price - {c.price} ");
        }
    }
}
