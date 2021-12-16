using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public Address Address { get; set; }
        public Manager Manager { get; set; }

    }
}
