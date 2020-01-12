using ALura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using Xunit;

namespace ALura.LeilaoOnline.Selenium
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome : IClassFixture<TestFixture>
    {
        private readonly IWebDriver _driver;

        //Setup
        public AoNavegarParaHome(TestFixture testFixture)
        {
            _driver = testFixture.Driver;
        }

        [Fact]
        public void ChromeAbertoConterLeilaoNoTitulo()
        {
            //arrange

            //act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", _driver.Title);
        }

        [Fact]
        public void ChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
