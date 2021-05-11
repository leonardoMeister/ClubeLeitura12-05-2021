using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    class Emprestimo
    {
        private Amigo amigo;
        private Revista revista;
        private DateTime dataAbertura;
        private DateTime dataDevolucao;
        private int id;
        private static int idClass = 0;

        public Emprestimo()
        {
            id = idClass;
            idClass++;
        }
        public Emprestimo(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return "";
        }

        public Amigo Amigo { get => amigo; set => amigo = value; }
        public Revista Revista { get => revista; set => revista = value; }
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public int Id { get => id; set => id = value; }
        public static int IdClass { get => idClass; set => idClass = value; }

        public string ValidarEmprestimo()
        {
            string aux = "";

            //Validar Emprestimo

            return aux;
        }
    }
}
