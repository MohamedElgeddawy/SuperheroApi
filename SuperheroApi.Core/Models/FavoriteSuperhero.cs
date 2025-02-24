using SuperheroApi.Core.Models;
using SuperheroApi.Core.Models.Superhero;

namespace SuperheroApi.Models
{
    public class FavoriteSuperhero
    {
        public int Id { get; set; }  
        public int SuperheroId { get; set; }  
        public string SuperheroName { get; set; }  
        public Superhero Superhero { get; set; }

       
    }

}
