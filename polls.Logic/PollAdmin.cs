using System;
using System.IO;
using System.Xml.Serialization;

namespace polls.Logic
{
    public class PollAdmin : User
    {
        public int? pollCount { get; set; } = 0;
        
        private XmlSerializer Serializer = new XmlSerializer(typeof(PollAdmin));
        public PollAdmin(){}
        
        public PollAdmin(string username, string password, string name, string email, int birthYear, string country)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
            this.birthYear = birthYear;
            this.country = country;
        }
        
        public override string SerializeXML()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
        
        public override string ToString()
        {
            return
                $"Poll Creator\nName: {this.name}\nEmail: {this.email}\nBirth Year: {this.birthYear}\nCountry: {this.country}\nNo. of Polls Taken: {this.pollCount}\n";
        }
    }
}

