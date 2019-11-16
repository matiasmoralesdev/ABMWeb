using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMWebMVC.Models.ViewModels
{
    public class PersonaLViewModel
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}