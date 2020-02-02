using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2.Clases.Sintactico
{
    class Gramatica
    {
        private XDocument archivo;
        
        private List<char> T { get; set; }
        private List<string> N { get; set; }
        public Produccion pr { get; set; }
        public List<Produccion> P { get; set; }

        public Gramatica()
        {
        }

        public Gramatica(String ubicacion)// inicializa los atributos de la clase
        {
            this.archivo = XDocument.Load(@ubicacion);
            this.N = new List<string>();
            this.T = new List<char>();
            pr = new Produccion();
            this.P = new List<Produccion>();
           
        }

        public List<string> AsignarListaT() {  // lee el archivo xml y lo almacena en la estructura correspondiente

            var temp = from x in this.archivo.Descendants("X") select x;

            foreach (XElement e in temp.Elements("terminal")) {
                N.Add(e.Value);
            }

            return N;
        }

        public List<char> AsignarNoT()
        {

            var temp = from x in this.archivo.Descendants("N") select x;

            foreach (XElement e in temp.Elements("no_terminal"))
            {

                T.Add(e.Value.ElementAt(0));
            }
            return T;
        }


        public List<Produccion> AsignarProd()// lee el archivo xml y lo almacena en la estructura correspondiente

        {

            var temp = from x in this.archivo.Descendants("P") select x;
            int cont = 0;
            foreach (XElement e in temp.Elements("regla"))
            {
                Produccion p = new Produccion();
                cont++;
                p.n = cont;
                p.izq = e.Value.ElementAt(0);
                p.der = e.Value.Substring(5);

                P.Add(p);
            }
            return P;
        }



    }
}
