using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(2, new double[] { 30, 40, 70, 20, 100 })]
        public void NaoPermiteNovosLancesDadosLeilaoFinalizado(
            double valorEsperado, double[] lances)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            var i = 0;

            leilao.IniciaPregao();

            for (; i < valorEsperado; i++)
            {
                leilao.RecebeLance(fulano, lances[i]);
            }

            leilao.TerminaPregao();

            //Act - método sob teste

            for (; i < lances.Length; i++)
            {
                leilao.RecebeLance(fulano, lances[i]);
            }

            //Assert - resultado
            var numeroDeLances = leilao.Lances.Count();

            Assert.Equal(valorEsperado, numeroDeLances);
        }
    }
}
