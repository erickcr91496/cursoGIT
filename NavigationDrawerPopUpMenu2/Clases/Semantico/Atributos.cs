using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases.Semantico
{
    public class Atributos
    {
      public char noterminal { get; set; }
        public string name { get; set; }
        public int principio { get; set; }
        public int siguiente { get; set; }
        public List<int> verdadero { get; set; }
        public List<int> falsos { get; set; }
        public Object valor { get; set; }
        public int Tipo { get; set; }
        public string Lex { get; set; } 
        public Atributos()
        {
        }

        public Atributos(char noterminal, string name, int principio, int siguiente, List<int> verdadero, List<int> falsos, object valor, int tipo, string lex)
        {
            this.noterminal = noterminal;
            this.name = name;
            this.principio = principio;
            this.siguiente = siguiente;
            this.verdadero = verdadero;
            this.falsos = falsos;
            this.valor = valor;
            Tipo = tipo;
            this.Lex = lex;
        }
    }
}
