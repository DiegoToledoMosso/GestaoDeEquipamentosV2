
using GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    public Fabricante[] fabricantes = new Fabricante[100];
    public int contadorFabricantes = 0;

    public void CadastrarFabricante(Fabricante novoFabricante)
    {
        fabricantes[contadorFabricantes] = novoFabricante;

        contadorFabricantes++;
    }

    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public bool EditarFabricante(int idSelecionado, Fabricante fabricantesAtualizado)
    {

        Fabricante fabricanteSelecionado = SelecionarFabricantePorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.nome = fabricantesAtualizado.nome;
        fabricanteSelecionado.email = fabricantesAtualizado.email;
        fabricanteSelecionado.telefone = fabricantesAtualizado.telefone;

        return true;
    }

    public bool ExcluirFabricante(int idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {

            if (fabricantes[i] == null)
                continue;

            if (fabricantes[i].id == idSelecionado)
            {
                fabricantes[i] = null;
                return true;
            }
        }
        return false;
    }

    public Fabricante SelecionarFabricantePorId(int idSelecionado)
    {


        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            if (f.id == idSelecionado)
                return f;
        }

        return null;
    }

    
}