﻿using System;
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
            try
            {
                List<string> countriesAndCapitals = File.ReadLines(@"C:\\Users\\Marian\\source\repos\\Motorola\\Motorola\\countries_and_capitals.txt").ToList();
                Random rnd = new Random();
                string pickedRecord = (countriesAndCapitals[rnd.Next(0, countriesAndCapitals.Count)]);
                string[] splittedRecord = pickedRecord.Split('|');
                string country = splittedRecord[0].Trim().ToLower();
                string capital = splittedRecord[1].Trim().ToLower();
                int lifes = 5;

                List<char> rightLetters = new List<char>();
                List<char> wrongLetters = new List<char>();
                List<char> capitalLetters = new List<char>();
                capitalLetters.AddRange(capital);

                Console.WriteLine(capital);

                bool gameOn = true;

                Console.WriteLine("Name of the capital to guess:");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" _", capital.Length)));

                while (gameOn)
                {
                   

                    if (lifes <= 0)
                    {
                        Console.WriteLine("You lost");
                        break;
                    }

                    if (lifes == 1)
                    {
                        Console.WriteLine("Hint: The capital of " + country);
                    }

                    Console.WriteLine("Already used letters:");

                    for (int i = 0; i < wrongLetters.Count; i++)
                    {                       
                        Console.Write(wrongLetters[i] + ", ");
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

                            for (int i = 0; i < capital.Length; i++)
                            {
                                if (capital[i] == letter)
                                {
                                    Console.Write(" " + letter);
                                }
                                else
                                {
                                    Console.Write(" _");
                                }
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Oops! Try again!");
                            if (!wrongLetters.Contains(letter))
                            {
                                wrongLetters.Add(letter);
                                lifes--;
                            }

                        }

                    }
                    if (choice == 'w')
                    {
                        Console.Write("Enter correct answer: ");
                        string word = (Console.ReadLine());

                        if (word == capital)
                        {
                            Console.WriteLine("Wow! That is correct! You win!");
                            Console.WriteLine(capital + " is a capital of " + country);
                        }
                        else
                        {
                            Console.WriteLine("Oops! Try again!");
                            lifes -= 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Type 'l' or 'w'");
                    }

                }

                Console.ReadLine();

               }

            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                Console.ReadLine();
            }


        }

        static char GetCharFromUser()
        {
            while (true)
            {
                string choice = Console.ReadLine();

                if (choice.Length == 1)
                {
                    return Convert.ToChar(choice);
                }
                else
                {
                    Console.WriteLine("Enter a single char");
                }
            }




        }

    }
}
