using System.ComponentModel.DataAnnotations;

namespace FaculSys.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public ICollection<Disciplina>? Disciplinas { get; set; }
    }
}
