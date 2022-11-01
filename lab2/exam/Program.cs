
namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            float examResult;


            Console.WriteLine("Please enter your exam result(in %): ");
            try
            {
                examResult = float.Parse(Console.ReadLine());
                if (examResult > 100 || examResult < 0)
                {
                    throw new ArgumentException("Your input is impossible(above 100% or below 0) ");
                }
                else if (examResult < 30)
                {
                    Console.WriteLine("You Failed.");
                }
                else if (examResult <= 50)
                {
                    Console.WriteLine("You Got a E.");
                }
                else if (examResult <= 60)
                {
                    Console.WriteLine("You Got a D.");
                }
                else if (examResult <= 75)
                {
                    Console.WriteLine("You Got a C.");
                }
                else if (examResult <= 85)
                {
                    Console.WriteLine("You Got a B.");
                }
                else
                {
                    Console.WriteLine("You Got a A.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}