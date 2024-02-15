using System;

namespace polls.Logic
{
    public abstract class User
    {
        public string? name { get; set; }
        public string? email;
        public int? birthYear;
        public string? country;

        public abstract string ToString();
    }
}

