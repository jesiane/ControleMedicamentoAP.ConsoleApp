using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
using ControleMedicamentoAP.ConsoleApp.ModuloPaciente;
using ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoSaida
{
    public class RequisicaoSaida : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;

        public Paciente paciente;

        public RequisicaoSaida(Medicamento medicamento, int quantidade ,DateTime data, Funcionario funcionario, Paciente paciente)
        {
            this.medicamento = medicamento;
            this.data = data;
            this.funcionario = funcionario;
            this.paciente = paciente;
            this.quantidade = quantidade;
            this.medicamento.RemoverQuantidade(quantidade);
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            RequisicaoSaida requisicaoSaidaAtualizada = (RequisicaoSaida)registroAtualizado;

            this.medicamento = requisicaoSaidaAtualizada.medicamento;
            this.quantidade = requisicaoSaidaAtualizada.quantidade;
            this.data = requisicaoSaidaAtualizada.data;
            this.funcionario = requisicaoSaidaAtualizada.funcionario;
            this.paciente = requisicaoSaidaAtualizada .paciente; 
        }

        internal void DesfazerRegistroSaida()
        {

            medicamento.AdicionarQuantidade(quantidade);

        }
    }
}
