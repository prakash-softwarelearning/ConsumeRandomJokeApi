using System.Reflection;

namespace Model
{
    public class RandomJokes
    {
        public string Id { get; set; }
        public string Jokes { get; set; }
        public string punchline { get; set; }
        public string type { get; set;}

    }

    public class jsonData
    { 
     public bool success { get; set; }
     public Body[] body { get; set;}
    }

    public class jsonDataCount
    {
        public bool success { get; set; }
        public int body { get; set; }
    }


    public class Body
    {
        public string _id { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }

        public string type { get; set; }
        public string[] likes { get; set; }

        public authors author {get;set;}
        public bool approved { get; set; }
        public string date { get; set; }

        public bool NSFW { get; set; }
        public string shareableLink { get; set;}

    }

    public class authors
    { 
      public string id { get; set; }
        public string name { get; set; }
        
    }
}