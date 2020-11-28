using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Motorola
{
    class Program
    {
        static void Main()
        {
            bool gameOn = true;

            while (gameOn)
            {
                List<string> countriesAndCapitals = File.ReadLines(@"C:\\Users\\Marian\\source\repos\\Motorola\\Motorola\\countries_and_capitals.txt").ToList();
                Random rnd = new Random();
                string pickedRecord = countriesAndCapitals[rnd.Next(0, countriesAndCapitals.Count)];
                string[] splittedRecord = pickedRecord.Split('|');
                string country = splittedRecord[0].Trim();
                string capitalUpperCase = splittedRecord[1].Trim();
                string capital = splittedRecord[1].Trim().ToLower();
                int lifes = 5;
                int guessCount = 0;
                DateTime dateBeginning = DateTime.Now;

                List<char> rightLetters = new List<char>();
                List<char> wrongLetters = new List<char>();
                List<char> capitalLetters = new List<char>();
                capitalLetters.AddRange(capital);

                Console.WriteLine(capital);
                                
                Console.WriteLine("You have " + lifes + " lifes left");
                Console.WriteLine("Name of the capital to guess:");

                ShowCapitalName(capital, rightLetters);

                while (true)
                {
                    if (lifes <= 0)
                    {
                        Console.WriteLine("You lost :(");
                        break;
                    }

                    if (lifes == 1)
                    {
                        Console.WriteLine("Hint: The capital of " + country);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to guess a single letter (l), or give it a shot and try with entire word (w): ");
                    char choice = GetCharFromUser();

                    if (choice == 'l')
                    {
                        Console.Write("Enter a single letter: ");
                        char letter = GetCharFromUser();

                        if (capitalLetters.Contains(letter))
                        {
                            Console.WriteLine("Very nice!");
                            rightLetters.Add(letter);
                            guessCount++;

                            ShowCapitalName(capital, rightLetters);

                            for (int i = 0; i < capitalLetters.Count; i++)
                            {
                                if (capitalLetters[i] == letter)
                                {
                                    capitalLetters.Remove(letter);
                                }
                            }

                            if (capitalLetters.Count == 0)
                            {
                                Console.WriteLine("You win!");
                                DateTime dateEnd = DateTime.Now;
                                TimeSpan scoreTime = (dateEnd - dateBeginning);
                                Console.WriteLine("You guessed the capital after " + guessCount + " letters. It took you " + scoreTime + " seconds");
                                HighScore(capitalUpperCase, guessCount);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Oops! Try again!");

                            if (!capitalLetters.Contains(letter))
                            {
                                lifes--;
                                guessCount++;

                                if (!wrongLetters.Contains(letter))
                                {
                                    wrongLetters.Add(letter);
                                }
                                Console.WriteLine("Not-in-word list:");

                                for (int i = 0; i < wrongLetters.Count; i++)
                                {
                                    Console.Write(wrongLetters[i] + ", ");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("You have " + lifes + " lifes left");

                        }
                    }
                    else if (choice == 'w')
                    {
                        Console.Write("Enter correct answer: ");
                        string word = Console.ReadLine();

                        if (word == capital || word == capitalUpperCase)
                        {
                            Console.WriteLine("Wow! That is correct! You win!");
                            Console.WriteLine(capitalUpperCase + " is a capital of " + country);
                            guessCount++;
                            DateTime dateEnd = DateTime.Now;
                            TimeSpan scoreTime = (dateEnd - dateBeginning);
                            Console.WriteLine("You guessed the capital after " + guessCount + " letters. It took you " + Math.Round(scoreTime.TotalSeconds) + " seconds");
                            HighScore(capitalUpperCase, guessCount);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Oops! Try again!");
                            lifes -= 2;
                            guessCount++;
                            if (lifes >= 0)
                            {
                                Console.WriteLine("You have " + lifes + " lifes left");
                            }
                            else
                            {
                                Console.WriteLine("You have 0 lifes left");
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Type 'l' or 'w'");
                    }
                }
                Console.Write("Would you like to start again? (y/n) ");
                char end = GetCharFromUser();

                if (end == 'y')
                {
                    gameOn = true;
                }
                else if (end == 'n')
                {
                    gameOn = false;
                }
                else 
                {
                    Console.Write("y/n? ");
                }
            }
        }
        
        static char GetCharFromUser()
        {
            while (true)
            {
                string choice = Console.ReadLine();

                if (choice.Length == 1 && choice != " ")
                {
                    if (Char.IsLetter(Convert.ToChar(choice)))
                    {
                        return Convert.ToChar(choice);
                    }
                    else 
                    {
                        Console.WriteLine("Enter a single char");
                    }                  
                }
                else
                {
                    Console.WriteLine("Enter a single char");
                }
            }
        }     
        static void ShowCapitalName(string capital, List<char> rightLetters)
        {
            for (int i = 0; i < capital.Length; i++)
            {
                if (rightLetters.Contains(capital[i]))
                {
                    Console.Write(" " + capital[i]);
                }
                else if (capital[i] == ' ')
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write(" _");
                }
            }
            Console.WriteLine();      
        }

        static void HighScore(string capitalUpperCase, int guessCount) 
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            string score = name + " | " + DateTime.Now + " | " + guessCount + " | " + capitalUpperCase;
            Console.WriteLine("Your score:");
            Console.WriteLine(score);
        }
    }
}
