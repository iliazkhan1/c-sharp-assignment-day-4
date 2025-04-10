namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogFilePath = @"C:\Users\patha\Downloads\application.txt";

            // Step 2: Simulate logging different events
            Logger.LogMessage("Application started");
            Logger.LogMessage("User logged in");
            Logger.LogMessage("User performed an action");
            Logger.LogMessage("Application encountered a warning");
            Logger.LogMessage("Application exited");

            Console.WriteLine("Logging completed. Check the 'application_log.txt' file.");
        }
    }
}