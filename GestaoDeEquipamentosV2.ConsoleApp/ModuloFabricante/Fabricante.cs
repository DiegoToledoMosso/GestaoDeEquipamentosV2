using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int id;
    public string nome;
    public string email;
    public string telefone;

    public Fabricante(string nome, string email, string telefone)
    {
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        
    }
    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O nome deve é obrigatório!\n";

        else if (nome.Length < 2)
            erros += "O nome deve conter mais que 1 caractere.\n";

        if (!MailAddress.TryCreate(email, out _))
            erros += "O email deve conter um formato válido \"nome@provedor.com\"!\n";

        if (string.IsNullOrWhiteSpace(telefone))
            erros += "O telefone é obrigatório";

        else if (telefone.Length < 9)
            erros += "O telefone deve conter no mínimo 9 números!\n";

        return erros;

    }

    public void AtualizarRegistro(Fabricante fabricantesAtualizado)
    {
        this.nome = fabricantesAtualizado.nome;
        this.email = fabricantesAtualizado.email;
        this.telefone = fabricantesAtualizado.telefone;
    }

}
