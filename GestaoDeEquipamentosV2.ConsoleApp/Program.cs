using GestaoDeEquipamentosV2.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentosV2.ConsoleApp.ModuloEquipamento;


namespace GestaoDeEquipamentosV2.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento(); 
        TelaChamado telaChamado = new TelaChamado();

        while (true)
        {
            char telaEscolhida = '2';

            if (telaEscolhida == '1')
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
                        telaEquipamento.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaEquipamento.EditarEquipamentos();
                        break;

                    case '4':
                        telaEquipamento.ExcluirEquipamentos();
                        break;
                }
            }

            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarRegistro();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaChamado.EditarEquipamentos();
                        break;

                    case '4':
                        telaChamado.ExcluirEquipamentos();
                        break;
                }

            }


                      
        }
    }
}

