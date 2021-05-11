using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    class Amigo
    {
        private Emprestimo[] logEmp;
        private string nome;
        private string responsavel;
        private int telefone;
        private string endereco;
        private int id;
        private static int idClass = 0;


        public Amigo()
        {
            logEmp = new Emprestimo[100];
            id = idClass;
            idClass++;
        }
        public Amigo(int id)
        {
            this.id = id;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public int Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        internal Emprestimo[] LogEmp { get => logEmp; set => logEmp = value; }
        public int Id { get => id; set => id = value; }

        public string ValidarAmigo()
        {
            string aux = "";

            //Validar Amigo

            return aux;
        }
    }
}
