using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_With_Cars
{
    class CarShop
    {
        private static int sedanquantity;
        private static int truckquantity;
        private static int busquantity;
        User user;
        
        public CarShop()
        {
            sedanquantity = 0;
            busquantity = 0;
            truckquantity = 0;
        }

        Sedan[] sedans;
        Truck[] trucks;
        Bus[] buses;

        public void Creator()
        {
            Sedan BMW = new Sedan("BMW", "335i", 10000, 30, 220);                     sedanquantity++;
            Sedan Marsedes = new Sedan("Mersedes Benz", "Yeshka", 7000, 35, 220);     sedanquantity++;
            Sedan Porsche = new Sedan("Porsche", "Cayenne", 25000, 120, 260);         sedanquantity++;
            Bus Pazik = new Bus("Pazik", "Sovetakan", 20000, 70, 150, 80);         busquantity++;
            Bus Bogdan = new Bus("Bogdan", "12b", 15000, 14, 130, 90);                busquantity++;
            Bus hamar14 = new Bus("14Number", "Public", 22000, 15, 123, 123);        busquantity++;
            Truck Zil = new Truck("Zil", 7000, "12ooe", 200, 70, 4000);               truckquantity++;
            Truck Kamaz = new Truck("Kamaz", 15000, "Gazaraguyn", 175, 100, 5000);    truckquantity++;
            Truck Zibil = new Truck("Zibili avto", 21000, "hotac", 123, 80, 2800);    truckquantity++;

            sedans = new Sedan[sedanquantity];
            trucks = new Truck[truckquantity];
            buses = new Bus[busquantity];

            sedans[0] = BMW;
            sedans[1] = Marsedes;
            sedans[2] = Porsche;
            buses[0] = Pazik;
            buses[1] = Bogdan;
            buses[2] = hamar14;
            trucks[0] = Zil;
            trucks[1] = Kamaz;
            trucks[2] = Zibil; 
        }

        string answer = "";

        public void ViewStuffAndBuy()
        {
            if (sedanquantity == 0 && busquantity == 0 && truckquantity == 0)
            {
                Console.WriteLine($"Ho du annasun ches {user.name} ? ");
            }
            int buynumber = -1;
            while (user.money >= 0 && (sedanquantity != 0 || busquantity != 0 || truckquantity != 0))
            {
                Console.WriteLine("Type 1 to view Sedans , 2 to viev Trucks , 3 to viev Buses");
                buynumber = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (buynumber)
                {
                    case (1):
                        {
                           
                        if (sedanquantity != 0)
                        {
                                for (int i = 0; i < sedans.Length; i++)
                                {
                                    if (sedans[i] != null)
                                    {
                                            Console.Write($"Sedan {i + 1}: ");
                                            Sedan.VievCharacteristics(sedans[i]);
                                    }
                                }

                                Console.WriteLine("Which sedan would you like to buy ? (enter sedan number)");
                                int num = int.Parse(Console.ReadLine());
                                if (sedans[num - 1] != null)
                                {
                                    user.Buys(sedans[num - 1]);
                                    sedans[num - 1] = null;
                                    sedanquantity--;
                                }
                                else
                                {
                                    Console.WriteLine($"Its already bought , {user.name}");
                                }
                        }
                            
                            else
                            {
                                Console.WriteLine("Our sedans are over :( ");
                                AskIfUserWants();
                            }

                            break;
                        }
                    case (2):
                        {
                            if (truckquantity != 0)
                            {
                                for (int i = 0; i < trucks.Length; i++)
                                {
                                  if (trucks[i] != null)
                                  {
                                    Console.Write($"Truck {i + 1}: ");
                                    Truck.VievCharacteristics(trucks[i]);
                                  }
                                }
                            
                                Console.WriteLine("Which truck would you like to buy ? (enter truck number)");
                                int num = int.Parse(Console.ReadLine());
                                if (trucks[num - 1] != null)
                                {
                                    user.Buys(trucks[num - 1]);
                                    trucks[num - 1] = null;
                                    truckquantity--;
                                }
                                else
                                {
                                    Console.WriteLine($"It's already bought , {user.name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Our Trucks are over :( ");
                                AskIfUserWants();
                            }
                            break;
                        }
                    case (3):
                        {
                            if (busquantity != 0)
                            {
                                for (int i = 0; i < buses.Length; i++)
                                {
                                  if (buses[i] != null)
                                  {
                                    Console.Write($"Bus {i + 1}: ");
                                    Bus.VievCharacteristics(buses[i]);
                                  }
                                }
                           
                                Console.WriteLine("Which bus would you like to buy ? (enter bus number)");
                                int num = int.Parse(Console.ReadLine());
                                if (buses[num - 1] != null)
                                {
                                    user.Buys(buses[num - 1]);
                                    buses[num - 1] = null;
                                    busquantity--;
                                }
                                else
                                {
                                    Console.WriteLine($"It's already bought , {user.name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Our buses are over :(");
                                AskIfUserWants();
                            }
                            break;
                        }
                }

               

                if (user.money >= 0 || answer != "no" )
                {
                    AskIfUserWants();
                }
                
            }
            
        }
        void AskIfUserWants()
        {
            
            Console.WriteLine("Would you like to buy another vehicle ? (Type 'yes' or 'no')");
            answer = Console.ReadLine();
            Console.Clear();

            switch (answer)
            {
                case ("yes"):
                    {
                        ViewStuffAndBuy();
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"Well , Thank You {user.name} , see you later !");
                        user.money = -1;
                        break;                        
                    }
            }
        }



        public  void Interface()
        {
            Console.WriteLine("Enter Your name , and the amount of money you have !");
            string name = Console.ReadLine();
            double money = int.Parse(Console.ReadLine());
            user = new User(name, money);

            
            Console.Clear();
            Console.WriteLine($"Welcome To Our Shop {user.name}");
            Console.WriteLine("We Have Sedans , Trucks and Buses !");

            ViewStuffAndBuy();          
        }
    }
}
