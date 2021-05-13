using System;
using ClubeLeitura12_05_2021.Controladores;

namespace ClubeLeitura12_05_2021.Telas
{
    class TelaPrincipal 
    {
        //Objetos Tela
        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;
        private TelaRevista telaRevista;
        private TelaEmprestimo telaEmprestimo;
        //Objetos Controlador
        private ControladorAmigo controladorAmigo;
        private ControladorCaixa controladorCaixa;
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;

        public TelaPrincipal()
        {
            controladorAmigo = new ControladorAmigo();
            controladorCaixa = new ControladorCaixa();
            controladorEmprestimo = new ControladorEmprestimo();
            controladorRevista = new ControladorRevista();

            telaAmigo = new TelaAmigo("Amigo", controladorAmigo);
            telaCaixa = new TelaCaixa("Caixa", controladorCaixa) ;
            telaRevista = new TelaRevista("Revista",controladorRevista, controladorCaixa, telaCaixa);
            telaEmprestimo = new TelaEmprestimo("Emprestimo",controladorAmigo,controladorEmprestimo,controladorRevista,telaAmigo,telaRevista ) ;
        }


        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Controle de Emprestimo");
                Console.WriteLine("Digite 2 para o Controle de Amigo");
                Console.WriteLine("Digite 3 para o Controle de Revista");
                Console.WriteLine("Digite 4 para o Controle de Caixa");


                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = telaEmprestimo;                  

                else if (opcao == "2")
                    telaSelecionada =  telaAmigo;

                else if (opcao == "3")
                    telaSelecionada = telaRevista;

                else if (opcao == "4")
                    telaSelecionada = telaCaixa;

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "3" && opcao != "4" && opcao != "2" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }
    }
}
