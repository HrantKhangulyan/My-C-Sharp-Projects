using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Sedan : Car
    {

        public Sedan(string mark, string model, double price, double maxfuel, double maxspeed) : base( mark,  model,  price,  maxfuel,  maxspeed)
        {           
            this.numberofseats = 4;           
        }

        public static void VievCharacteristics(Sedan c)
        {
            Console.WriteLine($"Mark - {c.mark} , Model - {c.model}  , Maxfuel - {c.maxfuel} , Maxspeed - {c.maxspeed} , Price - {c.price}");
        }
    }
}
