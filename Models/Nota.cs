using System.ComponentModel.DataAnnotations;

namespace FaculSys.Models
{
    public class Nota
    {
        public int Id { get; set; }

        [Required]
        public int MatriculaId { get; set; }
        public Matricula? Matricula { get; set; }

        public double Nota1 { get; set; }
        public double Nota2 { get; set; }

        public double Media => (Nota1 + Nota2) / 2;
    }
}
