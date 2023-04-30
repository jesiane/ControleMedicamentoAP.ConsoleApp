﻿using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ControleMedicamentoAP.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase
    {
        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor) 
        {
            repositorioBase = repositorioFornecedor;
            nomeEntidade = "Fornecedor";
            sufixo = "es";
        }  
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|", "ID", "Nome", "Telefone");
            Console.WriteLine("----------------------------------------------------");
            foreach(Fornecedor fornecedor in registros)
            {
                Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|", fornecedor.id,fornecedor.nome,fornecedor.telefone);  }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone");
            string telefone = Console.ReadLine();
            Console.Write("Digite o email");
            string email = Console.ReadLine();
            Console.Write("Digite a cidade");
            string cidade = Console.ReadLine(); 
            Console.Write("Digite o estado");
            string estado = Console.ReadLine();

           return new Fornecedor(nome, telefone, email, cidade, estado);
        }
    }
}
