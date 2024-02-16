using System;

namespace polls.Logic
{
    public class PollTaker : User
    {
        public int? pollCount { get; set; } = 0;
        public PollTaker(){}

        public PollTaker(string name, string email, int birthYear, string country)
        {
            this.name = name;
            this.email = email;
            this.birthYear = birthYear;
            this.country = country;
        }

        public override string toString()
        {
            return
                $"Poll Answerer\nName: {this.name}\nEmail: {this.email}\nBirth Year: {this.birthYear}\nCountry: {this.country}\n No. of Polls Taken: {this.pollCount}\n";
        }
    }
}

