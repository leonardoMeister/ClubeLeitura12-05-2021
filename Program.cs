using System;
using ClubeLeitura12_05_2021.Telas;

namespace ClubeLeitura12_05_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia objetos dentro da tela principal
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                ICadastravel telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                string opcao = ((TelaBase)telaSelecionada).ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.InserirNovoRegistro();

                else if (opcao == "2")
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }

                else if (opcao == "3")
                    telaSelecionada.EditarRegistro();

                else if (opcao == "4")
                    telaSelecionada.ExcluirRegistro();

                else if (opcao == "5")
                {
                    if (telaSelecionada is TelaAmigo)
                    {
                        ((TelaAmigo)telaSelecionada).MostrarHistorico();
                    }
                }

                Console.Clear();
            }
        }
    }
}
