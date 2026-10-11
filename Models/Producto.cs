using System.ComponentModel.DataAnnotations;

namespace ProductoMVC.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0.01, 9999999.99, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El Stock no puede ser negativo")]
        public int Stock { get; set; }

        public DateTime FechaCreacion { get; set;}
    }
}