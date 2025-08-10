using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPrestamos.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Tipo Documento")]
        public required string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Número Documento")]
        public required string NumeroDocumento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200)]
        [Display(Name = "Dirección")]
        public required string Direccion { get; set; }

        [StringLength(100)]
        [Display(Name = "Ciudad")]
        public string? Ciudad { get; set; }

        [StringLength(100)]
        [Display(Name = "Provincia")]
        public string? Provincia { get; set; }

        [StringLength(10)]
        [Display(Name = "Código Postal")]
        public string? CodigoPostal { get; set; }

        [Required(ErrorMessage = "El teléfono principal es obligatorio.")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono Principal")]
        public required string TelefonoPrincipal { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono Opcional")]
        public string? TelefonoOpcional { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La ocupación es obligatoria.")]
        [StringLength(100)]
        [Display(Name = "Ocupación")]
        public required string Ocupacion { get; set; }

        [StringLength(255)]
        [Display(Name = "Notas Adicionales")]
        public string? NotasAdicionales { get; set; }
        public ICollection<Prestamo>? Prestamos { get; set; }
        public ICollection<ReciboCobro>? RecibosCobro { get; set; }
    }
}