using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPrueba.Models
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = " El Codigo es obligatorio")]
        public int Codigo{ get; set; }

        [Required(ErrorMessage =" El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Este Campo se refiere si esta vigente o no")]
        public bool Estado { get; set; }

    }
}
