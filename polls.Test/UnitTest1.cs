using System;
using polls.Logic;
using polls.App;

namespace polls.Test
{
    public class UnitTest1
    {
        // Unit Test
        [Fact]
        public void Test1()
        {
            PollTaker _pollTaker = new PollTaker();
            _pollTaker.name = "Visshal Suresh";
            
            Assert.Equal(_pollTaker.name,"Visshal Suresh");
        }
        
        /**
         * Test for only valid email addresses
         */
        [Fact]
        public void Test2()
        {
            Exception exception = Assert.Throws<Exception>(() => new PollTaker("a","a","a","gg",1,"a"));
            Assert.Equal("Not Valid Email Address", exception.Message);
        }
        /**
         * test for valid birth year
         */
        [Fact]
        public void Test3()
        {
            Exception exception = Assert.Throws<Exception>(() => new PollTaker("a","a","a","skvisshal@gmail.com",1,"a"));
            Assert.Equal("Invalid Birth Year", exception.Message);
        }
        /**
         * tests for polladmin
         */
        [Fact]
        public void Test4()
        {
            PollAdmin _pollAdmin = new PollAdmin();
            _pollAdmin.name = "Visshal Suresh";
            
            Assert.Equal(_pollAdmin.name,"Visshal Suresh");
        }
        
        [Fact]
        public void Test5()
        {
            Exception exception = Assert.Throws<Exception>(() => new PollAdmin("a","a","a","gg",1,"a"));
            Assert.Equal("Not Valid Email Address", exception.Message);
        }
        
        [Fact]
        public void Test6()
        {
            Exception exception = Assert.Throws<Exception>(() => new PollAdmin("a","a","a","skvisshal@gmail.com",1,"a"));
            Assert.Equal("Invalid Birth Year", exception.Message);
        }
        
        [Fact]
        public void Test7()
        {
            PollTaker _pollTaker = new PollTaker();
            _pollTaker.password = "password123";
            
            Assert.Equal(_pollTaker.password,"password123");
        }
        
        [Fact]
        public void Test8()
        {
            List <PollTaker> l= new List<PollTaker>();
            Assert.IsType<List<PollTaker>>(Program.DeserializeList(@"./Users.txt"));
        }
        
        [Fact]
        public void Test9()
        {
            List <PollAdmin> l= new List<PollAdmin>();
            Assert.IsType<List<PollAdmin>>(Program.DeserializeListAdmin(@"./Admins.txt"));
        }
        
        [Fact]
        public void Test10()
        {
            PollTaker _pollTaker = new PollTaker();
            _pollTaker.username = "username.test";
            
            Assert.Equal(_pollTaker.username,"username.test");
        }
    }
}


