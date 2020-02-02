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
        public void DadosValidosDoFormularioENavegarParaProximaPagina()
        {
            //arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = _driver.FindElement(By.Id("Nome"));
            //email
            var inputEmail = _driver.FindElement(By.Id("Email"));
            //password
            var inputSenha = _driver.FindElement(By.Id("Password"));
            //confirmpassword
            var inputConfirmSenha = _driver.FindElement(By.Id("ConfirmPassword"));

            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Gustavo Bueno");
            inputEmail.SendKeys("gustavo@teste.com");
            inputSenha.SendKeys("123456");
            inputConfirmSenha.SendKeys("123456");
            //act
            botaoRegistro.Click();
            //assert
            Assert.Contains("Obrigado", _driver.PageSource);
        }
    }
}
