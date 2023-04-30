using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoSaida
{
    public class RepositorioRequisicaoSaida : RepositorioBase
    {
        public RepositorioRequisicaoSaida(ArrayList listaRequisicaoSaida)
        {
            this.listaRegistros = listaRequisicaoSaida;
        }

        public override RequisicaoSaida SelecionarPorId(int id)
        {
            return (RequisicaoSaida)base.SelecionarPorId(id);
        }
    }
}
