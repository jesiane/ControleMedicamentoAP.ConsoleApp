using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descricao;
        public string lote;
        public DateTime validade ;
        public int quantidade ;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descrição, string lote, DateTime validade, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricao = descrição;
            this.lote = lote;
            this.validade = validade;
            this.fornecedor = fornecedor;
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            Medicamento medicamentoAtualizado = (Medicamento)registroAtualizado;

            this.nome = medicamentoAtualizado.nome;
            this.descricao = medicamentoAtualizado.descricao;
            this.lote = medicamentoAtualizado.lote;
            this.validade = medicamentoAtualizado.validade;
            this.fornecedor = medicamentoAtualizado.fornecedor;

        }

        public void AdicionarQuantidade(int qtd)
        {
            this.quantidade += qtd;   
        }

        public void RemoverQuantidade(int qtd)
        {
            this.quantidade -= qtd; 
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            DateTime hoje = DateTime.Now.Date;

            if (validade < hoje)
                erros.Add("O campo \"validade\" não pode ser menor que a data atual");

            if (fornecedor == null)
                erros.Add("O campo \"fornecedor\" é obrigatório");

            if (quantidade < 0)
                erros.Add("O campo \"quantidade\" não pode ser menor que 0");

            return erros;

        }
    }
}
