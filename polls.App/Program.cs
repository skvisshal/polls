using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using polls.Logic;

namespace polls.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Survey Station");
            Console.WriteLine("[1] Poll Admin");
            Console.WriteLine("[2] Poll User");
            Console.WriteLine("Input: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                User user = adminRegOrLog();
                if (user == null) return;
                Console.WriteLine(user.ToString());
            } else if (input == 2)
            {
                User user = userRegOrLog();
                if (user == null) return;
                Console.WriteLine(user.ToString());
            }
            else
            {
                Console.WriteLine("Wrong Input");
                Main(args);
            }
            
        }

        public static User adminRegOrLog()
        {
            List<PollAdmin> existingAdmins = DeserializeListAdmin(@"./Admins.txt");
            Console.WriteLine("Enter 'R' to Register or 'L' to Log In");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("Successfully Exited!");
                return null;
            }
            else if (input != "R" && input != "L")
            {
                Console.WriteLine("Invalid Input");
                adminRegOrLog();
                return null;
            }
            else if(input == "R")
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                if (existingAdmins.Exists(x => x.username == username))
                {
                    Console.WriteLine("Username already exists");
                    return null;
                }
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
                PollAdmin u1 = new PollAdmin(username, password, name, email, birthYear, country);
                string path = @"./Admins.txt";
                existingAdmins.Add(u1);
                SerializeListAdmin(existingAdmins,path);
                return u1;
            }
            else
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (!existingAdmins.Exists(x => x.username == username && x.password == password))
                {
                    Console.WriteLine("Incorrect Username and Password Combo");
                    return null;
                }
                return existingAdmins.Find(x => x.username == username && x.password == password);
            }
        }
        public static User userRegOrLog()
        {
            List<PollTaker> existingUsers = DeserializeList(@"./Users.txt");
            Console.WriteLine("Enter 'R' to Register or 'L' to Log In");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("Successfully Exited!");
                return null;
            }
            else if (input != "R" && input != "L")
            {
                Console.WriteLine("Invalid Input");
                userRegOrLog();
                return null;
            }
            else if(input == "R")
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                if (existingUsers.Exists(x => x.username == username))
                {
                    Console.WriteLine("Username already exists");
                    return null;
                }
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
                PollTaker u1 = new PollTaker(username, password, name, email, birthYear, country);
                string path = @"./Users.txt";
                existingUsers.Add(u1);
                SerializeList(existingUsers,path);
                return u1;
            }
            else
            {
                Console.WriteLine("UserName: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (!existingUsers.Exists(x => x.username == username && x.password == password))
                {
                    Console.WriteLine("Incorrect Username and Password Combo");
                    return null;
                }
                return existingUsers.Find(x => x.username == username && x.password == password);
            }
            
            
        }

        public static void Serialize(User u, string path)
        {
            string[] text = { u.SerializeXML() };
            File.WriteAllLines(path, text);
        }

        public static void SerializeList(List<PollTaker> uL, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PollTaker>));
            using (var writer = new StreamWriter(path))
            {
                xmlSerializer.Serialize(writer, uL);
            }
        }
        
        public static void SerializeListAdmin(List<PollAdmin> uL, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PollAdmin>));
            using (var writer = new StreamWriter(path))
            {
                xmlSerializer.Serialize(writer, uL);
            }
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

        public static List<PollTaker> DeserializeList(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PollTaker>));
            var users = new List<PollTaker>();
            using (var reader = new StreamReader(path))
            {
                users = (List<PollTaker>)xmlSerializer.Deserialize(reader);
            }

            return users;
        }
        
        public static List<PollAdmin> DeserializeListAdmin(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PollAdmin>));
            var admins = new List<PollAdmin>();
            using (var reader = new StreamReader(path))
            {
                admins = (List<PollAdmin>)xmlSerializer.Deserialize(reader);
            }

            return admins;
        }

        public static void UserHome(User u)
        {
            Console.WriteLine("User Home Page");
            Console.WriteLine("[1] Create Survey");
            Console.WriteLine("[2] View Surveys");
        }
    }
}

