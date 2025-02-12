
namespace SuperheroApi.Core.Models
{
    
    public class SuperheroApiResponse
    {
        public string Response { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public PowerstatsApiResponse Powerstats { get; set; }
        public BiographyApiResponse Biography { get; set; }
        public AppearanceApiResponse Appearance { get; set; }
        public WorkApiResponse Work { get; set; }
        public ConnectionsApiResponse Connections { get; set; }
        public ImageApiResponse Image { get; set; }
    }

    public class PowerstatsApiResponse
    {
        public string Intelligence { get; set; }
        public string Strength { get; set; }
        public string Speed { get; set; }
        public string Durability { get; set; }
        public string Power { get; set; }
        public string Combat { get; set; }
    }

    public class BiographyApiResponse
    {
        public string FullName { get; set; }
        public string AlterEgos { get; set; }
        public List<string> Aliases { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FirstAppearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }

    public class AppearanceApiResponse
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<string> Height { get; set; }  
        public List<string> Weight { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
    }

    public class WorkApiResponse
    {
        public string Occupation { get; set; }
        public string Base { get; set; }
    }

    public class ConnectionsApiResponse
    {
        public string GroupAffiliation { get; set; }
        public string Relatives { get; set; }
    }

    public class ImageApiResponse
    {
        public string Url { get; set; }
    }
}
