namespace GestaoDeEquipamentosV2.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();    

        while (true)
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
                    telaEquipamento.VisualizarRegistros();
                    break;
            }            
        }
    }
}

public class TelaEquipamento
{

    public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

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
        Console.WriteLine("S - Sair");

        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }
    public void CadastrarRegistro()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de Equipamento");

        Console.WriteLine("");

        Equipamento equipamento = new Equipamento();

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

        equipamento.nome = nome;
        equipamento.precoAquisição = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = datafabricacao;

        repositorioEquipamento.equipamentos[0] = equipamento;

        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" foi cadastrado com sucesso!");
        Console.WriteLine();
    }

    public void VisualizarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Visualização de Equipamentos");

        Console.WriteLine(  );

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
            "Id" , "Nome" , "Preço de Aquisição" , " Número de Série", " Fabricante" , " Data de Fabricação"
            );

        Equipamento[] equipamentos = repositorioEquipamento.equipamentos; 

        for ( int i = 0;  i < equipamentos.Length; i++ )
        {
            Equipamento e = equipamentos[i];

            if ( e == null ) 
                continue;

            Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
            e.id, e.nome, e.precoAquisição.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }
    
}

public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisição;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;
}

public class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];
}