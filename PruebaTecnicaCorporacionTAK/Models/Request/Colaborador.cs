using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaCorporacionTAK.Models.Request
{
    public class Colaborador
    {
        public int IdColaborador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string  FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string GradoAcademico { get; set; }
        public string Direccion { get; set; }
    }
}