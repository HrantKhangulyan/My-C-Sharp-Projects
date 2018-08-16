using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your problem!");
            string ans;
            string path = @"C:\Users\Lenovo\Desktop\problem.txt";
            Console.WriteLine("Enter the problem!");
            while (true)
            {
                ans = Console.ReadLine();
                if (ans.Contains('#'))
                    break;

                using (StreamWriter sw = new StreamWriter(path , true))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(ans);
                }

                EventWaitHandle wh = EventWaitHandle.OpenExisting("ProblemIsReady");
                wh.Set();

                EventWaitHandle here = new EventWaitHandle(false, EventResetMode.AutoReset, "Solution is Ready");
                here.WaitOne();
                Console.WriteLine(File.ReadLines(path).Last());
            }
        }
    }
}
