using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            CarShop shop = new CarShop();
            shop.Creator();
            shop.Interface();            
            Console.ReadLine();
        }
    }
}
