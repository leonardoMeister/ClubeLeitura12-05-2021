using System;
using ClubeLeitura12_05_2021.Dominio;

namespace ClubeLeitura12_05_2021.Controladores
{
    public class ControladorAmigo : ControladorBase
    {
        public string RegistrarAmigo(int id,string endereco, string nome,string responsavel,int telefone )
        {
            Amigo amigo = null;

            int posicao;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amigo = (Amigo)registros[posicao];
            }

            amigo.Endereco = endereco;
            amigo.Nome = nome;
            amigo.Responsavel = responsavel;
            amigo.Telefone = telefone;

            string resultadoValidacao = amigo.ValidarAmigo();

            if (resultadoValidacao == "AMIGO_VALIDO")
                registros[posicao] = amigo;

            return resultadoValidacao;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistroPorId(new Amigo(id));
        }

        public bool ExcluirAmigo(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }

        public Amigo[] SelecionarTodasAmigos()
        {
            Amigo[] amigosAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigosAux, amigosAux.Length);

            return amigosAux;
        }

    }
}
