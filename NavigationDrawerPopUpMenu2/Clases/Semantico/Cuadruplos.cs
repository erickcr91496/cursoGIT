using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases.Semantico
{
    //genera un cuadruplo y debuelve un cuaruplo
    class Cuadruplos
    {
        public int numbertupla { get; set; }
        public string operador { get; set; }
        public string operando1 { get; set; }
        public string operando2 { get; set; }
        public string resultado { get; set; }
        //public List<Cuadruplos> CodigoIntermedio = new List<Cuadruplos>();

        public Cuadruplos()
        {
        }

        public Cuadruplos(int numbertupla, string operador, string operando1, string operando2, string resultado)
        {
            this.numbertupla = numbertupla;
            this.operador = operador;
            this.operando1 = operando1;
            this.operando2 = operando2;
            this.resultado = resultado;
        }
    }
}
