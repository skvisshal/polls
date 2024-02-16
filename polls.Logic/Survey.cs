using System;

namespace polls.Logic
{
    public class Survey
    {
        public int? Id { get; set; }

        public string title;

        public List<Question> questions;

        public PollAdmin creator;
        
        public Survey(){}

        public Survey(int id, PollAdmin creator, string title)
        {
            this.Id = id;
            this.title = title;
            this.creator = creator;
            this.questions = new List<Question>();
        }
    }
}

