using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public RepositorioFornecedor(ArrayList listaFornecedor)
        {
            this.listaRegistros = listaFornecedor;
        }


    }
}
