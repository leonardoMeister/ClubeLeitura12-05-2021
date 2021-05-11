using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura12_05_2021.Dominio
{
    class Caixa
    {
        /*
         cor, Id Caixa etiqueta  número.
         */
        private string cor;
        private string etiqueta;
        private int id;
        private static int idClass =0;

        public Caixa()
        {
            id = idClass;
            idClass++;
        }
        public Caixa(int id)
        {
            this.id = id;
        }

        public string Cor { get => cor; set => cor = value; }
        public string Etiqueta { get => etiqueta; set => etiqueta = value; }
        public int Id { get => id; set => id = value; }

        public string ValidarCaixa()
        {
            string aux = "";

            //IMPLEMENTAR VALIDACAO

            return aux;
        }
    }
}
