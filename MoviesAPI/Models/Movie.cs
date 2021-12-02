using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório.")]
        public string Director { get; set; }
        [StringLength(50, ErrorMessage = "Não pode ultrapassar 50 caracteres.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "O campo duração é obrigatório.")]
        [Range(1,600, ErrorMessage = "A duração deve ser entre 1 a 600 minutos.")]
        public int Duration { get; set; }
    }
}
