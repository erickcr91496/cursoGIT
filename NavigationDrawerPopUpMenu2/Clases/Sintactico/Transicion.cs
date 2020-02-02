using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2.Clases.Sintactico
{
    class Transicion
    {
        private XDocument archivo;

        public int eInicial;
        public char lee;
        public int eFinal;

        public Transicion(int eInicial, char lee, int eFinal)
        {
            
            this.eInicial = eInicial;
            this.lee = lee;
            this.eFinal = eFinal;
        }

        public Transicion(string ubicacion)
        {
            this.archivo = XDocument.Load(@ubicacion);
        }

        public List<Transicion> list_GoTo()// lee el archivo xml y lo almacena en la estructura correspondiente

        {
            var t = from tr in this.archivo.Descendants("GoTo") select tr;
            var lista = new List<Transicion>();
            int eInicial = -1;
            char lee = ' ';
            int eFinal = -1;
            foreach (XElement u in t.Elements("transicion"))
            {
                eInicial = int.Parse(u.Element("estado_ini").Value);
                lee = char.Parse(u.Element("no_terminal").Value);
                eFinal = int.Parse(u.Element("estado_fin").Value);
                lista.Add(new Transicion(eInicial, lee, eFinal));
            }
            return lista;
        }


        public List<Transicion> Accion()// lee el archivo xml y lo almacena en la estructura correspondiente

        {
            var t = from tr in this.archivo.Descendants("accion") select tr;
            var lista = new List<Transicion>();
            int eInicial = -1;
            char lee = ' ';
            int eFinal = -1;
            foreach (XElement p in t.Elements("transicion"))
            {
                eInicial = int.Parse(p.Element("estado").Value);
                lee = char.Parse(p.Element("simbolo").Value);
                eFinal = int.Parse(p.Element("movimiento").Value);
                lista.Add(new Transicion(eInicial, lee, eFinal));
            }
            return lista;
        }
    }
}
