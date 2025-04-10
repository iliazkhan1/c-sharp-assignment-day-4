using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Assignment45
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }

    internal class Program
    {
        static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            Console.Write("How many accounts do you want to add? ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for account #{i + 1}");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                string email;
                Console.Write("Email: ");
                email = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                {
                    Console.Write("Invalid email. Please enter a valid email address: ");
                    email = Console.ReadLine();
                }


                DateTime dob;
                Console.Write("Date of Birth (yyyy-mm-dd): ");
                while (!DateTime.TryParse(Console.ReadLine(), out dob))
                {
                    Console.Write("Invalid format. Please enter DOB as yyyy-mm-dd: ");
                }

                accounts.Add(new Account
                {
                    Name = name,
                    Email = email,
                    DOB = dob
                });
            }

            string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            Console.WriteLine("\nSerialized JSON:");
            Console.WriteLine(json);

            List<Account> deserializedAccounts = JsonConvert.DeserializeObject<List<Account>>(json);
            Console.WriteLine("\nDeserialized Account List:");
            foreach (var acc in deserializedAccounts)
            {
                Console.WriteLine($"Name: {acc.Name}, Email: {acc.Email}, DOB: {acc.DOB.ToShortDateString()}");
            }
        }
    }
}