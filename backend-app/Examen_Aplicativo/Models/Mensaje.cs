using System;
using System.ComponentModel.DataAnnotations;

namespace Examen_Aplicativo.Models
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }

        public string? Texto { get; set; }

        public DateTime Fecha { get; set; } 
    }
}
