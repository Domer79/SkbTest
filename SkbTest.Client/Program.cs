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
                var consoleKey = Console.ReadKey();
                var command = string.Empty;

                while (consoleKey.Key != ConsoleKey.Escape)
                {
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.Enter:
                        {
                            client.GetDictionaryData(command + "\r\n");
                            command = string.Empty;
                            break;
                        }
                        case ConsoleKey.Backspace:
                        {
                            if (command.Length == 0)
                                break;

                            ConsoleLineClear(command);
                            command = command.Substring(0, command.Length - 1);
                            Console.Write(command);
                            break;
                        }
                        default:
                        {
                            command += consoleKey.KeyChar;
                            break;
                        }
                    }

                    consoleKey = Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ConsoleLineClear(string line)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
