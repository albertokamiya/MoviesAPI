using System;
using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos
{
    public class ReadSessionDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public DateTime EndSession { get; set; }
        public DateTime BeginSession { get; set; }
    }
}
