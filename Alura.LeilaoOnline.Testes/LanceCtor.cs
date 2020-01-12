using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Testes
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            var mgnExcecao = "Valor do lançe não pode ser negativo";
            var excecaoObtida = Assert.Throws<System.ArgumentException>( 
                     () => new Lance(null, valorNegativo)
                 );
            Assert.Equal(mgnExcecao, excecaoObtida.Message);
        }
    }
}
