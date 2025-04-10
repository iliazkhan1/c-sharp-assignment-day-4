using System;
using System.IO;

namespace Assignment42
{
    internal class Display
    {
        public static void ShowEmployees()
        {
            string[] lines = File.ReadAllLines(Program.path);

            Console.WriteLine("EmployeeID\tName\t\tDepartment\t\tSalary");
            Console.WriteLine("-------------------------------------------------");

            for (int i = 1; i < lines.Length; i++) // Skip header
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length == 4)
                {
                    Console.WriteLine($"{parts[0]}\t\t{parts[1]}\t\t{parts[2]}\t\t\t{parts[3]}");
                }
            }
        }
    }
}