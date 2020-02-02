using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class TDS
    {
        public int nToken{ get; set; }
        public int tipo { get; set; }
        public int size { get; set; }
        public string nombre { get; set; }
        public object valor { get; set; }

        public TDS(int nToken, int tipo, int size, string nombre, object valor)
        {
            this.nToken = nToken;
            this.tipo = tipo;
            this.size = size;
            this.nombre = nombre;
            this.valor = valor;
        }

        public TDS()
        {
      
        }
       
    }
    




}
