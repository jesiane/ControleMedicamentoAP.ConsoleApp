using ControleMedicamentoAP.ConsoleApp.ModuloFornecedor;
using ControleMedicamentoAP.ConsoleApp.ModuloFuncionario;
using ControleMedicamentoAP.ConsoleApp.ModuloMedicamento;
 using ControleMedicamentoAP.ConsoleApp.ModuloPaciente;
using ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoEntrada;
using ControleMedicamentoAP.ConsoleApp.ModuloRequisicaoSaida;
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());
            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada(new ArrayList());
            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida(new ArrayList());

            CadastrarRegistros(repositorioFuncionario, repositorioFornecedor, repositorioMedicamento, repositorioPaciente,repositorioRequisicaoEntrada);

            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, telaFornecedor, repositorioFornecedor);
            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicaoEntrada, repositorioFuncionario,
                repositorioMedicamento, telaFuncionario, telaMedicamento);
            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida,repositorioFuncionario,
                repositorioMedicamento,repositorioPaciente, telaFuncionario,telaMedicamento,telaPaciente);
            

            TelaPrincipal principal = new TelaPrincipal();
            while (true)
            {
                string opc = principal.ApresentarMenu();
                if (opc == "s")
                    break;

                if (opc == "1")
                {
                    string submenu = telaFornecedor.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaFornecedor.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaFornecedor.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaFornecedor.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaFornecedor.ExcluirRegistro();
                    }
                }


                else if (opc == "2")
                {
                    string submenu = telaFuncionario.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }

                else if (opc == "3")
                {
                    string submenu = telaPaciente.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaPaciente.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaPaciente.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaPaciente.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaPaciente.ExcluirRegistro();
                    }
                }

                else if (opc == "4")
                {
                    string submenu = telaMedicamento.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaMedicamento.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaMedicamento.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaMedicamento.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaMedicamento.ExcluirRegistro();
                    }
                    else if (submenu == "5")
                    {
                        telaMedicamento.VisualizarMedicamentosMaisRetirados();
                    }
                    else if (submenu == "6")
                    {
                        telaMedicamento.VisualizarMedicamentosEmFalta();
                    }
                }

                else if (opc == "5")
                {
                    string submenu = telaRequisicaoEntrada.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaRequisicaoEntrada.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaRequisicaoEntrada.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaRequisicaoEntrada.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaRequisicaoEntrada.ExcluirRegistro();
                    }

                }

                else if (opc == "6")
                {
                    string submenu = telaRequisicaoSaida.ApresentarMenu();
                    if (submenu == "1")
                    {
                        telaRequisicaoSaida.InserirNovoRegistro();
                    }
                    else if (submenu == "2")
                    {
                        telaRequisicaoSaida.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (submenu == "3")
                    {
                        telaRequisicaoSaida.EditarRegistro();
                    }
                    else if (submenu == "4")
                    {
                        telaRequisicaoSaida.ExcluirRegistro();
                    }
                }
            }
         }

            private static void CadastrarRegistros(
            RepositorioFuncionario repositorioFuncionario,
            RepositorioFornecedor repositorioFornecedor,
            RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente,
            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada)
            {
                Funcionario funcionario1 = new Funcionario("Jesiane S", "oliver", "456");
                Funcionario funcionario2 = new Funcionario("floquinho", "dog", "123");

                repositorioFuncionario.Inserir(funcionario1);
                repositorioFuncionario.Inserir(funcionario2);

                Fornecedor fornecedor1 = new Fornecedor("Generico", "123456789", "kk.kk@kk", "Lages", "SC");
                Fornecedor fornecedor2 = new Fornecedor("aqui", "123456789", "kk.kk@kk", "Lages", "SC");

                repositorioFornecedor.Inserir(fornecedor1);
                repositorioFornecedor.Inserir(fornecedor2);

                Medicamento medicamento1 = new Medicamento("Pondera", "anti depressivo", "987654321", new DateTime(2020, 01, 02), fornecedor1);
                Medicamento medicamento2 = new Medicamento("fluoroxetina", "anti depressivo", "987654321", new DateTime(2020, 01, 30), fornecedor2);
                
                repositorioMedicamento.Inserir(medicamento1);
                repositorioMedicamento.Inserir(medicamento2);

                Paciente paciente1 = new Paciente("José", "123456789");
                Paciente paciente2 = new Paciente("Maria", "987654321");
                Paciente paciente3 = new Paciente("Luis", "951736842");
                Paciente paciente4 = new Paciente("Marlene", "132896574");

                repositorioPaciente.Inserir(paciente1);
                repositorioPaciente.Inserir(paciente2);
                repositorioPaciente.Inserir(paciente3);
                repositorioPaciente.Inserir(paciente4);

            RequisicaoEntrada requisicaoEntrada1 = new RequisicaoEntrada(medicamento2,10,DateTime.Now,funcionario1);
            RequisicaoEntrada requisicaoEntrada2 = new RequisicaoEntrada(medicamento1,5,DateTime.Now,funcionario2);

            repositorioRequisicaoEntrada.Inserir(requisicaoEntrada1);
            repositorioRequisicaoEntrada.Inserir(requisicaoEntrada2);



        
        }

    }
}