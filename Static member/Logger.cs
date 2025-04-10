namespace ConsoleApp1
{
    public class Logger
    {
        public static string LogFilePath { get; set; }
        static Logger()
        {
            LogFilePath = @"C:\Users\patha\Downloads\default.txt";
        }
        public static void LogMessage(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {message}";
                Console.WriteLine(logEntry);
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging message: " + ex.Message);
            }
        }
    }

}