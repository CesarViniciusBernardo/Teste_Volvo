using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CadastroCaminhao.CustomValidation;

namespace CadastroCaminhao.Models
{
    public class Caminhao
    {
        //Classe modelo para o objeto Caminhao.
        [Required]
        public int Id { get; set; }

        [Required]
        [ModeloValidate(Allowed = new string[] { "FH", "FM" }, ErrorMessage = "O Modelo é invalido.")]
        public string Modelo { get; set; }

        [Required]
        public int AnoFabricacao { get; set; }

        [Required]
        public int AnoModelo { get; set; }

    }
}
