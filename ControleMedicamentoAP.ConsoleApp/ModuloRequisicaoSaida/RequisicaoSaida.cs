using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
using ControleMedicamentoAP.ConsoleApp.ModuloPaciente;

using System.Collections;

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

        public void RegistrarSaida()
        {
            this.medicamento.RemoverQuantidade(quantidade);
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (medicamento == null)
                erros.Add("O campo \" medicamento \" é obrigatório");

            if (funcionario == null)
                erros.Add("O campo \"funcionario\" é obrigatório");

            if (paciente == null)
                erros.Add("O campo \"paciente\" é obrigatório");

            if (data < DateTime.Now.Date)
                erros.Add("O campo \"data\" é obrigatório");

            if (quantidade < 0)
                erros.Add("O campos \"quantidade\" deve ser maior que zero");

            if (medicamento != null  & quantidade > medicamento.quantidade)
                erros.Add("O campo \" quantidade requisitada\" exedeu a quantidade em estoque");

            return erros;

        }

    }
}
