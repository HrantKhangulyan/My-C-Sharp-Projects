using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Sedan : Car
    {

       

        public Sedan(string mark, string model, double price, double fuel, double carspeed) : base( mark,  model,  price,  fuel,  carspeed)
        {           
            this.numberofseats = 4;          
        }

        public static void VievCharacteristics(Sedan c)
        {
            Console.WriteLine($"Mark - {c.mark} , Model - {c.model}  , Maxfuel - {c.Fuel} , Maxspeed - {c.CarSpeed} , Price - {c.price}");
        }
    }
}
