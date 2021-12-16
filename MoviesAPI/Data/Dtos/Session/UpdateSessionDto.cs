using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateSessionDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
    }
}
