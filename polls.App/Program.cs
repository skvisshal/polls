using System;

namespace polls.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            regOrLog();
        }

        public static void regOrLog()
        {
            Console.WriteLine("Enter 'R' to Register or 'L' to Log In");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("Successfully Exited!");
            }
            else if (input != "R" && input != "L")
            {
                Console.WriteLine("Invalid Input");
                regOrLog();
            }
            else if(input == "R")
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Birth Year: ");
                int birthYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Country: ");
                string country = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
            }
        }
    }
}

