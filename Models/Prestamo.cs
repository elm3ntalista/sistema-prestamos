using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPrestamos.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }

        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El monto principal es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        [Display(Name = "Monto Principal")]
        public decimal MontoPrincipal { get; set; }

        [Required(ErrorMessage = "La tasa de interés es obligatoria.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0.01, 100.00, ErrorMessage = "La tasa de interés debe ser entre 0.01 y 100.")]
        [Display(Name = "Tasa Interés Anual (%)")]
        public decimal TasaInteresAnual { get; set; }

        [Required(ErrorMessage = "El plazo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El plazo debe ser al menos 1.")]
        [Display(Name = "Plazo (Meses)")]
        public int PlazoMeses { get; set; }

        [Required(ErrorMessage = "La frecuencia de pago es obligatoria.")]
        [StringLength(50)]
        [Display(Name = "Frecuencia Pago")]
        public required string FrecuenciaPago { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Fin Prevista")]
        public DateTime? FechaFinPrevista { get; set; }

        [Required(ErrorMessage = "La tasa de mora es obligatoria.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0.00, 100.00, ErrorMessage = "La tasa de mora debe ser entre 0 y 100.")]
        [Display(Name = "Tasa Interés Mora Anual (%)")]
        public decimal TasaInteresMoraAnual { get; set; }

        [Required(ErrorMessage = "El estado del préstamo es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public required string Estado { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Saldo Pendiente")]
        public decimal SaldoPendiente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Último Pago")]
        public DateTime? FechaUltimoPago { get; set; }

        [StringLength(255)]
        [Display(Name = "Términos Adicionales")]
        public string? TerminosAdicionales { get; set; }

        [Display(Name = "Cliente")]
        public Cliente? Cliente { get; set; }
        public ICollection<ReciboCobro>? RecibosCobro { get; set; }
    }
}