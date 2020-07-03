using System;
using System.Security.Cryptography;

namespace NumberGuesser
{
    class Program
    {

        static void Main(string[] args)
        {
            WelcomeScreen();
        programstart: int number = GeneratingRanomNumber();
            Console.ResetColor();
            StartGame(number);
            WinScreen(number);
            if (StartAgain() == true) goto programstart;
            else PlayAgainIsFalse();
        }

        private static void PlayAgainIsFalse()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for playing.");
            Console.ResetColor();
        }

        private static bool StartAgain()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Do you want to try again? (Y/N)");
            startagain: string input = Console.ReadLine();
            if (input == "Y" || input == "y") return true;
            else if (input == "N" || input == "n") return false;
            else
            {
                Console.WriteLine("Wrong input. Try again.");
                goto startagain;
            }
        }

        private static void WinScreen(int guess)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Good job, you guessed it right! It was {0}", guess);
            Console.ResetColor();

        }

        private static void StartGame(int number)
        {
            Console.WriteLine("Guess a number between 1 and 100");
            CheckIfGuessIsTrue(number);
        }

        private static void CheckIfGuessIsTrue(int number)
        {
            int guess;
            do
            {
                guess = EnterGuess();
                GenerateHint(number, guess);
            } while (guess != number);
        }

        private static void GenerateHint(int number, int guess)
        {
            if (guess > number) Console.WriteLine("Try a bit lower");
            else if (guess < number) Console.WriteLine("Try a bit higher");
        }

        private static int EnterGuess()
        {
            int guess;
            string input;
            inputGuess: input = Console.ReadLine();
            if (CheckIfInputIsValid(input) == true) guess = Int32.Parse(input);
            else goto inputGuess;

            return guess;
        }

        private static bool CheckIfInputIsValid(string input)
        {
            int guess;
            if (int.TryParse(input, out guess) == false)
            {
                Console.WriteLine("Please enter a valid number");
                return false;
            }
            else if (Int32.Parse(input) < 0 || Int32.Parse(input) > 100)
            {
                Console.WriteLine("Please enter a number between 0 and 100");
                return false;
            }

            return true;
        }

        private static int GeneratingRanomNumber()
        {
            Random rnd = new Random();
            int number;
            number = rnd.Next(1, 100);
            return number;
        }

        private static void WelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What is your name?");
            string input = Console.ReadLine();
            Console.WriteLine("Okay {0}, let's play a game..", input);
        }
    }
}
