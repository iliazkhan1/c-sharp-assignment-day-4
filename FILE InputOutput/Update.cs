using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment42
{
    internal class Update
    {
        public static void UpdateEmployee()
        {
            List<string> lines = new List<string>(File.ReadAllLines(Program.path));
            if (lines.Count <= 1)
            {
                Console.WriteLine("No employee records found.");
                return;
            }

            int empId = Valid.GetInt("Enter Employee ID to update: ");
            bool found = false;

            for (int i = 1; i < lines.Count; i++) // Start from 1 to skip header
            {
                string[] parts = lines[i].Split(',');

                if (int.Parse(parts[0]) == empId)
                {
                    found = true;
                    int choice;

                    do
                    {
                        Console.WriteLine($"\nCurrent Record: {string.Join(", ", parts)}");
                        Console.WriteLine("1. Update Department");
                        Console.WriteLine("2. Update Salary");
                        Console.WriteLine("0. Exit Update");

                        choice = Valid.GetInt("Enter your choice: ");

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter new Department: ");
                                parts[2] = Console.ReadLine();
                                Console.WriteLine("Department updated.");
                                break;
                            case 2:
                                double newSalary = Valid.GetDouble("Enter new Salary: ");
                                parts[3] = newSalary.ToString();
                                Console.WriteLine("Salary updated.");
                                break;
                            case 0:
                                Console.WriteLine("Exiting update...");
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                        lines[i] = string.Join(",", parts);
                        if (choice != 0)
                        {
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                    } while (choice != 0);

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
            else
            {
                File.WriteAllLines(Program.path, lines);
                Console.WriteLine("Changes saved successfully.");
            }
        }
    }
}
