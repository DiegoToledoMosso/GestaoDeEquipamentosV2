
using GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;
using System.Runtime.CompilerServices;

namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{

    public RepositorioFabricante repositorioFabricante;
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Fabricantes");

        Console.WriteLine();
    }

    public char ApresentarMenu()
    {

        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Fabricantes");
        Console.WriteLine("2 - Visualizar Fabricantes");
        Console.WriteLine("3 - Editar Fabricantes");
        Console.WriteLine("4 - Excluir Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Fabricantes");

        Console.WriteLine("");

        Fabricante novoFabricante = ObeterDados();

        string erros = novoFabricante.Validar();

        if (erros.Length > 0)  // Se der erro
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red; //Exibe a mensagem em vermelho

            Console.WriteLine(erros);
            Console.ResetColor();  // Reseta a cor da Mensagem.

            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();


            CadastrarRegistro(); // chama pra onde quer voltar

            return;
        }

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Console.WriteLine($"\nFabricante\"{novoFabricante.nome}\" foi cadastrado com sucesso!");
        Console.ReadLine();

    }

    public void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricantesAtualizado = ObeterDados();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idSelecionado, fabricantesAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nFabricante \"{fabricantesAtualizado.nome}\" foi editado com sucesso!");
        Console.WriteLine();
    }

    public void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusao de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nFabricante excluído com sucesso!");
        Console.WriteLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();


        Console.WriteLine("Visualização de Fabricantes");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -20} | {3, -15}",
            "Id", "Nome", "email", " telefone"
            );

        Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -20} | {3, -15}",
            f.id, f.nome, f.email, f.telefone
            );
        }

        Console.ReadLine();
    }

    public Fabricante ObeterDados()
    {
        Console.WriteLine("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o email do fabricante: ");
        string email = Console.ReadLine();

        Console.WriteLine("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();

        Fabricante fabricante = new Fabricante(nome, email, telefone);
        
        
        return fabricante;
    }

}
