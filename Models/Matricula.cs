using System.ComponentModel.DataAnnotations;

namespace FaculSys.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        [Required]
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        [Required]
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }

        public Nota? Nota { get; set; }
    }
}
