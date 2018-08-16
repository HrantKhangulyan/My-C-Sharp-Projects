using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Truck : Car
    {
        private readonly double maxcapacity;
        private double capacity;

        public Truck(string mark, double price, string model, double maxfuel, double maxspeed , double maxcapacity) : base(mark,  model, price, maxfuel, maxspeed)
        {
            maxspeed = 70;
            this.maxcapacity = 300;
            this.MaxCapacity = maxcapacity;
        }

        public double MaxCapacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if(value > maxcapacity)
                {
                    capacity = maxcapacity;
                }
                capacity = value;
            }
        }

        public static void VievCharacteristics(Truck c)
        {
            Console.WriteLine($"Mark - {c.mark} , Model - {c.model}  , Maxfuel - {c.maxfuel} , Maxspeed - {c.maxspeed} , Maxcapacity - {c.maxcapacity} Price - {c.price}");
        }
    }
}
