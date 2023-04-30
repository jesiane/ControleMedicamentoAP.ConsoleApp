﻿using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string nome;
        public string login;
        public string senha;

        public Funcionario(string nome, string login, string senha)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome= funcionarioAtualizado.nome;
            this.login = funcionarioAtualizado.login;
            this.senha = funcionarioAtualizado.senha;
        }
    }
}
