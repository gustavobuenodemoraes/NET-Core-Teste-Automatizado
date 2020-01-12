using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        public enum EstadoLeilao
        {
            LeilaoAntesDoPregao,
            LeilaoEmAndamento,
            LeilaoFinalizado
        }

        private readonly IList<Lance> _lances;
        private Interessada _ultimoCliente;
        private IModalidadeAvaliacao _avaliador;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }


        public Leilao(string peca, IModalidadeAvaliacao avalidaor)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            _avaliador = avalidaor;
        }

        private bool LanceInvalido(Interessada cliente, double valor)
        {
            return (Estado != EstadoLeilao.LeilaoEmAndamento) || (cliente == _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (LanceInvalido(cliente, valor))
                return;

            _lances.Add(new Lance(cliente, valor));
            _ultimoCliente = cliente;

        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new System
                    .InvalidOperationException(
                        "Não é possível terminar o pregão sem que ele tenha começado.Para isso, Utilize o método IniciarPregao()"
                    );

            Ganhador = _avaliador.Avalia(this);

            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}