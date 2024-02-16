using System;

namespace polls.Logic
{
    public abstract class User
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public string? email{ get; set; }
        public int? birthYear{ get; set; }
        public string? country{ get; set; }

        public abstract string ToString();
    }
}

