namespace polls.Logic
{
    public class Question
    {
        public int? Id { get; set; }
        private static int idSeed = 1;
        public Survey survey;

        public string body;

        public Answer[] answers;

        public Question() {}

        public Question(Survey survey, string body)
        {
            this.Id = idSeed;
            idSeed++;
            this.survey = survey;
            this.body = body;
            this.answers = new Answer[5];
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i] = new Answer(this, i);
            }
        }
    }
}

