using System;

namespace polls.Logic
{
    public class Answer
    {
        public int? Id { get; set; }

        public Question question;
        public int body;
        public List<PollTaker> users;

        public Answer() {}

        public Answer(int id, Question q, int body)
        {
            this.Id = id;
            this.question = q;
            this.body = body;
            users = new List<PollTaker>();
        }
    }
}

