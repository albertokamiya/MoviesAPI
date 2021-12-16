using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime EndSesssion { get; set; }
    }
}
