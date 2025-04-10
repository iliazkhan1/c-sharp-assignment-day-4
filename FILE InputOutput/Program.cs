namespace Assignment42
{
    internal class Program
    {
        public static string path = @"C:\Users\patha\Downloads\Book1.csv";
        static void Main(string[] args)
        {
            if (File.Exists(path))
            {
                int choice = -1;
                while (choice != 0)
                {
                    Console.Clear();
                    Console.WriteLine("1. Display List");
                    Console.WriteLine("2. Update List");
                    Console.WriteLine("3. Delete");
                    Console.WriteLine("0. Exit");

                    choice = Valid.GetInt("Enter the Choice (Numbers: 1, 2, 3, ...): ");
                    switch (choice)
                    {
                        case 1:
                            Display.ShowEmployees();
                            break;

                        case 2:
                            Update.UpdateEmployee();
                            break;

                        case 3:
                            Delete.DeleteEmployee();
                            break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                    if (choice != 0)
                    {
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist!");
            }
        }
    }
}
