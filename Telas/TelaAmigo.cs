using System;
using ClubeLeitura12_05_2021.Controladores;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Telas
{
    public class TelaAmigo : TelaBase, ICadastravel
    {
        private ControladorAmigo controladorAmigo;
        public TelaAmigo(string titulo, ControladorAmigo ctrlA) : base(titulo)
        {
            controladorAmigo = ctrlA;
        }

        public override string ObterOpcao()
        {
            Console.WriteLine($"Gestão de Tela Amigo\n");
            Console.WriteLine("Digite 1 para inserir novo Amigo");
            Console.WriteLine("Digite 2 para visualizar Amigos Cadastrados");
            Console.WriteLine("Digite 3 para editar um Cadastro");
            Console.WriteLine("Digite 4 para excluir um Cadastro");
            Console.WriteLine("Digite 5 para Visualizar Historico de um Amigo");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void MostrarHistorico()
        {
            Console.WriteLine("Historico Emprestimos!\n\n");
            VisualizarRegistros();
            Console.WriteLine("Informe o Id do Amigo Desejado");
            int auxId = Convert.ToInt32(Console.ReadLine());
            Amigo amigo=  controladorAmigo.SelecionarAmigoPorId(auxId);
            if (!(amigo is null))
            {
                if (!(amigo.ToString() == ""))
                {
                    Console.WriteLine(amigo.ToString());
                }
                else Console.WriteLine("Amigo Sem Emprestimos no Historico");
                
            }
            else Console.WriteLine("Operação Inválida.\nTente Novamente");

            Console.ReadLine();
            
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Amigo...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número Id do Amigo que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCaixa(id);

            if (conseguiuGravar)
                ApresentarMensagem("Amigo editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o Amigo", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Amigo...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Amigo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmigo.ExcluirAmigo(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Amigo excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o Amigo", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo Amigo...");

            bool conseguiuGravar = GravarCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amigo inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o Amigo", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Amigos...");

            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-40} | {3,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amigo = controladorAmigo.SelecionarTodasAmigos();

            if (amigo.Length == 0)
            {
                ApresentarMensagem("Nenhuma Amigo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < amigo.Length; i++)
            {
                string aux;
                if (amigo[i].StatusEmprestimo)
                {
                    aux = "Sem Emprestimo";
                }
                else aux = "Com Emprestimo";

                Console.WriteLine(configuracaColunasTabela, amigo[i].Id, aux, amigo[i].Nome, amigo[i].Responsavel);
            }
        }


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Status", "Nome", "Responsável");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCaixa(int id)                       ////---------Arrumar para pegar a caixa E STRING VALIDACAO
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite Nome do Amigo: ");
            string nomeAmigo = Console.ReadLine();

            Console.Write("Digite o Responsável do Amigo: ");
            string responsavelAmigo = Console.ReadLine();

            Console.Write("Digite o Telefone: ");
            int telefoneAmigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Endereço do Amigo: ");
            string enderecoAmigo = Console.ReadLine();

            resultadoValidacao = controladorAmigo.RegistrarAmigo(id, enderecoAmigo, nomeAmigo, responsavelAmigo, telefoneAmigo);

            if (resultadoValidacao != "AMIGO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
}
