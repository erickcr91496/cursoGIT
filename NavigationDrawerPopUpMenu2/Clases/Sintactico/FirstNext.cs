using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class FirstNext
    {
       public string nt { get; set; }
        public string first { get; set; }
        public string next { get; set; }

        public FirstNext()
        {
        }

        public FirstNext(string nt, string first, string next)
        {
            this.nt = nt;
            this.first = first;
            this.next = next;
        }

        public List<FirstNext> Cargar(List<FirstNext> firstynext, StreamReader sr) {

            while (!sr.EndOfStream)
            {
                string [] linea = sr.ReadLine().Split('\t');
                nt = linea[0];
                first = linea[1];
                next= linea[2];
                FirstNext fn = new FirstNext(nt, first, next);
                firstynext.Add(fn);

            }
            sr.Close();

            return firstynext;
        }



    }



}
