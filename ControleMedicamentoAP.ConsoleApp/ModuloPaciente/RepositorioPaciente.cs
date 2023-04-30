using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase 
    {
        public RepositorioPaciente(ArrayList listaPaciente)
        {
            this.listaRegistros = listaPaciente;
        }
        public override Paciente SelecionarPorId(int id)
        {
            return (Paciente)base.SelecionarPorId(id);
        }
    }

}
