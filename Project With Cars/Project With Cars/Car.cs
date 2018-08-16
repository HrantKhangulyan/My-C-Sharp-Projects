using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Car
    {

        protected string mark;
        protected string model;
        public double price;
        protected double fuel;
        protected int numberofseats;
        protected double maxfuel;
        protected double carspeed;
        protected double maxspeed;
        protected double currentspeed;

        public Car() { }
        
      
        public Car(string mark,  string model, double price, double fuel, double carspeed)
        {
            this.maxspeed = 300;
            this.maxfuel = 100;
            Fuel = fuel;
            CarSpeed = carspeed;
            this.mark = mark;
            this.price = price;
            this.model = model;
            this.numberofseats = 4;
            this.currentspeed = 0;
        }

        public double Fuel
        {
            get
            {
                return fuel;
            }

            set
            {
                if( value >= maxfuel)
                {
                    fuel = maxfuel;
                    return;
                }
                fuel = value;
            }
        }

        public double CarSpeed
        {
            get
            {
                return carspeed;
            }
            set
            {
                if(value > maxspeed)
                {
                    carspeed = maxspeed;
                    return;
                }
                else
                {
                    carspeed = value;
                }
            }
        }

        

        public void Go(double DistanceInKilometers)
        {
            int acceleration = 20;

            for (int i = 0; i < DistanceInKilometers; i++)
            {
                if (fuel <= 0)
                {
                    Console.WriteLine("Your fuel os over ! ");
                    Console.WriteLine($"You actually passed {i} Kilometers.");
                    return;
                }

                if (currentspeed + acceleration >= maxspeed)
                {
                    currentspeed = maxspeed;
                }

                currentspeed += acceleration;
                fuel -= currentspeed / 20;
            }
            Console.WriteLine($"You passed {DistanceInKilometers} Kilometers. Remaining fuel is {fuel} ");
            currentspeed = 0;
        }

        public void AddFuel(double AmountOfFuel)
        {
            if( fuel + AmountOfFuel <= maxfuel)
            {
                fuel += AmountOfFuel;
            }

            else
            {
                Console.WriteLine($"Your max fuel capacity is {maxfuel} , you can add maximum {maxfuel - fuel}");
                fuel = maxfuel;
            }
        }

    }
}
