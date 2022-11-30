using System;
namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] movies = new string[] { "venom", "No Time To Die", "Matrix Resurrection", "The Addams Family 2", "Dune", "Ron’s Gone Wrong" };
            int[] ageRequirments = new int[] { 15, 12, 15, 8, 12, 8 };
            string movieName;
            int movieAge;
            try
            {
                while (true)
                {
                    int numberOfMoviesToAdd;
                    int userChoice, userAge = 0;
                    do
                    {
                        Console.WriteLine(@"
Please choose one of the following options:
1.Show Movie List
2.Add Movie To The List
3.Validate if user can watch a movie
4.Quit Program");
                        userChoice = int.Parse(Console.ReadLine());
                    } while (!(userChoice > 0 && userChoice < 5));
                    if (userChoice == 1)
                    {
                        Console.WriteLine("The Current Movies are:\n" + string.Join("\n", movies));
                    }
                    else if (userChoice == 2)
                    {
                        Console.WriteLine("Please enter the number of movies you would like to add: ");
                        userChoice = int.Parse(Console.ReadLine());
                        for (int i = 0; i < userChoice; i++)
                        {
                            Console.WriteLine("Please enter the name of the movie you would like to add: ");
                            movieName = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Please enter the age of the movie you would like to add (between 4-18): ");
                                movieAge = int.Parse(Console.ReadLine());
                            } while (!(movieAge > 3 && movieAge < 19));
                            movies = movies.Append(movieName).ToArray();
                            ageRequirments = ageRequirments.Append(movieAge).ToArray();
                        }
                    }
                    else if (userChoice == 3)
                    {
                        do
                        {
                            Console.WriteLine("Please choose one of the following movies:");
                            for (int i = 0; i < movies.Length; i++)
                            {
                                Console.WriteLine((i + 1) + " " + movies[i] + "(" + ageRequirments[i] + ")");
                            }
                            userChoice = int.Parse(Console.ReadLine());
                        } while (!(userChoice > 0 && userChoice < movies.Length + 1));
                        do
                        {
                            Console.WriteLine("Pease enter the users Age(between 0-103): ");
                            userAge = int.Parse(Console.ReadLine());
                        } while (!(userChoice >= 0 && userChoice < 103));
                        Console.WriteLine(ageRequirments[userChoice - 1]);
                        if (userAge >= ageRequirments[userChoice - 1])
                        {
                            Console.WriteLine("The user CAN watch the movie");
                        }
                        else
                        {
                            Console.WriteLine("The user is NOT allowed to watch the movie");
                        }
                    }
                    else if (userChoice == 4)
                    {
                        Console.WriteLine("GoodBye!");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}