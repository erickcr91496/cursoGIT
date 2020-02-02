using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class TipoDato
    {

        private int id { get; set; }
        private string nombre { get; set; }
        int identificador = 1;
        int[] tipos = { 17, 21, 18,20,19};
        String[] tipoPalabra = {"string", "double", "char", "bool", "real","integer" };
        //ArrayList tipos = new ArrayList();
        int[] operadores = { 11 };
        int[] funciones = { };

        public TipoDato()
        {
        }

        public int TipoVariable(string nombre) 
        {
            int a=-1;
            if (nombre.Equals("integer")) {
                 a = 1;       
            }
            if (nombre.Equals("real"))
            {
                a = 2;
            }
            if (nombre.Equals("char"))
            {
                a = 3;
            }
            if (nombre.Equals("string"))
            {
                a = 4;
            }

            if (nombre.Equals("bool"))
            {
                a = 5;
            }

            return a;
        }

        public TipoDato(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public string RecoTipo(int numero)
        {
            string res="";

            if (tipos.Contains(numero)) {
                res = "tipo";
            }

            if (operadores.Contains(numero))
            {
                res = "operador";
            }
            if (identificador==numero)
            {
                res = "identificador";
            }
            return res;
        }
        public int convertir(string tipo)
        {
            int num = 0;
            if (tipo == "string")
            {
                num = 4;
            }
            else if (tipo == "integer")
            {
                num = 1;
            }
            else if (tipo == "real")
            {
                num = 2;
            }
            else if (tipo == "char")
            {
                num = 3;
            }
            else if (tipo == "bool")
            {
                num = 5;
            }

            return num;
        }

        public string RecoTipo(String p)
        {
            string res = "";

            if (tipoPalabra.Contains(p))
            {
                res = "tipo";
            }

            if (p.Substring(0,1).Equals('#'))
            {
                res = "identificador";
            }


            return res;
        }


    }
}
