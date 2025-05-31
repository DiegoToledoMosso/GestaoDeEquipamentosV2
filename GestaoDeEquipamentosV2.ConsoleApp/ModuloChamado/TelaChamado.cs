
using GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;
    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Chamados");

        Console.WriteLine();
    }
    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Chamados");
        Console.WriteLine("2 - Visualizar Chamados");
        Console.WriteLine("3 - Editar Chamado");
        Console.WriteLine("4 - Excluir Chamado");
        Console.WriteLine("S - Sair");

        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }
    
    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Chamados");

        Console.WriteLine();

        Chamado chamado = ObeterDados();        

        repositorioChamado.CadastrarChamado(chamado);

        Console.WriteLine($"\nEquipamento \"{chamado.titulo}\" cadastrado com sucesso!");
        Console.ReadLine();
    }    

    public void EditarChamados()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Chamados");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Chamado chamadoAtualizado = ObeterDados();

        bool conseguiuEditar = repositorioChamado.EditarChamados(idSelecionado, chamadoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nEquipamento \"{chamadoAtualizado.titulo}\" foi editado com sucesso!");
        Console.WriteLine();
    }

    public void ExcluirChamados()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Chamados");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioChamado.ExcluirChamados(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nChamado excluido com sucesso!");
        Console.WriteLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();


        Console.WriteLine("Visualização de Chamados");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
            "Id", "Título", "Descrição", " Data de Abertura", " Equipamento"
            );

        Chamado[] chamados = repositorioChamado.SelecionarChamados();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = chamados[i];

            if (c == null)
                continue;

            Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
            c.id, c.titulo, c.descricao, c.dataAbertura.ToShortTimeString(), c.equipamento.nome
            );
        }

        Console.ReadLine();
    }

    public Chamado ObeterDados()
    {
        Console.WriteLine("\nPor favor digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.WriteLine("\nPor favor digite a descrisão do chamado: ");
        string descricao = Console.ReadLine();

        DateTime dataAbertura = DateTime.Now;

        VisualizarEquipamentos();

        Console.WriteLine("\nPor favor digite o id do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Chamado chamado = new Chamado();
        chamado.titulo = titulo;
        chamado.descricao = descricao;
        chamado.dataAbertura = dataAbertura;
        chamado.equipamento = equipamentoSelecionado;


        return chamado;
    }

    public void VisualizarEquipamentos()
    {
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


}
