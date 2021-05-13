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

            if (!amigo.StatusEmprestimo || !revista.StatusEmprestimo)
            {
                return "Amigo Ou Revista Já Possui Emprestimo Em Andamento!";
            }
            

            emprestimo.Amigo = amigo;
            emprestimo.Revista = revista;
            emprestimo.DataDevolucao = dataDevolucaoRevista;
            emprestimo.DataAbertura = System.DateTime.Now;

            string resultadoValidacao = emprestimo.ValidarEmprestimo();
            


            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                amigo.AlocarHistoricoEmprestimos(emprestimo);
                revista.StatusEmprestimo = false;
                registros[posicao] = emprestimo;                   
            }
            return resultadoValidacao;

        }
        protected override bool CompararId(object auxId, object AuxComparador)
        {
            Emprestimo aux1 = (Emprestimo)auxId;
            Emprestimo aux2 = (Emprestimo)AuxComparador;
            if (aux1.Id == aux2.Id)
            {
                return true;
            }
            else return false;
        }
        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }

        public bool ExcluirEmprestimo(int idSelecionado)
        {
            Emprestimo aux = SelecionarEmprestimoPorId(idSelecionado);


            bool auxbol = false;
            if (ExcluirRegistro(new Emprestimo(idSelecionado)))
            {
                auxbol = true;
                aux.Amigo.StatusEmprestimo = true;
                aux.Revista.StatusEmprestimo = true;
            }
            return  auxbol;
        }

        public Emprestimo[] SelecionarTodasEmprestimos()
        {
            Emprestimo[] emprestimosAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimosAux, emprestimosAux.Length);

            return emprestimosAux;
        }
    }
}
