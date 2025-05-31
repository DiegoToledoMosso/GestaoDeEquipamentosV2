using GestaoDeEquipamentosV2.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentosV2.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        TelaEquipamento telaEquipamento = new TelaEquipamento(); 
        telaEquipamento.repositorioEquipamento = repositorioEquipamento;

        TelaChamado telaChamado = new TelaChamado();
        telaChamado.repositorioChamado = repositorioChamado;
        telaChamado.repositorioEquipamento = repositorioEquipamento;

        while (true)
        {
            char telaEscolhida = ApresentarMenuPrincipal();

            if (telaEscolhida == '1')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEquipamento.CadastrarRegistro();
                        break;

                    case '2':
                        telaEquipamento.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaEquipamento.EditarEquipamentos();
                        break;

                    case '4':
                        telaEquipamento.ExcluirEquipamentos();
                        break;
                }
            }

            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarRegistro();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaChamado.EditarEquipamentos();
                        break;

                    case '4':
                        telaChamado.ExcluirEquipamentos();
                        break;
                }

            }


                      
        }
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("|             Gestão de Equipamentos              |");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamado");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Escolha uma das opçôes: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;

    }
}

