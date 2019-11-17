using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABMWebMVC.Models.ViewModels
{
    public class PersonaViewModel
    {
        [Required]
        public int DNI { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(20)]
        public string Apellido { get; set; }
        //[Required]
        [Display(Name = "Mail")]
        [StringLength(50)]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
    }

}