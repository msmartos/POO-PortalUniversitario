using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUniversitario.Models
{
    public class Unidade
    {
        public int IdUnidade { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string CNPJ { get; set; }

        public string Site { get; set; }

        public int IdUniv { get; set; }

        public string Universidade { get; set; }

        public string Img { get; set; }
    }
}
