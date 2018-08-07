using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExercicioWeb01.Models
{
    public class Alunos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome não pode ser vazio")]
        public string Nome { get; set; }

        public long CodigoMatricula { get; set; }

        [Range(0,10, ErrorMessage = "A nota deve ser de 0 a 10")]
        public decimal nota1 { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve ser de 0 a 10")]
        public decimal nota2 { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve ser de 0 a 10")]
        public decimal nota3 { get; set; }

        public int frequencia { get; set; }
    }
}