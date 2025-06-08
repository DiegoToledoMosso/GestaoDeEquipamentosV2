namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;

    public void AtualizarRegistro(Equipamento equipamentoAtualizado)
    {
        
        this.nome = equipamentoAtualizado.nome;
        this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
        this.numeroSerie = equipamentoAtualizado.numeroSerie;
        this.fabricante = equipamentoAtualizado.fabricante;
        this.dataFabricacao = equipamentoAtualizado.dataFabricacao;
    }
}

