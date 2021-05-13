using System;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Controladores
{
    class ControladorCaixa : ControladorBase
    {
        public string RegistrarCaixa(int id, string cor, string etiqueta)
        {
            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.Cor = cor;
            caixa.Etiqueta = etiqueta;


            string resultadoValidacao = caixa.ValidarCaixa();

            if (resultadoValidacao == "CAIXA_VALIDA")
                registros[posicao] = caixa;
            return resultadoValidacao;
        }
        protected override bool CompararId(object auxId, object AuxComparador)
        {
            Caixa aux1 = (Caixa)auxId;
            Caixa aux2 = (Caixa)AuxComparador;
            if (aux1.Id == aux2.Id)
            {
                return true;
            }
            else return false;
             
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixasAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixasAux, caixasAux.Length);

            return caixasAux;
        }

    }
}
