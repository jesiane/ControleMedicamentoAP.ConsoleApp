using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada
{
    public class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;

        public RequisicaoEntrada(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario)
        {
            this.medicamento = medicamento;
            this.quantidade = quantidade;
            this.data = data;
            this.funcionario = funcionario;

            this.medicamento.AdicionarQuantidade(quantidade);
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            RequisicaoEntrada requisicaoEntradaAtualizada = (RequisicaoEntrada)registroAtualizado;

            this.medicamento = requisicaoEntradaAtualizada.medicamento;
            this.quantidade = requisicaoEntradaAtualizada.quantidade;
            this.data = requisicaoEntradaAtualizada.data;
            this.funcionario = requisicaoEntradaAtualizada.funcionario;
        }

        internal void DesfazerRegistroEntrada()
        {
            medicamento.RemoverQuantidade(quantidade);
        } 
    }
}
