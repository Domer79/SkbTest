using System;

namespace SkbTest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                throw new InvalidOperationException("Отсутствуют необходимые параметры");

            try
            {
                var client = new Client(args[0], int.Parse(args[1]));

                while (true)
                {
                    var command = Console.ReadLine();

                    if (string.IsNullOrEmpty(command))
                        continue;

                    var lowerWord = command.ToLower();

                    if (lowerWord == "exit" || lowerWord == "quit")
                        break;

                    client.GetDictionaryData(command + "\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
