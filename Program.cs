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
                TelaBase telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                string opcao = ((TelaBase)telaSelecionada).ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (telaSelecionada is TelaEmprestimo)
                {
                    if (opcao == "1")
                    {
                        ((TelaEmprestimo)telaSelecionada).CriarEmprestimo();
                    }
                    else if (opcao == "2")
                    {
                        ((TelaEmprestimo)telaSelecionada).VisualizarEmprestimos();
                        Console.ReadLine();
                    }
                    else if (opcao == "3")
                    {
                        ((TelaEmprestimo)telaSelecionada).DevolverEmprestimo();

                    }
                }
                else
                {
                    if (opcao == "1")
                        ((ICadastravel)telaSelecionada).InserirNovoRegistro();

                    else if (opcao == "2")
                    {
                        ((ICadastravel)telaSelecionada).VisualizarRegistros();
                        Console.ReadLine();
                    }

                    else if (opcao == "3")
                        ((ICadastravel)telaSelecionada).EditarRegistro();

                    else if (opcao == "4")
                        ((ICadastravel)telaSelecionada).ExcluirRegistro();

                    else if (opcao == "5")
                    {
                        if (telaSelecionada is TelaAmigo)
                        {
                            ((TelaAmigo)telaSelecionada).MostrarHistorico();
                        }
                    }
                }

                Console.Clear();
            }
        }
    }
}
