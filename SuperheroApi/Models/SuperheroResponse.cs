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


    // Mapping method
    public Superhero MapApiResponseToSuperhero(SuperheroResponse apiResponse)
    {
        return new Superhero
        {
            // Do not set the Id here
            Name = apiResponse.Name ?? string.Empty,
            Powerstats = new Powerstats
            {
                Intelligence = int.Parse(apiResponse.Powerstats.Intelligence ?? "0"),
                Strength = int.Parse(apiResponse.Powerstats.Strength ?? "0"),
                Speed = int.Parse(apiResponse.Powerstats.Speed ?? "0"),
                Durability = int.Parse(apiResponse.Powerstats.Durability ?? "0"),
                Power = int.Parse(apiResponse.Powerstats.Power ?? "0"),
                Combat = int.Parse(apiResponse.Powerstats.Combat ?? "0")
            },
            Biography = new Biography
            {
                FullName = apiResponse.Biography.FullName ?? string.Empty,
                AlterEgos = apiResponse.Biography.AlterEgos ?? string.Empty,
                Aliases = apiResponse.Biography.Aliases ?? new List<string>(),
                PlaceOfBirth = apiResponse.Biography.PlaceOfBirth ?? string.Empty,
                FirstAppearance = apiResponse.Biography.FirstAppearance ?? string.Empty,
                Publisher = apiResponse.Biography.Publisher ?? string.Empty,
                Alignment = apiResponse.Biography.Alignment ?? string.Empty
            },
            Appearance = new Appearance
            {
                Gender = apiResponse.Appearance.Gender ?? string.Empty,
                Race = apiResponse.Appearance.Race ?? string.Empty,
                Height = apiResponse.Appearance.Height ?? new List<string>(),
                Weight = apiResponse.Appearance.Weight ?? new List<string>(),
                EyeColor = apiResponse.Appearance.EyeColor ?? string.Empty,
                HairColor = apiResponse.Appearance.HairColor ?? string.Empty
            },
            Work = new Work
            {
                Occupation = apiResponse.Work.Occupation ?? string.Empty,
                Base = apiResponse.Work.Base ?? string.Empty
            },
            Connections = new Connections
            {
                GroupAffiliation = apiResponse.Connections.GroupAffiliation ?? string.Empty,
                Relatives = apiResponse.Connections.Relatives ?? string.Empty
            },
            Image = new Image
            {
                Url = apiResponse.Image.Url ?? string.Empty
            }
        };
    }

    //public Superhero ToSuperhero()
    // {
    //     if (!int.TryParse(Id, out int superheroId))
    //     {
    //         throw new Exception("Invalid superhero ID.");
    //     }

    //     if (!int.TryParse(Powerstats.Intelligence, out int intelligence))
    //     {
    //         throw new Exception("Invalid Intelligence value.");
    //     }

    //     if (!int.TryParse(Powerstats.Strength, out int strength))
    //     {
    //         throw new Exception("Invalid Strength value.");
    //     }

    //     return new Superhero
    //     {
    //         Id = superheroId,
    //         Name = Name,
    //         Powerstats = new Powerstats
    //         {
    //             Intelligence = intelligence,
    //             Strength = strength,
    //             Speed = int.Parse(Powerstats.Speed),
    //             Durability = int.Parse(Powerstats.Durability),
    //             Power = int.Parse(Powerstats.Power),
    //             Combat = int.Parse(Powerstats.Combat),
    //             SuperheroId = superheroId
    //         },
    //         Biography = new Biography
    //         {
    //             FullName = Biography.FullName,
    //             AlterEgos = Biography.AlterEgos,
    //             Aliases = Biography.Aliases,
    //             PlaceOfBirth = Biography.PlaceOfBirth,
    //             FirstAppearance = Biography.FirstAppearance,
    //             Publisher = Biography.Publisher,
    //             Alignment = Biography.Alignment,
    //             SuperheroId = superheroId
    //         },
    //         Appearance = new Appearance
    //         {
    //             Gender = Appearance.Gender,
    //             Race = Appearance.Race,
    //             Height = Appearance.Height,
    //             Weight = Appearance.Weight,
    //             EyeColor = Appearance.EyeColor,
    //             HairColor = Appearance.HairColor,
    //             SuperheroId = superheroId
    //         },
    //         Work = new Work
    //         {
    //             Occupation = Work.Occupation,
    //             Base = Work.Base,
    //             SuperheroId = superheroId
    //         },
    //         Connections = new Connections
    //         {
    //             GroupAffiliation = Connections.GroupAffiliation,
    //             Relatives = Connections.Relatives,
    //             SuperheroId = superheroId
    //         },
    //         Image = new Image
    //         {
    //             Url = Image.Url,
    //             SuperheroId = superheroId
    //         }
    //     };
    // }


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

