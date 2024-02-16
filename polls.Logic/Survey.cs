using System;
using System.IO;
using System.Xml.Serialization;

namespace polls.Logic
{
    public class Survey
    {
        public int Id { get; set; }

        public string title;

        public List<Question> questions;

        public PollAdmin creator;
        
        private XmlSerializer Serializer = new XmlSerializer(typeof(Survey));
        
        public Survey(){}

        public Survey(int id, PollAdmin creator, string title)
        {
            this.Id = id;
            this.title = title;
            this.creator = creator;
            this.questions = new List<Question>();
        }
        
        public string SerializeXML()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
        
        public override string ToString()
        {
            return $"Survey\ntitle: {this.title}\n";
        }
    }
}

