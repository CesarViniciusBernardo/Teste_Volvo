using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCaminhao.Models;

namespace CadastroCaminhao.Negocio
{
    public class CaminhaoNegocio
    {
        public bool ValidarModeloCaminhao(Caminhao caminhao)
        {
            if (caminhao.Modelo.Equals("FM"))
                return true;
            if (caminhao.Modelo.Equals("FH"))
                return true;
            return false;
        }

        public bool ValidarAnoModelo(Caminhao caminhao)
        {
            if (caminhao.AnoModelo == caminhao.AnoFabricacao)
                return true;
            if (caminhao.AnoModelo == (caminhao.AnoFabricacao + 1))
                return true;
            return false;
        }
    }
}
