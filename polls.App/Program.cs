﻿using System;
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
                PollAdmin user = adminRegOrLog();
                if (user == null) return;
                AdminHome(user);
            } else if (input == 2)
            {
                User user = userRegOrLog();
                if (user == null) return;
                UserHome(user);
            }
            else
            {
                Console.WriteLine("Wrong Input");
                Main(args);
            }
            
        }

        public static PollAdmin adminRegOrLog()
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
                PollAdmin u1;
                try
                {
                    u1 = new PollAdmin(username, password, name, email, birthYear, country);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    adminRegOrLog();
                    return null;
                }
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

                PollTaker u1;
                try
                {
                    u1 = new PollTaker(username, password, name, email, birthYear, country);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    adminRegOrLog();
                    return null;
                }
                
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
        
        public static List<Survey> DeserializeListSurvey(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Survey>));
            var surveys = new List<Survey>();
            using (var reader = new StreamReader(path))
            {
                surveys = (List<Survey>)xmlSerializer.Deserialize(reader);
            }

            return surveys;
        }
        
        public static void SerializeListSurvey(List<Survey> uL, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Survey>));
            using (var writer = new StreamWriter(path))
            {
                xmlSerializer.Serialize(writer, uL);
            }
        }
        
        
        
        

        public static void AdminHome(PollAdmin u)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Admin Home Page");
            Console.WriteLine("[1] Create Survey");
            Console.WriteLine("[2] View Surveys");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter Survey Title");
                string title = Console.ReadLine();
                bool check = true;
                int counter = 1;
                List <String> l= new List<String>();
                while (check)
                {
                    Console.WriteLine("Enter Question "+counter);
                    l.Add(Console.ReadLine());
                    Console.WriteLine("Enter q to end survey or c to continue");
                    string response = Console.ReadLine();
                    if (response.Equals("c"))
                    {
                        counter++;
                        continue;
                    } else if (response.Equals("q"))
                    {
                        check = false;
                    }
                }

                List<Survey> existingSurveys =
                    DeserializeListSurvey(@"./Surveys.txt");
                int lastIndex = 1;
                try
                {
                    lastIndex = existingSurveys.FindLast(x => x.Id > 0).Id;
                }
                catch
                {
                    lastIndex = 1;
                }
                Survey s = new Survey(lastIndex + 1, u, title);
                //l.ForEach(x => s.questions.Add(new Question(1,s.Id,x)));
                existingSurveys.Add(s);
                SerializeListSurvey(existingSurveys,@"./Surveys.txt");
                //Console.WriteLine();
                
            }else if (choice == 2)
            {
                
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                AdminHome(u);
                return;
            }
        }
        
        public static void UserHome(User u)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("User Home Page");
            Console.WriteLine("[1] List Available Surveys");
            Console.WriteLine("[2] View Answered Surveys");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                List<Survey> existingSurveys =
                    DeserializeListSurvey(@"./Surveys.txt");
                existingSurveys.ForEach(x => Console.WriteLine(x.ToString()));
            }else if (choice == 2)
            {
                
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                UserHome(u);
                return;
            }
        }
    }
}

