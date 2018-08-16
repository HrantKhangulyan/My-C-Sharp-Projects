using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class User
    {
        public string name;
        public double money;
             
        public User(string name , double money)
        {
            this.name = name;
            this.money = money;
        }

        public void Buys(Car car)
        {
            if(car is Sedan)
            {
                if (car.price > money)
                {
                    Console.WriteLine("You have not enough money ! ");
                    return;
                }
                else
                {
                    Console.WriteLine("Congratulations , you successfully bought a car !");
                    money -= car.price;
                    Console.WriteLine($"Your money is {money}");
                }
            }

            if (car is Truck)
            {
                if (car.price > money)
                {
                    Console.WriteLine("You have not enough money ! ");
                    return;
                }
                else
                {
                    Console.WriteLine("Congratulations , you successfully bought a truck !");
                    money -= car.price;
                    Console.WriteLine($"Your money is {money}");
                }
            }

            if (car is Bus)
            {
                if (car.price > money)
                {
                    Console.WriteLine("You have not enough money ! ");
                    return;
                }
                else
                {
                    Console.WriteLine("Congratulations , you successfully bought a bus !");
                    money -= car.price;
                    Console.WriteLine($"Your money is {money}");
                }
            }
        }

    }
}
