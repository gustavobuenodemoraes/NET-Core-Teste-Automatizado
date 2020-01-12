using System.Linq;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDoMesmoCliente()
        {
            //Arranje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);


            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert - resultado
            leilao.TerminaPregao();
            var numeroDeLances = leilao.Lances.Count();
            var valorEsperado = 1;

            Assert.Equal(valorEsperado, numeroDeLances);
        }

        [Theory]
        [InlineData(2, new double[] { 30, 40, 70, 20, 100 })]
        public void NaoPermiteNovosLancesDadosLeilaoFinalizado(
            double valorEsperado, double[] lances)
        {
            //Arranje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            var i = 0;

            leilao.IniciaPregao();

            for (; i < valorEsperado; i++)
            {
                var ofertante = i % 2 == 0 ? fulano : maria;
                leilao.RecebeLance(ofertante, lances[i]);
            }

            leilao.TerminaPregao();

            //Act - método sob teste

            for (; i < lances.Length; i++)
            {
                var ofertante = i % 2 == 0 ? fulano : maria;
                leilao.RecebeLance(ofertante, lances[i]);
            }

            //Assert - resultado
            var numeroDeLances = leilao.Lances.Count();

            Assert.Equal(valorEsperado, numeroDeLances);
        }
    }
}
