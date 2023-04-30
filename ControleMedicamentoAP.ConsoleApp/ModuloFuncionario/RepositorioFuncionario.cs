using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario(ArrayList listaFuncionario)
        {
            this.listaRegistros = listaFuncionario; ;
        }
        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Funcionario)base.SelecionarPorId(id);
        }
    }
}
