using System;
using ClubeLeitura12_05_2021.Controladores;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Telas
{
    class TelaCaixa : TelaBase, ICadastravel
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(string titulo, ControladorCaixa ctrlC) : base(titulo)
        {
            controladorCaixa = ctrlC;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número Id da Caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCaixa(id);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar A Caixa", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da Caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a Caixa", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova Caixa...");

            bool conseguiuGravar = GravarCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a caixa", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Caixas...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixa = controladorCaixa.SelecionarTodasCaixas();

            if (caixa.Length == 0)
            {
                ApresentarMensagem("Nenhuma Caixa cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixa.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela, caixa[i].Id, caixa[i].Cor, caixa[i].Etiqueta);
            }
        }


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCaixa(int id)                       ////---------Arrumar para pegar a caixa E STRING VALIDACAO
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a Cor da Caixa: ");
            string corCaixa = Console.ReadLine();

            Console.Write("Digite a Etiqueta Caixa: ");
            string etiquetaCaixa = Console.ReadLine();

            resultadoValidacao = controladorCaixa.RegistrarCaixa(id,corCaixa,etiquetaCaixa);

            if (resultadoValidacao != "CAIXA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
}
