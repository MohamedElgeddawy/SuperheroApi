namespace SuperheroApi.Models
{
    // Represents a favorite superhero with a reference to the Superhero entity
    public class FavoriteSuperhero
    {
        public int Id { get; set; }
        public int SuperheroId { get; set; }
        public Superhero Superhero { get; set; }
    }
}
