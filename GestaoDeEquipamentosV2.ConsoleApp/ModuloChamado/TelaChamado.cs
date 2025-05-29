
namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloChamado;

public class TelaChamado
{
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
        throw new NotImplementedException();
    }

    public void EditarEquipamentos()
    {
        throw new NotImplementedException();
    }

    public void ExcluirEquipamentos()
    {
        throw new NotImplementedException();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        throw new NotImplementedException();
    }


}
