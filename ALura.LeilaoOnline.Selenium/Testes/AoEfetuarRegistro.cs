using ALura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;
namespace ALura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private readonly IWebDriver _driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void Teste()
        {
            //arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");
            //act
            //assert
        }
    }
}
