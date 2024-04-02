using System;
using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAppMvc.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required(ErrorMessage="La descripción es requerida")]
        [Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Display(Name="COP")]
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        [Display(Name="Fecha de Alta")]
        public DateTime FechaDeAlta { get; set; }
    }
}