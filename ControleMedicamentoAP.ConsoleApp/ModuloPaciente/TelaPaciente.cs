using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase
    {
        public TelaPaciente(RepositorioPaciente repositoriopaciente) 
        { 
            this.repositorioBase = repositoriopaciente;
            nomeEntidade = "Paciente";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("  {0,-10}{1,-20}{2,-20 }", "id", "Nome", "Cartão SUS");
            Console.WriteLine("--------------------------------------------------------");

            foreach (Paciente paciente in registros)
            {
                Console.WriteLine("  {0,-10}{1,-20}{2,-20 }", paciente.id, paciente.nome, paciente.cartaosus);
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();


            Console.WriteLine("Digite o numero do cartão SUS: ");
            string cartaosus = Console.ReadLine();

            return new Paciente(nome, cartaosus);
        }
    }
}
