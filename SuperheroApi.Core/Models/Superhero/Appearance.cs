using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SuperheroApi.Core.Models.Superhero
{
    public class Appearance
    {
        public string? EyeColor { get; set; }
        public string? HairColor { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Height { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Weight { get; set; }

        public List<string> GetHeightList() => string.IsNullOrEmpty(Height) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(Height);
        public void SetHeightList(List<string> heights) => Height = JsonSerializer.Serialize(heights);

        public List<string> GetWeightList() => string.IsNullOrEmpty(Weight) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(Weight);
        public void SetWeightList(List<string> weights) => Weight = JsonSerializer.Serialize(weights);
    }
}
