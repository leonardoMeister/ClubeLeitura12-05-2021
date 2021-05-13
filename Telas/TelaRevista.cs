using System;
using ClubeLeitura12_05_2021.Controladores;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Telas
{
    class TelaRevista : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;
        private ControladorCaixa controladorCaixa;
        private TelaCaixa telaCaixa;
        public TelaRevista(string titulo, ControladorRevista ctrlR, ControladorCaixa ctrlC, TelaCaixa telaCaixa): base(titulo)
        {
            controladorCaixa = ctrlC;
            controladorRevista = ctrlR;
            this.telaCaixa = telaCaixa;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da Revista que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarRevista(id);

            if (conseguiuGravar)
                ApresentarMensagem("Revista editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar A Revista", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da Revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a Revista", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo Revista...");

            bool conseguiuGravar = GravarRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("Revista inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o Revista", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasRevistas();

            if (revista.Length == 0)
            {
                ApresentarMensagem("Nenhuma Revista cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                string aux;
                if (revista[i].StatusEmprestimo)
                {
                    aux = "Disponivel Alugar";
                } else aux = "Emprestada";
                Console.WriteLine(configuracaColunasTabela, revista[i].Id , revista[i].TipoColecao, aux);
            }
        }


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Tipo Coleção", "Status");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarRevista(int id)                       ////---------Arrumar para pegar a caixa E STRING VALIDACAO
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;
            Console.Clear();

            telaCaixa.VisualizarRegistros();

            Console.Write("\n\nDigite o Tipo Coleção da revista: ");
            string tipoColecao = Console.ReadLine();

            Console.Write("Digite o Numero da Coleção: ");
            int numeroColecao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de Impressao da Revista: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite Id Caixa: ");
            int idCaixa = Convert.ToInt32( Console.ReadLine());

            Console.Write("Digite o Status da Revista: ");
            string status = Console.ReadLine();

            Caixa caixa = controladorCaixa.SelecionarCaixaPorId(idCaixa);                   ////---------Arrumar para pegar a caixa

            resultadoValidacao = controladorRevista.RegistrarRevista(id, numeroColecao,caixa,dataFabricacao,status,tipoColecao);

            if (resultadoValidacao != "REVISTA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

    }
}
