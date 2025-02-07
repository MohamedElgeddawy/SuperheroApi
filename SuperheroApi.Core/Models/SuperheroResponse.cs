public class SuperheroResponse
{
    public string Response { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public PowerstatsResponse Powerstats { get; set; }
    public BiographyResponse Biography { get; set; }
    public AppearanceResponse Appearance { get; set; }
    public WorkResponse Work { get; set; }
    public ConnectionsResponse Connections { get; set; }
    public ImageResponse Image { get; set; }
    public List<SuperheroResponse> Results { get; set; }
}

public class PowerstatsResponse
{
    public string Intelligence { get; set; }
    public string Strength { get; set; }
    public string Speed { get; set; }
    public string Durability { get; set; }
    public string Power { get; set; }
    public string Combat { get; set; }
}

public class BiographyResponse
{
    public string FullName { get; set; }
    public string AlterEgos { get; set; }
    public List<string> Aliases { get; set; }
    public string PlaceOfBirth { get; set; }
    public string FirstAppearance { get; set; }
    public string Publisher { get; set; }
    public string Alignment { get; set; }
}

public class AppearanceResponse
{
    public string Gender { get; set; }
    public string Race { get; set; }
    public List<string> Height { get; set; }
    public List<string> Weight { get; set; }
    public string EyeColor { get; set; }
    public string HairColor { get; set; }
}

public class WorkResponse
{
    public string Occupation { get; set; }
    public string Base { get; set; }
}

public class ConnectionsResponse
{
    public string GroupAffiliation { get; set; }
    public string Relatives { get; set; }
}

public class ImageResponse
{
    public string Url { get; set; }
}

