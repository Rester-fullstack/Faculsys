using System.ComponentModel.DataAnnotations;

namespace FaculSys.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Curso { get; set; }

        public ICollection<Matricula>? Matriculas { get; set; }
    }
}
