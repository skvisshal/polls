using System;
using System.IO;
using System.Xml.Serialization;
using polls.Logic;

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
                User u1 = new PollTaker(username, password, name, email, birthYear, country);
                string path = @"./Users.txt";
                Serialize(u1,path);
            }
            else
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                string path = @"./Users.txt";
                Console.WriteLine(DeserializeXML(path).ToString());
            }
            
            
        }

        public static void Serialize(User u, string path)
        {
            string[] text = { u.SerializeXML() };
            File.WriteAllLines(path, text);
        }

        public static User DeserializeXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PollTaker));
            User U = new PollTaker();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found!");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (User)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    U = record;
                }
            }
            return U;
        }
    }
}

