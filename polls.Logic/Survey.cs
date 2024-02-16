using System;

namespace polls.Logic
{
    public class Survey
    {
        public int? Id { get; set; }

        public string title;

        public List<Question> questions;

        public PollAdmin creator;

        private static int idSeed = 1;
        
        public Survey(){}

        public Survey(PollAdmin creator, string title)
        {
            this.Id = idSeed;
            this.title = title;
            idSeed++;
            this.creator = creator;
            this.questions = new List<Question>();
        }
    }
}

