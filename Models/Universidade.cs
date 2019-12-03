using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUniversitario.Models
{
    public class Universidade
    {
        public int? IdUniversidade { get; set; }
        
        [Display(Name="Nome")]
        [Required(ErrorMessage ="Campo nome obrigatório")]
        public string Nome { get; set; }

        public string Img { get; set; }

    }
}
