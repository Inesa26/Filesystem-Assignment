using System.Configuration;

namespace EmailSenderApp
{
    public static class Logger
    {
        public static async Task Log(string methodName, string outcome)
        {
            string logMessage = $"{DateTime.Now}: Method '{methodName}' - {outcome}";

            await WriteToFile(logMessage);
        }

        private static async Task WriteToFile(string logMessage)
        {
            string logFileName = $"Logs_{DateTime.Now:yyyy-MM-dd}.txt";
            string logFilePath = Path.Combine(ConfigurationManager.AppSettings["logPath"], logFileName);

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                try
                {
                    await writer.WriteLineAsync(logMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }
        }
    }
}
