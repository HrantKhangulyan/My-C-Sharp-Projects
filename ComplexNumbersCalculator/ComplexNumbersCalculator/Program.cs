using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbersCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input format...For Example (a+bi)+(c+di) ");
                Console.WriteLine("Operations are '+' , '-' , '*' , '/' ");
                Console.WriteLine("After the result is given press Enter to run the program again");
                Console.WriteLine("If you want to finish the program please type 'exit' to finish");
                Console.WriteLine("************\n");
                int l = 1;
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    return;
                }
                string first = string.Empty;
                string second = string.Empty;
                string third = string.Empty;
                string fourth = string.Empty;
                char First_Complex_Number_Operation;
                char Second_Complex_Number_Operation;
                char realsign1 = 'P';
                char realsign2 = 'L';
                char Operation;

                if (input[l] == '-')
                {
                    realsign1 = input[l];
                    l++;
                }

                while (char.IsDigit(input[l]))
                {
                    first += input[l];
                    l++;
                }

                First_Complex_Number_Operation = input[l];
                l++;

                while (input[l] != 'i')
                {
                    second += input[l];
                    l++;
                }

                l += 2;
                Operation = input[l];
                l += 2;

                if (input[l] == '-')
                {
                    realsign2 = input[l];
                    l++;
                }

                while (char.IsDigit(input[l]))
                {
                    third += input[l];
                    l++;
                }


                Second_Complex_Number_Operation = input[l];
                l++;

                while (input[l] != 'i')
                {
                    fourth += input[l];
                    l++;
                }

                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);
                int c = Convert.ToInt32(third);
                int d = Convert.ToInt32(fourth);

                if (realsign1 == '-')
                {
                    a *= (-1);
                }
                if (realsign2 == '-')
                {
                    c *= (-1);
                }
                if (First_Complex_Number_Operation == '-')
                {
                    b *= (-1);
                }
                if (Second_Complex_Number_Operation == '-')
                {
                    d *= (-1);
                }

                double FinalReal = -1;
                double FinalComplex = -1;

                switch (Operation)
                {
                    case ('+'):
                        {
                            FinalReal = a + c;
                            FinalComplex = b + d;
                            break;
                        }

                    case ('-'):
                        {
                            FinalReal = a - c;
                            FinalComplex = b - d;
                            break;
                        }

                    case ('*'):
                        {
                            FinalReal = a * c - b * d;
                            FinalComplex = a * d + c * b;
                            break;
                        }
                    case ('/'):
                        {
                            FinalReal = (a * c + b * d);
                            FinalComplex = (b * c - a * d);
                            int T = (c * c + d * d);
                            Console.WriteLine("({0}/{1})+({2}/{3})i", FinalReal, T, FinalComplex, T);
                            break;
                        }
                }
                if (Operation != '/')
                {
                    if (FinalComplex >= 0)
                    {
                        Console.WriteLine("{0}+{1}i", FinalReal, FinalComplex);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}i", FinalReal, FinalComplex);
                    }
                }
                string enter = Console.ReadLine();
                if (enter == "exit")
                    return;
                Console.Clear();
            }
            
        }
    }
}