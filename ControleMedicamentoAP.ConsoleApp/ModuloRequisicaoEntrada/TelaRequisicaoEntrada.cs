using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada
{
    public class TelaRequisicaoEntrada : TelaBase
    {
        private RepositorioRequisicaoEntrada repositorioRequisicaoEntrada;

        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMedicamento repositorioMedicamento;

        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;

        public TelaRequisicaoEntrada(RepositorioRequisicaoEntrada repositorioRequisicaoEntrada,
            RepositorioFuncionario repositorioFuncionario, RepositorioMedicamento repositorioMedicamento,
            TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento)
        {
            this.repositorioBase = repositorioRequisicaoEntrada;

            this.repositorioRequisicaoEntrada = repositorioRequisicaoEntrada;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisições de Entrada";
        }


        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

           int id = EncontrarId();

            // Desfazer a alteração a quantidade medicamento;

            RequisicaoEntrada requisicaoEntrada = (RequisicaoEntrada)repositorioRequisicaoEntrada.SelecionarPorId(id);

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoEntrada.DesfazerRegistroEntrada();


            if (TemErrosDeValidacao(registroAtualizado))
            {
                return;
            }
            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);

        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            int id = EncontrarId();

            RequisicaoEntrada requisicaoEntrada = (RequisicaoEntrada)repositorioRequisicaoEntrada.SelecionarPorId(id);

            requisicaoEntrada.DesfazerRegistroEntrada();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);

        }
        protected override void MostrarTabela(ArrayList registros)
        {
            //    Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}{4 ,-20}", "id", "Data", "Medicamento", "Fornecedor", "Quantidade");

            const string FORMATO_TABELA = "{0,-10}{1,-10}{2,-20}{3,-20}{4 ,-20}";

            Console.WriteLine(FORMATO_TABELA, "id", "Data", "Medicamento", "Fornecedor", "Quantidade");
            Console.WriteLine("---------------------------------------------------------------");
            foreach(RequisicaoEntrada requisicaoEntrada in registros)
            {
                //Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}{4 ,-20}", 
                //    requisicaoEntrada.id,
                //    requisicaoEntrada.data.ToShortDateString(),
                //    requisicaoEntrada.medicamento.nome,
                //    requisicaoEntrada.medicamento.fornecedor.nome,
                //    requisicaoEntrada.quantidade);
                
                Console.WriteLine(FORMATO_TABELA, 
                    requisicaoEntrada.id,
                    requisicaoEntrada.data.ToShortDateString(),
                    requisicaoEntrada.medicamento.nome,
                    requisicaoEntrada.medicamento.fornecedor.nome,
                    requisicaoEntrada.quantidade);

            }
        }
        
        protected override EntidadeBase ObterRegistro()
        {
            // ctrl + . = extrair metodo (refatorar)

            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoEntrada(medicamento, quantidade, data, funcionario);

        }

        private Funcionario ObterFuncionario()
        {
            //Visualizar a lista de funcionarios
            telaFuncionario.VisualizarRegistros(false);

            //Selecionar um funcionarios por id
            //*  Console.Write("Digite o id do funcionario");
            //*  int idfuncionario = Convert.ToInt32(Console.ReadLine());

            int id = EncontrarId();

            //Pegar o objeto no repositorio de funcionarios a partir do id seleciomnado
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(id);

            Console.WriteLine();

            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {
            //Visualizar a lista de medicamentos
            telaMedicamento.VisualizarRegistros(false);

            //Selecionar um medicamento por id
            //   Console.Write("Digite o id do medicamento: ");
            //   int idMedicamento = Convert.ToInt32(Console.ReadLine());

            int id = EncontrarId();

            //Pegar o objeto no repositorio de medicamento a partir do id seleciomnado
            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarPorId(id);
            return medicamento;
        }
    }
}
