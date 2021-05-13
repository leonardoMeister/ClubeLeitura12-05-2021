using System;
using ClubeLeitura12_05_2021.Controladores;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Telas
{
    class TelaEmprestimo : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorAmigo controladorAmigo;

        private TelaRevista telaRevista;
        private TelaAmigo telaAmigo;
        public TelaEmprestimo(string titulo, ControladorAmigo ctrlA, ControladorEmprestimo ctrlE, ControladorRevista ctrlR, TelaAmigo telaA, TelaRevista telaR) : base(titulo)
        {
            this.controladorAmigo = ctrlA;
            this.controladorEmprestimo = ctrlE;
            this.controladorRevista = ctrlR;
            this.telaAmigo = telaA;
            this.telaRevista = telaR;
        }
        public override string ObterOpcao()
        {
            Console.WriteLine($"Gestão de Emprestimos\n");
            Console.WriteLine("Digite 1 para Realizar um Emprestimo");
            Console.WriteLine("Digite 2 para visualizar Emprestimos Ativos");
            Console.WriteLine("Digite 3 para editar um Emprestimo");
            Console.WriteLine("Digite 4 para Devolver um Emprestimo");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Emprestimo...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número Id do Emprestimo que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarEmprestimo(id);

            if (conseguiuGravar)
                ApresentarMensagem("Emprestimo editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o Emprestimo", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Devolvendo um Emprestimo...");

            VisualizarRegistros();

            Console.WriteLine();
             
            Console.Write("Digite o número do Emprestimo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEmprestimo.ExcluirEmprestimo(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Emprestimo excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o Emprestimo", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo Emprestimo...");

            bool conseguiuGravar = GravarEmprestimo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Emprestimo inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o Emprestimo", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Emprestimos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodasEmprestimos();

            if (emprestimo.Length == 0)
            {
                ApresentarMensagem("Nenhum Emprestimo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < emprestimo.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela, emprestimo[i].Id, emprestimo[i].Amigo.Nome, emprestimo[i].Revista.TipoColecao);
            }
        }


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id Emprestimo", "Nome Amigo", "Coleção Revista");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarEmprestimo(int id)                       ////---------Arrumar para pegar a caixa E STRING VALIDACAO
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;
            telaAmigo.VisualizarRegistros();
            telaRevista.VisualizarRegistros();

            Console.Write("Digite Id do Amigo para o Emprestimo: ");
            int idAmigo = Convert.ToInt32( Console.ReadLine());

            Console.Write("Digite o Id da Revista para o Emprestimo: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite A Data De Devolução: ");
            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

            resultadoValidacao = controladorEmprestimo.RegistrarEmprestimo(id,controladorAmigo.SelecionarAmigoPorId(idAmigo),controladorRevista.SelecionarRevistaPorId(idRevista), dataDevolucao);

            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }



            return conseguiuGravar;
        }
    }
}
