using Hangman.Enums;

namespace Hangman.Helpers
{
    public static class OutputHelper
    {
        public static void PrintMainMenu()
        {
            HangmanLogo();
            Console.WriteLine("Possible topics:");
            foreach (var topic in Enum.GetValues(typeof(TopicEnum)))
            {
                Console.WriteLine($"{(int)topic}. {topic}");
            }
            Console.WriteLine();
        }

        private static void HangmanLogo()
        {
            Console.Clear();
            Console.WriteLine("    HANGMAN");
            Console.WriteLine("+______________");
            Console.WriteLine("|/          |");
            Console.WriteLine("|           O");
            Console.WriteLine("|          /|\\");
            Console.WriteLine("|          / \\");
            Console.WriteLine("|");
            Console.WriteLine("|\\_____________\n");
        }
      
        public static void HangmanDrawing(int attempts)
        {
            Console.WriteLine("+______________");
            switch (attempts)
            {
                case 0:
                    {
                        Console.WriteLine("|/");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|           |");
                        Console.WriteLine("|");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|");
                        Console.WriteLine("|");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|          /");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|          / \\");
                        break;
                    }

            }
            Console.WriteLine("|");
            Console.WriteLine("|\\_____________");


        }
       
    }
}
