﻿using Hangman.Classes;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new(new WordSelector(new Random()));
            game.Play();
        }
    }
}
