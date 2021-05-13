using System;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Controladores
{
    class ControladorRevista :ControladorBase
    {
        public string RegistrarRevista(int id, int numeroColecao, Caixa caixa, DateTime data, string status,string tipoColecao)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.NumeroColecao = numeroColecao;
            revista.Caixa = caixa;
            revista.DataRevista = data;
            revista.Status = status;
            revista.TipoColecao = tipoColecao;

            string resultadoValidacao = revista.RevistaValida();

            if (resultadoValidacao == "REVISTA_VALIDA")
                registros[posicao] = revista;

            
            return resultadoValidacao;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistasAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistasAux, revistasAux.Length);

            return revistasAux;
        }
    }
}
