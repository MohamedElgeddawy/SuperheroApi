
   namespace SuperheroApi.Models
    {
        // Represents a superhero with various properties
        public class Superhero
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Powerstats Powerstats { get; set; }
            public Biography Biography { get; set; }
            public Appearance Appearance { get; set; }
            public Work Work { get; set; }
            public Connections Connections { get; set; }
            public Image Image { get; set; }
        }

        // Represents the power statistics of a superhero
        public class Powerstats
        {
            public int Intelligence { get; set; }
            public int Strength { get; set; }
            public int Speed { get; set; }
            public int Durability { get; set; }
            public int Power { get; set; }
            public int Combat { get; set; }
        }

        // Represents the biography of a superhero
        public class Biography
        {
            public string FullName { get; set; }
            public string AlterEgos { get; set; }
            public string PlaceOfBirth { get; set; }
            public string FirstAppearance { get; set; }
            public string Publisher { get; set; }
            public string Alignment { get; set; }
        }

        // Represents the appearance of a superhero
        public class Appearance
        {
            public string Gender { get; set; }
            public string Race { get; set; }
            public string[] Height { get; set; }
            public string[] Weight { get; set; }
            public string EyeColor { get; set; }
            public string HairColor { get; set; }
        }

        // Represents the work details of a superhero
        public class Work
        {
            public string Occupation { get; set; }
            public string Base { get; set; }
        }

        // Represents the connections of a superhero
        public class Connections
        {
            public string GroupAffiliation { get; set; }
            public string Relatives { get; set; }
        }

        // Represents the image of a superhero
        public class Image
        {
            public string Url { get; set; }
        }

        
      
    }
    