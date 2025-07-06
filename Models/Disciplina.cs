using System.ComponentModel.DataAnnotations;

namespace FaculSys.Models
{
    public class Disciplina
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        public ICollection<Matricula>? Matriculas { get; set; }
    }
}
