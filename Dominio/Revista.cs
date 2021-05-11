using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    class Revista
    {
        private string tipoColecao;
        private int numeroColecao;
        private DateTime dataRevista;
        private Caixa caixa;
        private string status;
        private int id;
        private static int idClass = 0;

        public Revista()
        {
            id = idClass;
            idClass++;
        }
        public Revista(int id)
        {
            this.id = id;
        }

        public string TipoColecao { get => tipoColecao; set => tipoColecao = value; }
        public int NumeroColecao { get => numeroColecao; set => numeroColecao = value; }
        public DateTime DataRevista { get => dataRevista; set => dataRevista = value; }
        public string Status { get => status; set => status = value; }
        internal Caixa Caixa { get => caixa; set => caixa = value; }

        public string RevistaValida()
        {
            string aux = "";

            //IMPLEMENTAR VALIDACAO

            return aux;
        }
    }
}
