namespace polls.Logic
{
    public class Question
    {
        public int? Id { get; set; }
        //public Survey survey;
        public int surveyId;
        public string body;

        public Answer[] answers;

        public Question() {}

        public Question(int id, int surveyId, string body)
        {
            this.Id = id;
            this.surveyId = surveyId;
            this.body = body;
            this.answers = new Answer[5];
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i] = new Answer(i, this, i);
            }
        }
    }
}

