using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada
{
    public class RepositorioRequisicaoEntrada : RepositorioBase
    { 
    public RepositorioRequisicaoEntrada(ArrayList listaRequisicaoEntrada)
        {
            this.listaRegistros = listaRequisicaoEntrada;
        }

        public override RequisicaoEntrada SelecionarPorId(int id)
        {
            return (RequisicaoEntrada)base.SelecionarPorId(id);
        }
    }
}
