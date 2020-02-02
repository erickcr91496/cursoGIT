using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class LeerMatrizAFD
    {

        /**
      * Abro el achivo y lo convierto a texto
      * 
      * @param ruta: la ruta del archivo a leer
      * return : el texto del archivo
      */

        public String[] columnas_simbolos { get; set; }
        public string[,] matrizTransicion { get; set; }
        public LeerMatrizAFD(String ruta)
        {
            this.matrizTransicion = crearMatrizTransicion(ruta);

        }

        private string[] abriArchivo(string ruta)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(ruta); // me lee todas las lineas que existe

                this.columnas_simbolos = this.v_column(lines[0]); // extraemos los simbolos que se encuentra en la fila 0
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Error: al cargar el archivo", "original");
            }
            return lines;
        }

        /**
         * Del archivo leido genero la matriz de transicion
         * 
         * @param ruta: la ruta del archivo a ser leido
         * return : retorno la matriz de transicion
         */
        public string[,] crearMatrizTransicion(string ruta)
        {
            string[] partes_txt = abriArchivo(ruta); // texto de cada linea
            string[,] m = new string[partes_txt.Length - 1, this.columnas_simbolos.Length]; // -1 porque no queremos la fila de los simbolos
            string[] part = null;

            for (int i = 0; i < m.GetLength(0); i++) // recorro todas las filas del archivo
            {
                part = partes_txt[i].Split(';'); // +1 : porque en la posicion 0 se encuentra los simbolos ya sacados

                for (int j = 0; j < part.Length; j++) // recorro todas las partes de cada fila
                {
                    if (!"".Equals(part[j]))// si no existe un vacio
                    {
                        m[i, j] = part[j]; // guardo el nodo obtenido
                    }
                    else
                    {
                        m[i, j] = "-999"; // si esta vacio le lleno con -1
                    }
            }
        }
            return m;
        }

        public void generarTableMatrizTransicion(DataGridView tabla, string[,] m)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(" ");
            for (int i = 1; i < m.GetLongLength(1); i++)
            {
                dt.Columns.Add(m[0,i]+"--"+i); // añado las columnas de la tabla (simbolos)
            }

            for (int i = 0; i < m.GetLongLength(0); i++)
            {
                dt.Rows.Add(""); // agrego las filas necesarias
            }
            tabla.DataSource = dt; // aplico los cambios a la tabla entrante
        }


        public void imprimirTablaMatrizTransicion(DataGridView tabla, string[,] m)
        {
            for (int i = 1; i < m.GetLength(0); i++)
            {
                //tabla[0, i].Value = i;
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    tabla[j , i-1].Value = m[i, j];
                }
            }
        }

        public List<string[]> crearMatrizTransicion2(string ruta)
        {
            string[] partes_txt = abriArchivo(ruta); // texto de cada linea
            string[] part = null;
            List<string[]> l_v = new List<string[]>();
            for (int i = 0; i < partes_txt.Length; i++) // recorro todas las filas del archivo
            {
                part = partes_txt[i].Split(';'); // +1 : porque en la posicion 0 se encuentra los simbolos ya sacados
                l_v.Add(part);

                /*for (int j = 0; j < part.Length; j++) // recorro todas las partes de cada fila
                {
                    if (!"".Equals(part[j]))// si no existe un vacio
                    {
                        m[i, j] = int.Parse(part[j]); // guardo el nodo obtenido
                    }
                    else
                    {
                        m[i, j] = -1; // si esta vacio le lleno con -1
                    }
                }*/
            }
            return l_v;
        }

        
        /**
         * Separo todos los simbolos qu existen del archivo
         * 
         * @param txt: son las culumnas de  los simbolos
         * return: retorno un vector con los simbolos
         */
        private string[] v_column(string txt)
        {
            return txt.Split(';');
           
        }

    }

}
