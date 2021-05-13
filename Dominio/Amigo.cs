using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    public class Amigo
    {
        private Emprestimo[] logEmp;    //quando vai cadastrar amigo n precisa disso

        private string nome;
        private string responsavel;
        private int telefone;
        private string endereco;
        private int id;
        private static int idClass = 1;

        private bool statusEmprestimo;

        public Amigo()
        {
            logEmp = new Emprestimo[100];
            id = idClass;
            idClass++;
            statusEmprestimo = true;
        }
        public Amigo(int id)
        {
            this.id = id;
        }
        public override string ToString()
        {
            string aux = "";
            for (int i = 0; i < logEmp.Length; i++)
            {
                if (logEmp[i] == null || logEmp[i].Id ==0)
                {
                    return aux;
                }

                if (logEmp[i] != null)
                {
                    aux += logEmp[i].ToString()+"\n";
                }
            }
            return aux;
        }

        public void AlocarHistoricoEmprestimos(Emprestimo emp)
        {
            for (int i = 0; i < logEmp.Length; i++)
            {
                if (logEmp[i]== null)
                {
                    logEmp[i] = emp;
                    statusEmprestimo = false;
                    return;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Amigo amigo = (Amigo)obj;

            if (id == amigo.id)
                return true;
            else
                return false;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public int Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        internal Emprestimo[] LogEmp { get => logEmp; set => logEmp = value; }
        public int Id { get => id; set => id = value; }
        public bool StatusEmprestimo { get => statusEmprestimo; set => statusEmprestimo = value; }

        public string ValidarAmigo()
        {
            string aux = "";

            //Validar Amigo


            if (aux == "")
            {
                return "AMIGO_VALIDO";
            }

            return aux;
        }
    }
}
