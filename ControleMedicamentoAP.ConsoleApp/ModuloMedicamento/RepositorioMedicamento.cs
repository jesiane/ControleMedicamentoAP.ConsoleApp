using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase
    {
        public RepositorioMedicamento(ArrayList listaMedicamento)
        {
            this.listaRegistros = listaMedicamento;
        }
        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Medicamento)base.SelecionarPorId(id);
        }
        public ArrayList SelecionarMedicamentosMaisRetirados()
        {
            //fazer a ordenação
            return this.listaRegistros;
        }
        public ArrayList SelecionarMedicamentosEmFalta()
        {
            return this.listaRegistros;
        }
    } 
}
