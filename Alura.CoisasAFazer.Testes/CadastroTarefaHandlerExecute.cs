using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastroTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveIncluirNoBanco()
        {
            //Arrange
            var titulo = "Estudar XUnit";
            var categoria = new Categoria("Estudo");
            var dataTarega = new DateTime(2019, 12, 31);
            var comando = new CadastraTarefa(titulo, categoria, dataTarega);

            var repo = new RepositorioFake();

            var handler = new CadastraTarefaHandler(repo);
            //Act
            handler.Execute(comando);

            //Assert
            var tarefas = repo.ObtemTarefas(t => t.Titulo == "Estudar XUnit").FirstOrDefault();
            Assert.NotNull(tarefas);
        }
    }
}
