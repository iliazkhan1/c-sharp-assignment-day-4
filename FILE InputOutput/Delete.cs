using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment42
{
    internal class Delete
    {
        public static void DeleteEmployee()
        {
            List<string> lines = new List<string>(File.ReadAllLines(Program.path));
            if (lines.Count <= 1)
            {
                Console.WriteLine("No employee records to delete.");
                return;
            }
            int empId = Valid.GetInt("Enter Employee ID to delete: ");
            bool found = false;
            for (int i = 1; i < lines.Count; i++) // skip header
            {
                string[] parts = lines[i].Split(',');
                int currentId;
                if (!string.IsNullOrWhiteSpace(parts[0]) && int.TryParse(parts[0], out currentId))
                {
                    if (currentId == empId)
                    {
                        Console.WriteLine($"\nEmployee Found: {lines[i]}");
                        string confirm = Valid.GetYesOrNo("Are you sure you want to delete this employee?");
                        if (confirm == "yes")
                        {
                            lines.RemoveAt(i);
                            File.WriteAllLines(Program.path, lines);
                            Console.WriteLine("Employee record deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Deletion canceled.");
                        }
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}