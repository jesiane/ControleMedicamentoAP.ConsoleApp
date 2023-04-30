using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;
using System.ComponentModel;

namespace ControleMedicamentoAP.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBase = repositorioFuncionario;
            nomeEntidade = "Funcionario";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0,-10}{1,-29}{2,-20}" , "id", "Nome", "Login");
            Console.WriteLine("---------------------------------------------------");
            foreach (Funcionario funcionario in registros) 
            {
                Console.WriteLine("{0,-10}{1,-29}{2,-20}", funcionario.id, funcionario.nome,funcionario.login);
            }
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string senha = Console.ReadLine();

            return new Funcionario(nome, login, senha);

        }
    } 
}
