using System;

namespace polls.Logic
{
    public class Answer
    {
        public int? Id { get; set; }
        private static int idSeed = 1;

        public Question question;
        public int body;
        public List<PollTaker> users;

        public Answer() {}

        public Answer(Question q, int body)
        {
            this.Id = idSeed;
            idSeed++;
            this.question = q;
            this.body = body;
            users = new List<PollTaker>();
        }
    }
}

