using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Server
{
    class Program
    {
        public  static string Calc(string a)
        {
            char[] oper = new char[4] { '+', '-', '*', '/' };

            foreach (char item in oper)
            {
                if (a.Contains(item))
                {
                    string[] arr = a.Split(item);
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);

                    if (item == '\\' && y == 0)
                        return "a/0 !";

                    switch (item)
                    {
                        case '+':
                            return (x + y).ToString();
                        case '-':
                            return (x - y).ToString();
                        case '*':
                            return (x * y).ToString();
                        case '/':
                            return (x / y).ToString();
                    }



                }
            }
            return "!";
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Lenovo\Desktop\problem.txt";

            while (true)
            {
                EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "ProblemIsReady");
                wh.WaitOne();

                string ans = File.ReadLines(path).Last();

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(Calc(ans));
                }

                EventWaitHandle here = EventWaitHandle.OpenExisting("Solution is Ready");
                here.Set();
            }
        }
    }
}
