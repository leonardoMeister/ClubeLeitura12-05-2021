using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    public class Revista
    {
        private string tipoColecao;
        private int numeroColecao;
        private DateTime dataRevista;
        private Caixa caixa;
        private string status;
        private bool statusEmprestimo;
        private int id;
        private static int idClass = 1;

        public Revista()
        {
            Id = idClass;
            idClass++;
            statusEmprestimo = true;
        }
        public Revista(int id)
        {
            this.Id = id;
        }

        public string TipoColecao { get => tipoColecao; set => tipoColecao = value; }
        public int NumeroColecao { get => numeroColecao; set => numeroColecao = value; }
        public DateTime DataRevista { get => dataRevista; set => dataRevista = value; }
        public string Status { get => status; set => status = value; }
        internal Caixa Caixa { get => caixa; set => caixa = value; }
        public int Id { get => id; set => id = value; }
        public bool StatusEmprestimo { get => statusEmprestimo; set => statusEmprestimo = value; }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }

        public string RevistaValida()
        {
            string aux = "";

           // if()

            if (aux == "")
            {
                return "REVISTA_VALIDA";
            }
            return aux;
        }
    }
}
