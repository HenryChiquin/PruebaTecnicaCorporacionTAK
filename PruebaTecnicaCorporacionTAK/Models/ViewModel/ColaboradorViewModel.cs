using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCorporacionTAK.Models.ViewModel
{
    public class ColaboradorViewModel
    {
        public int IdColaborador { get; set; }

        [Required]
        [Display(Name ="Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Required]
        [Display(Name = "Grado Académico")]
        public string GradoAcademico { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
    }
}