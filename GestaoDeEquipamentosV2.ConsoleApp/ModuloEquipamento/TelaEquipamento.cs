namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{

    public RepositorioEquipamento repositorioEquipamento;

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();
    }

    public char ApresentarMenu()
    {

        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Visualizar Equipamentos");
        Console.WriteLine("3 - Editar Equipamentos");
        Console.WriteLine("4 - Excluir Equipamentos");
        Console.WriteLine("S - Sair");

        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {

        ExibirCabecalho();
        
        Console.WriteLine("Cadastro de Equipamento");

        Console.WriteLine("");
        Equipamento equipamento = ObeterDados();

        repositorioEquipamento.CadastrarEquipamento(equipamento);

        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" foi cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {

        if (exibirCabecalho == true)
            ExibirCabecalho();


        Console.WriteLine("Visualização de Equipamentos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
            "Id", "Nome", "Preço de Aquisição", " Número de Série", " Fabricante", " Data de Fabricação"
            );

        Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
            e.id, e.nome, e.precoAquisição.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }

    public void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoAtualizado = ObeterDados();

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamentos(idSelecionado, equipamentoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" foi editado com sucesso!");
        Console.WriteLine();
    }
    public void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamentos(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nEquipamento excluido com sucesso!");
        Console.WriteLine();
    }

    public Equipamento ObeterDados()
    {
        Console.WriteLine("\nPor favor digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.WriteLine("\nPor favor o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nPor favor digite o número de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.WriteLine("\nPor favor digite o fabricante do equipamento: ");
        string fabricante = Console.ReadLine();

        Console.WriteLine("\nPor favor digite a data de fabricação do equipamento: ");
        DateTime datafabricacao = DateTime.Parse(Console.ReadLine());


        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisição = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = datafabricacao;


        return equipamento;
    }
}

