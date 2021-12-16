using System;

namespace MoviesAPI.Data.Dtos
{
    public class CreateSessionDto
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime EndSession { get; set; }
    }
}
