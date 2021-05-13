using System;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Controladores
{
    class ControladorEmprestimo : ControladorBase
    {
        public string RegistrarEmprestimo(int id, Amigo amigo, Revista revista, DateTime dataDevolucaoRevista)
        {
            Emprestimo emprestimo = null;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.Amigo = amigo;
            emprestimo.Revista = revista;
            emprestimo.DataDevolucao = dataDevolucaoRevista;
            emprestimo.DataAbertura = System.DateTime.Now;

            string resultadoValidacao = emprestimo.ValidarEmprestimo();
            
            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                amigo.AlocarHistoricoEmprestimos(emprestimo);
                registros[posicao] = emprestimo;                   
            }
            return resultadoValidacao;


        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }

        public bool ExcluirEmprestimo(int idSelecionado)
        {
            return ExcluirRegistro(new Emprestimo(idSelecionado));
        }

        public Emprestimo[] SelecionarTodasEmprestimos()
        {
            Emprestimo[] emprestimosAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimosAux, emprestimosAux.Length);

            return emprestimosAux;
        }
    }
}
