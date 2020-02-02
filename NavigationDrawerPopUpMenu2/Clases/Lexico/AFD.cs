using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2.Clases
{
    
        [Serializable]
        public class AFD
        {
            private System.Xml.Linq.XDocument documento;
            public List<int> Q;
            public List<char> X;
            public List<Transition> transitions;
            public List<int> F;

            
            public AFD(List<int> q, List<char> x, List<Transition> transitions, int q0, List<int> f, string ruta)
            {
                this.documento = XDocument.Load(ruta);
                Q = list_Q();
                X = list_X();
                transitions = list_Transicion();
                q0 = q0;
                F = f;
            }

          
       
            private List<int> list_Q()
            {
                // Extraer Q -> conjunto de estados
                var Q = from cje in this.documento.Descendants("Q") select cje;
                List<int> lQ = new List<int>();

                foreach (XElement u in Q.Elements("estado"))
                {
                    lQ.Add(int.Parse(u.Value));
                }
                return lQ;
            }

            /**
             * Estraigo el alfabeto de un archivo xml
             * 
             * return: retorno una lista de alfabeto
             */
            private List<char> list_X()
            {
                // Extraer X -> alfabeto
                var X = from al in this.documento.Descendants("X") select al;
                var listX = new List<char>();
                foreach (XElement u in X.Elements("simbolo"))
                {
                    listX.Add(u.Value.ElementAt(0));
                }
                return listX;
            }

            /**
             * Estraigo el estado inicial de un archivo xml
             * 
             * return: retorno un entro que es el estado inicial
             */
            private int q0()
            {
                // Extraer qo -> estado inicial
                var qo = from ei in this.documento.Descendants("qo") select ei;
                int qo_ei = 0;
                foreach (XElement u in qo.Elements("estadoInicial"))
                {
                    qo_ei = int.Parse(u.Value);
                }
                return qo_ei;
            }

            /**
             * Estraigo el conjunto de estados finales de un archivo xml
             * 
             * return: retorno una lista de estados finales
             */
            public List<int> list_F()
            {
                // Extraer F -> Conjunto de estados finales
                var F = from al in this.documento.Descendants("F") select al;
                List<int> listF = new List<int>();
                foreach (XElement u in F.Elements("estadoFinal"))
                {
                    listF.Add(int.Parse(u.Value));
                }
                return listF;
            }

            /**
             * Estraigo las transiciones del automata de un archivo xml
             * 
             * return: retorno una lista de transiciones
             */
            private List<Transition> list_Transicion()
            {
                // transicion
                var transicion = from tran in this.documento.Descendants("T") select tran;
                var listTransicion = new List<Transition>();
                int estado_ini = -1;
                char lee = ' ';
                int estado_fin = -1;
                foreach (XElement u in transicion.Elements("transicion"))
                {
                    estado_ini = int.Parse(u.Element("estado_ini").Value);
                    lee = char.Parse(u.Element("lee").Value);
                    estado_fin = int.Parse(u.Element("estado_fin").Value);
                    listTransicion.Add(new Transition(estado_ini, lee, estado_fin));
                }
                return listTransicion;
            }

            /**
             * Generar la matriz con los estados, el alfabeto y la transicion del archivo xml
             * 
             * return : retorno la matriz
             */
            public int[,] generarMatrizTransitiva(List<int> listQ, List<char> listX, List<Transition> listTransicion)
            {
                int[,] m = crearMatriz(listQ.Count, listX.Count);
                //Console.WriteLine("f: "+ listQ.Count+"    c: "+ listX.Count);
                int fila = 0;
                int columna = 0;
                foreach (Transition dt in listTransicion)
                {
                    fila = listQ.FindIndex(x => x == dt.startstate);
                    columna = listX.FindIndex(x => x.Equals(dt.input));
                    //Console.WriteLine("estado : " + dt.estado + "  lee: " + dt.leyendo);
                    m[fila, columna] = dt.arrivalstate;
                }
                return m;
            }

            private int[,] crearMatriz(int fila, int columnas)
            {
                int[,] m = new int[fila, columnas];
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    for (int j = 0; j < m.GetLength(1); j++)
                    {
                        m[i, j] = -1;
                    }
                }
                return m;
            }
        
}
}

