using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descrição;
        public string lote;
        public DateTime validade ;
        public int quantidade ;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descrição, string lote, DateTime validade, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descrição = descrição;
            this.lote = lote;
            this.validade = validade;
            this.fornecedor = fornecedor;
        }

        public override void AtualizarInformações(EntidadeBase registroAtualizado)
        {
            Medicamento medicamentoAtualizado = (Medicamento)registroAtualizado;

            this.nome = medicamentoAtualizado.nome;
            this.descrição = medicamentoAtualizado.descrição;
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
    }
}
