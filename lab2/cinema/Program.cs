
namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializing variable that will be used
            int age;
            string movieName;
            int ageRequirment;
            string[] movies = { "venom", "No Time To Die", "Matrix Resurrection", "The Addams Family 2", "Dune", "Ron’s Gone Wrong" };
            int[] ageRequirments = { 15, 12, 15, 8, 12, 8 };
            int userChoice;
            Console.WriteLine(@"Please enter one of the following movies:
1. Venom (Let There Be Carnage) (15) 
2. No Time to Die(12A) 
3. Matrix Resurrection (15) 
4. The Addams Family 2 (PG) 
5. Dune (12A) 
6. Ron’s Gone Wrong (PG) ");
            //if the program is unable to convert the string(console.readline) then the try catch statment will catch the error and display
            //an error message
            try
            {
                userChoice = int.Parse(Console.ReadLine());

                if (userChoice > movies.Length || userChoice <= 0)
                {
                    throw new ArgumentException("movie length out of bounds");
                }
                //reads the input user inputs and sets it to var age
                Console.WriteLine("Enter your age:  ");
                age = int.Parse(Console.ReadLine());
                movieName = movies[userChoice - 1];
                ageRequirment = ageRequirments[userChoice - 1];
                //check if user has entered a negative number
                if (age < 0)
                {
                    throw new ArgumentException("Your input is invalid(less tan 0)");
                }
                //check if user is under the age you need to be to watch movie
                else if (age < ageRequirment)
                {
                    Console.WriteLine("You are not old enough to watch " + movieName);
                }
                //all other input should be above and valid which means that the user is able to watch the movie
                else
                {
                    Console.WriteLine("You can watch " + movieName);
                }
            }// will cath the error that will be thrown by int.parse if the user input is not an intiger
            //this will also didplay error messages that have been thrown by unplanned errors
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}