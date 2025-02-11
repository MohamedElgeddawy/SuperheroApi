using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SuperheroApi.Core.Models
{
    public class Superhero
    {
        public string? Response { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public PowerStats Powerstats { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }

    public class PowerStats
    {
        public string Intelligence { get; set; }
        public string Strength { get; set; }
        public string Speed { get; set; }
        public string Durability { get; set; }
        public string Power { get; set; }
        public string Combat { get; set; }
    }

    public class Biography
    {
        public string? FullName { get; set; }
        public string? AlterEgos { get; set; }
        public List<string>? Aliases { get; set; }
        public string? PlaceOfBirth { get; set; }

        // ✅ Allow NULL values
        public string? FirstAppearance { get; set; }

        public string? Publisher { get; set; }
        public string? Alignment { get; set; }
    }


    public class Appearance
    {
        public string? EyeColor { get; set; }
        public string? HairColor { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }

        // Store List<string> as JSON
        [Column(TypeName = "nvarchar(max)")]
        public string Height { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Weight { get; set; }

        // Convert List<string> to JSON before saving to DB
        public List<string> GetHeightList() => string.IsNullOrEmpty(Height) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(Height);
        public void SetHeightList(List<string> heights) => Height = JsonSerializer.Serialize(heights);

        public List<string> GetWeightList() => string.IsNullOrEmpty(Weight) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(Weight);
        public void SetWeightList(List<string> weights) => Weight = JsonSerializer.Serialize(weights);
    }



    public class Work
    {
        public string Occupation { get; set; }
        public string Base { get; set; }
    }

    public class Connections
    {
        public string GroupAffiliation { get; set; }
        public string Relatives { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }
}
