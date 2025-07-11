﻿namespace GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];
    public int contadorEquipamentos = 0;

    public void CadastrarEquipamento(Equipamento equipamento)
    {
        equipamentos[contadorEquipamentos] = equipamento;  

        contadorEquipamentos++;
    }

    public bool EditarEquipamentos(int idSelecionado, Equipamento equipamentoAtualizado)
    {
        Equipamento equipamentoSelecionado = SelecionarEquipamentoPorId(idSelecionado);

        if (equipamentoSelecionado == null)
            return false;
        

        return true;
    }
        
    public bool ExcluirEquipamentos(int idSelecionado)
    {
            
        for (int i = 0; i < equipamentos.Length; i++)
        {

            if (equipamentos[i] == null)
                continue;

            if (equipamentos[i].id == idSelecionado)
            {
                equipamentos[i] = null;
                return true;
            }
        }
        return false;   
    }

    public Equipamento[] SelecionarEquipamentos()
    {
        return equipamentos;
    }

    public Equipamento SelecionarEquipamentoPorId(int idSelecionado)
    {


        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
                return e;
        }

        return null;
    }


}

