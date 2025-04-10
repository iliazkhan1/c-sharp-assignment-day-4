using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment42
{
    internal class Valid
    {
        public static int GetInt(string msg)
        {
            int num;
            while (true)
            {
                Console.Write(msg);
                var s = Console.ReadLine();
                if (int.TryParse(s, out num) && num >= 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a number...");
                }
            }
        }

        public static double GetDouble(string msg)
        {
            double num;
            while (true)
            {
                Console.Write(msg);
                var s = Console.ReadLine();
                if (double.TryParse(s, out num) && num >= 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a number...");
                }
            }
        }
        public static string GetYesOrNo(string message)
        {
            string input = "";
            while (input != "yes" && input != "no" && input != "y" && input != "n")
            {
                Console.Write(message + " (yes/no): ");
                input = Console.ReadLine().Trim().ToLower();
            }
            return (input == "y") ? "yes" : (input == "n") ? "no" : input;
        }
    }
}
