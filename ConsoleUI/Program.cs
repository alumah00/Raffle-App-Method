using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            //MultiLineAnimation();
            GetRaffleNumber(guests);
            PrintGuestsName();
            PrintWinner();
            Console.ReadLine();
        }
            private static Dictionary<int, string> guests = new Dictionary<int, string>();
            private static int min = 1000;
            private static int max = 9999;
            private static int raffleNumber;
            private static Random _rdm = new Random();
            public static string GetUserInput(string message)
            {
                string output = "";
                Console.Write(message);
                output = Console.ReadLine();
                return output;
            }

            public static void GetUserInfo()
            {
                string otherGuest = "";
                do
                {
                    string name = GetUserInput("Please enter your name ");
                    raffleNumber = GenerateRandomNumber(min, max);
                    while (String.IsNullOrEmpty(name))
                    {
                        name = GetUserInput("Please enter your name ");
                    }
                    while (guests.ContainsKey(raffleNumber))
                    {
                        raffleNumber = GenerateRandomNumber(min, max);
                    }
                    AddGuestsInRaffle(raffleNumber, name);

                    otherGuest = GetUserInput("Do you want to add another name? ").ToLower();
                    while (String.IsNullOrEmpty(otherGuest))
                    {
                        otherGuest = GetUserInput("Do you want to add another name? ").ToLower();
                    }
                } while (otherGuest == "yes" || String.IsNullOrEmpty(otherGuest));
            }

            public static int GenerateRandomNumber(int min, int max)
            {
                int output = _rdm.Next(min, max);
                return output;
            }

            public static void AddGuestsInRaffle(int raffleNumber, string guest)
            {
                guests.Add(raffleNumber, guest);
            }

            public static void PrintGuestsName()
            {
                foreach (var name in guests)
                {
                    Console.WriteLine($"Thank you for coming {name.Value}, your raffle number is {name.Key}");
                }
            }

            public static int GetRaffleNumber(Dictionary<int, string> people)
            {
                List<int> raffleNumber = people.Keys.ToList();
                int i = _rdm.Next(raffleNumber.Count);
                int winnerNumber = raffleNumber[i];
                return winnerNumber;
            }

            public static void PrintWinner()
            {
                int winnerNumber = GetRaffleNumber(guests);
                string winnerName = guests[GetRaffleNumber(guests)];
                Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}!!");
            }

        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
        
        //Start writing your code here

        
    }