using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    public class Emprestimo
    {
        private Amigo amigo;
        private Revista revista;
        private DateTime dataAbertura;
        private DateTime dataDevolucao;
        private int id;
        private static int idClass = 1;

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
            return $"Amigo: {amigo.Nome}, Coleção Revista: {revista.TipoColecao}, Id: {id}";
        }

        public Amigo Amigo { get => amigo; set => amigo = value; }
        public Revista Revista { get => revista; set => revista = value; }
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public int Id { get => id; set => id = value; }
        public static int IdClass { get => idClass; set => idClass = value; }

        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }
        public string ValidarEmprestimo()
        {
            string aux = "";

            //Validar Emprestimo

            if (aux == "")
            {
                return "EMPRESTIMO_VALIDO";
            }

            return aux;
        }
    }
}
