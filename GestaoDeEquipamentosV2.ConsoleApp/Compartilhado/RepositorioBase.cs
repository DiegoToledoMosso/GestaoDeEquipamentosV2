﻿using GestaoDeEquipamentosV2.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentosV2.ConsoleApp.Compartilhado;

public class RepositorioBase
{
    private Object[] registros = new Object[100];
    private int contadorRegistros = 0;

    public void CadastrarRegistro(Object novoRegistro)
    {
        registros[contadorRegistros] = novoRegistro;

        contadorRegistros++;
    }

}
