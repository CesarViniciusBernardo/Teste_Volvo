using CadastroCaminhao.Models;
using CadastroCaminhao.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadastroCaminhaoUnitTestProject
{
    [TestClass]
    public class CaminhaoNegocioTests
    {
        [TestMethod]
        public void ValidarModeloCaminhao_FM_ReturnsTrue()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "FM",
                AnoFabricacao = 2020,
                AnoModelo = 2020
            };

            //Act
            var result = caminhaoNegocio.ValidarModeloCaminhao(caminhao);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarModeloCaminhao_FH_ReturnsTrue()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "FH",
                AnoFabricacao = 2020,
                AnoModelo = 2020
            };

            //Act
            var result = caminhaoNegocio.ValidarModeloCaminhao(caminhao);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarModeloCaminhao_XX_ReturnsFalse()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "XX",
                AnoFabricacao = 2020,
                AnoModelo = 2020
            };

            //Act
            var result = caminhaoNegocio.ValidarModeloCaminhao(caminhao);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidarAnoModelo_FabricacaoX_ModeloX_ReturnsTrue()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "FM",
                AnoFabricacao = 2020,
                AnoModelo = 2020
            };

            //Act
            var result = caminhaoNegocio.ValidarAnoModelo(caminhao);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarAnoModelo_FabricacaoX_ModeloXPlus1_ReturnsTrue()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "FM",
                AnoFabricacao = 2020,
                AnoModelo = 2021
            };

            //Act
            var result = caminhaoNegocio.ValidarAnoModelo(caminhao);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarAnoModelo_FabricacaoX_ModeloY_ReturnsTrue()
        {
            //Arrange
            var caminhaoNegocio = new CaminhaoNegocio();
            var caminhao = new Caminhao
            {
                Modelo = "FM",
                AnoFabricacao = 2020,
                AnoModelo = 2019
            };

            //Act
            var result = caminhaoNegocio.ValidarAnoModelo(caminhao);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
