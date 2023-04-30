using ControleMedicamentoAP.ConsoleApp.Compartilhado;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
using ControleMedicamentoAP.ConsoleApp.ModuloPaciente;
using ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoSaida
{
    public class TelaRequisicaoSaida : TelaBase
    {
        private RepositorioRequisicaoSaida repositorioRequisicaoSaida;
        private RepositorioPaciente repositorioPaciente;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMedicamento repositorioMedicamento;

        private TelaPaciente telaPaciente;
        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;

        public TelaRequisicaoSaida(RepositorioRequisicaoSaida repositorioRequisicaoSaida,
            RepositorioFuncionario repositorioFuncionario,
            RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente,
            
            TelaFuncionario telaFuncionario, 
            TelaMedicamento telaMedicamento,
            TelaPaciente telaPaciente)
        {
            this.repositorioBase = repositorioRequisicaoSaida;
         //   this.repositorioRequisicaoSaida = repositorioRequisicaoSaida;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioPaciente = repositorioPaciente;

            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
            this.telaPaciente = telaPaciente;

            nomeEntidade = "Requisição de Saida";
        }

        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            // Desfazer a alteração a quantidade medicamento;

            RequisicaoSaida requisicaoSaida = (RequisicaoSaida)repositorioRequisicaoSaida.SelecionarPorId(id);

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);

        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida requisicaoSaida = (RequisicaoSaida)repositorioRequisicaoSaida.SelecionarPorId(id);

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);

        }
        protected override void MostrarTabela(ArrayList registros)
        {

            Console.WriteLine("{0,-10}{1,-10}{2,-20}{3 ,-20}{4,-20}{5 ,-20}", "id", "Data", "Medicamento", "Fornecedor", "Paciente", "Quantidade");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (RequisicaoSaida requisicaoSaida in registros)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-20}{3 ,-20}{4,-20}{5 ,-20}",
                    requisicaoSaida.id,
                    requisicaoSaida.data.ToShortDateString(),
                    requisicaoSaida.medicamento.nome,
                    requisicaoSaida.medicamento.fornecedor.nome,
                    requisicaoSaida.paciente.nome,  
                    requisicaoSaida.quantidade);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {

            // ctrl + . = extrair metodo (refato rar)

            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Paciente paciente = ObterPaciente();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoSaida(medicamento, quantidade, data, funcionario, paciente);

        }

        private Paciente ObterPaciente()
        {

            //Visualizar a lista de funcionarios
            telaPaciente.VisualizarRegistros(false);

            //Selecionar um funcionarios por id
            Console.Write("Digite o id do funcionario");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de funcionarios a partir do id seleciomnado
            Paciente paciente = (Paciente)repositorioPaciente.SelecionarPorId(idPaciente);
            return paciente;

        }

        private Funcionario ObterFuncionario()
        {

            //Visualizar a lista de funcionarios
            telaFuncionario.VisualizarRegistros(false);

            //Selecionar um funcionarios por id
            Console.Write("Digite o id do funcionario");
            int idfuncionario = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de funcionarios a partir do id seleciomnado
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(idfuncionario);
            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {

            //Visualizar a lista de medicamentos
            telaMedicamento.VisualizarRegistros(false);

            //Selecionar um medicamento por id
            Console.Write("Digite o id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de medicamento a partir do id seleciomnado
            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);
            return medicamento;

        }
    }
}
