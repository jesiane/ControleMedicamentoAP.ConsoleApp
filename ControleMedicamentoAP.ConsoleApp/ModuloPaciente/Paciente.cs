﻿using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        public string nome;
        public string cartaosus;

        public Paciente(string nome, string cartaosus)
        {
            this.nome = nome;
            this.cartaosus = cartaosus;
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            Paciente pacienteAtualizado = (Paciente)registroAtualizado;

            this.nome = pacienteAtualizado.nome;
            this.cartaosus = pacienteAtualizado.cartaosus;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(cartaosus.Trim()))
                erros.Add("O campo \"login\" é obrigatório");

          
            return erros;
        }
    }
}
