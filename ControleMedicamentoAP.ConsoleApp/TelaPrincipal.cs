namespace ControleMedicamentoAP.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenu() 
        {
            Console.Clear();
            Console.WriteLine("Controle Medicamento");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para fornecedor");
            Console.WriteLine("Digite 2 para funcionario");
            Console.WriteLine("Digite 3 para Paciente");
            Console.WriteLine("Digite 4 para Medicamento");

            Console.WriteLine("Digite 5 para Cadastrar Requisições de Entrada");
            Console.WriteLine("Digite 6 para Cadastrar Requisições de Saida");

            Console.WriteLine("Digite S para Sair");

            string opc = Console.ReadLine();

            return opc;
        }

    }
}
