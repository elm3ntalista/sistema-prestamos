using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaPrestamos.Models
{
    public class ReciboCobro
    {
        [Key]
        public int ReciboCobroId { get; set; }

        [ForeignKey("Prestamo")]
        [Required(ErrorMessage = "El préstamo es obligatorio.")]
        [Display(Name = "Préstamo")]
        public int PrestamoId { get; set; }

        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha del pago es obligatoria.")]
        [Display(Name = "Fecha Pago")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El monto a pagar es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        [Display(Name = "Monto a Pagar")]
        public decimal MontoPagado { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Monto Capital Aplicado")]
        public decimal MontoCapital { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Monto Interés Aplicado")]
        public decimal MontoInteres { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Saldo Actual (Préstamo)")]
        public decimal SaldoActual { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Método Pago")]
        public required string MetodoPago { get; set; }

        [StringLength(100)]
        [Display(Name = "Número Transacción/Referencia")]
        public string? NumeroTransaccion { get; set; }

        [StringLength(255)]
        [Display(Name = "Notas")]
        public string? Notas { get; set; }

        [Display(Name = "Préstamo Relacionado")]
        public Prestamo? Prestamo { get; set; }
        [Display(Name = "Cliente Relacionado")]
        public Cliente? Cliente { get; set; }
    }
}