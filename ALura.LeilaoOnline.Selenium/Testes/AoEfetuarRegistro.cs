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

        [Theory]
        [InlineData("", "gustavo@teste.com", "123456", "123456")]
        [InlineData("Gustavo Bueno", "gustavo.com", "123456", "123456")]
        [InlineData("Gustavo Bueno", "gustavo@teste.com", "123456", "444788")]
        [InlineData("Gustavo Bueno", "gustavo@teste.com", "123456", "")]
        public void DadosInvalidosDoFormularioENavegarParaProximaPagina(
            string nome,
            string email,
            string senha,
            string confirmSenha)
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

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            //act
            botaoRegistro.Click();
            //assert
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();
            //assert
            IWebElement element = _driver.FindElement(By.CssSelector("span#Nome-error"));
            Assert.True(element.Displayed);
        }
    }
}
