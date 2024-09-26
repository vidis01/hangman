using Hangman.Enums;
using Hangman.Helpers;
using Hangman.Interfaces;

namespace Hangman.Classes
{
    internal class Game
    {
        bool choosingTopic = true;
        string? userInput = "";
        int attempts = 0;
        bool gameOn = true;

        public const int MaxAttempts = 7;

        private TopicEnum? _topic;
        private IWordSelector _wordSelector;

        private string _wordToGuess = "";
        private char[] _wordInDashes = Array.Empty<char>();
        private List<char> _guessedLetters = new();
        public List<string> _guessedWords = new();

        public Game(IWordSelector wordSelector)
        {
            _wordSelector = wordSelector;
        }

        public void Play()
        {
            _topic = ChooseTopic();
            _wordToGuess = _wordSelector.SelectWord(_topic);
            _wordInDashes = new string('_', _wordToGuess.Length).ToCharArray();
            GameLogic();
        }

        private TopicEnum? ChooseTopic()
        {
            OutputHelper.PrintMainMenu();

            TopicEnum? topic;

            do
            {
                Console.WriteLine("Choose topic:");
                userInput = Console.ReadLine();
            }
            while (!InputHelper.TryParseTopicSelection(userInput, out topic));

            Console.Clear();

            return topic;
        }

        private void GameLogic()
        {
            while (gameOn)
            {
                GameScreenLayout();

                Console.WriteLine("Guess a letter:");
                userInput = Console.ReadLine();

                Console.Clear();
                if (CheckUserInput.BasicChecks(userInput))
                {
                    if (userInput.Length > 1)
                    {
                        if (!(userInput.Length > _wordToGuess.Length))
                        {
                            if (!CheckIfItsTheSameWord(userInput.ToLower()))
                            {
                                if (userInput.ToLower() == _wordToGuess.ToLower())
                                {
                                    GameWin();
                                    gameOn = false;
                                }
                                else
                                {
                                    Console.WriteLine("Your guess was incorrect.");
                                    attempts++;
                                    if (attempts == MaxAttempts)
                                    {
                                        GameOver();
                                        gameOn = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"You guessed that word already..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Word you entered has more symbols than the word you trying to guess");
                        }
                    }
                    else
                    {
                        char userInputChar = char.ToLower(char.Parse(userInput));
                        if (CheckUserInput.CheckLetters(userInputChar))
                        {
                            if (!CheckIfItsTheSameLetter(userInputChar))
                            {
                                if (GuessChecking(char.ToLower(userInput[0]), _wordToGuess))
                                {
                                    Console.WriteLine($"Your guess '{userInputChar}' was correct!\n");
                                    if (!_wordInDashes.Contains('_'))
                                    {
                                        GameWin();
                                        gameOn = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Sorry, there is no '{userInputChar}' letter in this word..\n");
                                    attempts++;

                                    if (attempts == MaxAttempts)
                                    {
                                        GameOver();
                                        gameOn = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"You guessed '{userInput}' letter already. \n");
                            }
                        }
                        else 
                        { 
                            Console.WriteLine($"Let's be real, {userInput} is not a letter.\n"); 
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your entry is invalid.");
                }
            }
        }
        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine($"Sorry, you've lost...");
            OutputHelper.HangmanDrawing(MaxAttempts);

        }
        private void GameWin()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You Won!!");
            Console.WriteLine($"Correct word - {_wordToGuess}");
        }

        private void GameScreenLayout()
        {
            Console.WriteLine($"Topic selected: {_topic}\n");
            PrintLettersGuessed();
            PrintWordsGuessed();
            Console.WriteLine();
            OutputHelper.HangmanDrawing(attempts);
            Console.WriteLine();
            PrintWordInDashes();
            Console.WriteLine("\n");
        }

        private bool GuessChecking(char userInput, string wordSelected)
        {
            int indexCount = 0;
            bool guessWasCorrect = false;
            foreach (var item in wordSelected.ToLower())
            {
                if (item == userInput)
                {
                    _wordInDashes[indexCount] = userInput;
                    guessWasCorrect = true;
                }
                indexCount++;
            }
            return guessWasCorrect;
        }

        private bool CheckIfItsTheSameLetter(char userInput)
        {
            if (!_guessedLetters.Contains(userInput))
            {
                _guessedLetters.Add(userInput);
                return false;
            }
            return true;
        }

        private bool CheckIfItsTheSameWord(string userInput)
        {
            if (!_guessedWords.Contains(userInput))
            {
                _guessedWords.Add(userInput);
                return false;
            }
            return true;
        }

        private void PrintLettersGuessed()
        {
            if (_guessedLetters.Count != 0)
            {
                Console.WriteLine("Letters that you guessed already:");
                foreach (var item in _guessedLetters)
                {
                    Console.Write($"{item}, ");
                }
            }
            Console.WriteLine();
        }

        private void PrintWordsGuessed()
        {
            if (_guessedWords.Count != 0)
            {
                Console.WriteLine("Words that you guessed already:");
                foreach (var item in _guessedWords)
                {
                    Console.Write($"{item}, ");
                }
            }
        }

        private void PrintWordInDashes()
        {
            foreach (var item in _wordInDashes)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
