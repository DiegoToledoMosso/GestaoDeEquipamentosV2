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
    public char ApresentarMenu()
    {

        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();

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

        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" foi cadastrado com sucesso!");
        Console.WriteLine();
    }
    public void VisualizarRegistros()
    {
        throw new NotImplementedException();
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

