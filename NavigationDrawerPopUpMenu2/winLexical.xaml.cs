using Microsoft.Win32;
using NavigationDrawerPopUpMenu2.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Lógica de interacción para winLexical.xaml
    /// </summary>
    public partial class winLexical : UserControl
    {
        string rutaContador = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\comas.txt";

        TipoDato td = new TipoDato();
        Movimiento afd = new Movimiento();
        String ruta;
        Token tk = new Token();
        loadAlfabeto alfabeto;
        generarTablas gt;
        ArrayList Listafin;
        ArrayList reconocidos = new ArrayList();
        ArrayList noreconocidos = new ArrayList();

        Object[,] prifil;
        Object[,] valor;
        int posicionlista = 0;
        Queue<char> myQueue;
        static List<Token> listorec = new List<Token>();
        static List<Token> alfa = new List<Token>();

        TDS tds = new TDS();

       

        public winLexical()
        {
            InitializeComponent();
        }


        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
        

        private void BtnCargarAlfabeto(object sender, RoutedEventArgs e)
        {
           
            alfabeto = new loadAlfabeto();

            string rutax = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\Alfabeto2.xml";


            gt = new generarTablas();
            alfabeto.getRuta_alfabeto(rutax);
            gt.generarTablaAlfabeto(tblAlfabeto,alfabeto.listAlfabeto);


            Alfa=alfabeto.generarListaAlfabeto(alfabeto.Documento);
            tblAlfabeto.ItemsSource = Alfa;
                

        }

        string rutaCSV = @"E:\UTN\VII SEMESTRE\COMPILADORES\puntoycomas.txt";

        LeerMatrizAFD lm ;
        int[,] m;
        private void btnCargarMatrizAFD(object sender, RoutedEventArgs e)
        {
            FrmTransicion fr = new FrmTransicion();
            fr.Show();
            lm = new LeerMatrizAFD(rutaCSV);



        }
       
        private void btnRead_click(object sender, RoutedEventArgs e)
        {

            string ruta2 = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\comas.txt";

            StreamReader sr = new StreamReader(ruta2, System.Text.Encoding.ASCII);
            ReadAFD(sr);
            sr.Close();

        }
        private void ReadAFD(StreamReader sr)
        {

            int f = 173;
            int c = 65;
          Object[,] mt = new Object[f, c]; //matriz de transicion
           

            for (int i = 0; i < f; i++)
            {
                string temp = sr.ReadLine();

                for (int x = 0; x < c; x++)
                {

                    Object[] temps = temp.Split('\t');

                    mt[i, x] = temps[x];


                }
            }

            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int x = 0; x < mt.GetLength(1); x++)
                {

                    if (mt[i, x].Equals(""))
                    {
                        mt[i, x] = "-";
                    }
                }
            }
         

            int c1 = 0;

            for (int i = 1; i < mt.GetLength(0); i++)// cuenta el numero de transiciones totales
            {
                for (int j = 1; j < mt.GetLength(1); j++)
                {

                    if (!mt[i, j].Equals("-"))
                    {
                        c1++;
                    }

                }

            }

            Console.WriteLine("------------------------------prifil------------------------------");
            prifil = afd.Prifil(mt);
            afd.Print(prifil, rtbPrifil);
            Console.WriteLine("--------------------------tabla valor-----------------------");
            valor = afd.Valor(mt, c1);
            afd.Print(valor, rtbValor);      
        }





      



        private void BtnCargarPalabra_Click(object sender, RoutedEventArgs e)
        {
             Listorec.Clear();
            tabla.Clear();
            txtb_Error.Clear();
            txtb_listareco.Clear();
            txtb_texto.Clear();
            reconocidos.Clear();
            txtb_palabraactual.Clear();
            Listafin = new ArrayList();
            String buscar = @"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\prueba4.txt";
           
        
                StreamReader sr = new StreamReader(buscar);
               Listafin = afd.Readtxt(sr, Listafin);
                   sr.Close();
            
               

            for (int i = 0; i < Listafin.Count; i++)
            {
                string texto = Listafin[i].ToString().Remove(Listafin[i].ToString().Length - 1);
                    txtb_texto.AppendText(texto+" ");


            }
            txtb_palabraactual.AppendText(Listafin[0].ToString());
 
        }
       
        public void Btn_reconocerTodo_Click(object sender, RoutedEventArgs e)
        {
            BtnCargarPalabra_Click(sender, e);
            BtnCargarAlfabeto(sender, e);
            btnRead_click(sender, e);
            reconocidos.Clear();
            txtb_listareco.Clear();
                int x = 1;
                bool bandera = false;
            for (int i = 0; i < Listafin.Count; i++)
            {

                char[] a = Listafin[i].ToString().ToCharArray();
                for (int j = 0; j < a.GetLength(0); j++)
                {

                    int res = afd.Buscar(x, a[j].ToString(), prifil, valor);
                    if (res >= 0)
                    {
                        x = res;
                        bandera = true;
                    }
                    else
                    {
                        bandera = false;

                        break;

                    }
                }
                  if (bandera == true)
                    {

                        Object ux = Listafin[i].ToString().Remove(Listafin[i].ToString().Length - 1);

                        reconocidos.Add(ux.ToString());
                        x = 1;
                    }
               
                
                    else
                {
                    Object ux = Listafin[i].ToString().Remove(Listafin[i].ToString().Length - 1);
                    noreconocidos.Add(ux.ToString());
                    x = 1;
                    }
            }
            
                if (Estructura() == true)
                {
                    if (noreconocidos.Count == 0)
                    {
                        for (int j = 0; j < reconocidos.Count; j++)
                        {
                            txtb_listareco.AppendText(reconocidos[j].ToString() + "\n");
                        }
                    }
                    else
                    {
                        for (int j = 0; j < noreconocidos.Count; j++)
                        {
                            txtb_Error.AppendText("token (" + noreconocidos[j].ToString() + ") no fue reconocido por el automata\n");
                        }
                        reconocidos.Clear();
                        noreconocidos.Clear();
                    }

                }
                else
                {

                    reconocidos.Clear();
                }
                int d, m;
                for (int j = 0; j < reconocidos.Count; j++)
                {
                    if (reconocidos[j].Equals("declare"))
                    {
                        d = j;
                    }
                    if (reconocidos[j].Equals("main"))
                    {
                        m = j;
                    }
                }

                ReconocerTokens();
                MostrarTDS();
            
        }

        Queue<char> myQueue2;
        int a = 1;
        private void Btn_quitar_Click(object sender, RoutedEventArgs e)
        {

            analizarPalabra();
            if (myQueue2.Count > 0)
            {
                if (myQueue2.Last().Equals('$'))
                {
                    txtb_palabraactual.Clear();

                    txtb_transiciona.Clear();


                    String letra = myQueue2.ElementAt(0) + "";


                    int res = afd.Buscar(a, letra, prifil, valor);
                    if (res >= 0)
                    {


                        txtb_transiciona.AppendText(res.ToString());
                        a = Convert.ToInt16(txtb_transiciona.Text);

                        myQueue2.Dequeue();
                        for (int j = 0; j < myQueue2.Count; j++)
                        {

                            txtb_palabraactual.AppendText(myQueue2.ElementAt(j).ToString());


                        }

                    }
                    else
                    {
                        if (posicionlista < Listafin.Count)
                        {
                            afd.Siguiente(myQueue, Listafin, posicionlista);
                        }
                        a = 1;
                    }
                }
                else
                {
                    if (posicionlista < Listafin.Count)
                    {
                       afd.Siguiente(myQueue,Listafin,posicionlista);
                    }
                    myQueue2 = new Queue<char>();

                    char[] cadena = txtb_palabraactual.Text.ToString().ToCharArray();
                    txtb_palabraactual.Clear();
                    for (int j = 0; j < cadena.Length; j++)
                    {

                        myQueue2.Enqueue(cadena[j]);
                    }

                    for (int j = 0; j < cadena.Length; j++)
                    {
                        txtb_palabraactual.AppendText(myQueue2.ElementAt(j).ToString());
                    }
                    a = 1;
                }

            }
            else
            {
                //txtb_fin.AppendText("token reconocido");

                reconocidos.Add(Listafin[posicionlista].ToString());
                txtb_listareco.Clear();
                for (int j = 0; j < reconocidos.Count; j++)
                {
                    txtb_listareco.AppendText(reconocidos[j].ToString() + "\n");
                }
                if (posicionlista < Listafin.Count - 1)
                {
                       afd.Siguiente(myQueue,Listafin,posicionlista);
                 
                }
                a = 1;
            }
        }

        public void analizarPalabra()
        {
            myQueue2 = new Queue<char>();

            char[] cadena = txtb_palabraactual.Text.ToString().ToCharArray();
           txtb_palabraactual.Clear();
            for (int j = 0; j < cadena.Length; j++)
            {

                myQueue2.Enqueue(cadena[j]);
            }

            for (int j = 0; j < cadena.Length; j++)
            {
                txtb_palabraactual.AppendText(myQueue2.ElementAt(j).ToString());
            }
        }


        public void Siguiente()
        {


            myQueue = new Queue<char>();
            if (posicionlista + 1 < Listafin.Count)
            {
                char[] cadena = Listafin[posicionlista + 1].ToString().ToCharArray();

                for (int j = 0; j < cadena.Length; j++)
                {
                    myQueue.Enqueue(cadena[j]);
                }


                for (int j = 0; j < cadena.Length; j++)
                {

                    txtb_palabraactual.AppendText(myQueue.ElementAt(j).ToString());

                }
                posicionlista++;
            }
        }

        
        private void Btn_SiguientePos_Click(object sender, RoutedEventArgs e)
        {

            analizarPalabra();
            if (myQueue2.Count > 0)
            {
                if (myQueue2.Last().Equals('$'))
                {
                    txtb_palabraactual.Clear();

                    txtb_transiciona.Clear();


                    String letra = myQueue2.ElementAt(0) + "";


                    int res = afd.Buscar(a, letra, prifil, valor);
                    if (res >= 0)
                    {


                        txtb_transiciona.AppendText(res.ToString());
                        a = Convert.ToInt16(txtb_transiciona.Text);

                        myQueue2.Dequeue();
                        for (int j = 0; j < myQueue2.Count; j++)
                        {

                            txtb_palabraactual.AppendText(myQueue2.ElementAt(j).ToString());


                        }

                    }
                    else
                    {
                        if (posicionlista < Listafin.Count)
                        {
                            Siguiente();
                        }
                        a = 1;
                    }
                }
                else
                {
                    if (posicionlista < Listafin.Count)
                    {
                        Siguiente();
                    }
                    myQueue2 = new Queue<char>();

                    char[] cadena = txtb_palabraactual.Text.ToString().ToCharArray();
                    txtb_palabraactual.Clear();
                    for (int j = 0; j < cadena.Length; j++)
                    {

                        myQueue2.Enqueue(cadena[j]);
                    }

                    for (int j = 0; j < cadena.Length; j++)
                    {
                        txtb_palabraactual.AppendText(myQueue2.ElementAt(j).ToString());
                    }
                    a = 1;
                }

            }
            else
            {
                Object ux = Listafin[posicionlista].ToString().Remove(Listafin[posicionlista].ToString().Length - 1);
                reconocidos.Add(ux.ToString());
                txtb_listareco.Clear();
                for (int j = 0; j < reconocidos.Count; j++)
                {
                    txtb_listareco.AppendText(reconocidos[j].ToString() + "\n");
                }
                if (posicionlista < Listafin.Count - 1)
                {
                    Siguiente();
                }
                a = 1;
            }
        }

        public void MostrarTDS()
        {

            TipoDato tipod = new TipoDato();
int n = 0;
            for (int i = 0; i < Listorec.Count; i++)
            {
                String lexe = Listorec[i].Lexema;
                string numerotoken = tipod.RecoTipo(Convert.ToInt16(Listorec[i].NumToken));
              
                if (tipod.RecoTipo(Convert.ToInt16(Listorec[i].NumToken)).Equals("tipo"))//analiza si es un tipo int,double,string,char.etc. con el metodo RecoTipo
                {
                    for (int j = i; j < Listorec.Count; i++)
                    {
                        char c = Listorec[j + 1].Lexema[0];

                      
                        char lexema = Listorec[j + 2].Lexema[0];
                     

                            if (!Listorec[j].Lexema.Equals(";"))
                            {

                            char signo = Listorec[j + 1].Lexema[0];

                            if (Listorec[j + 1].Lexema[0].Equals('#') && !Listorec[j+2].Lexema.Equals(":="))
                            {
                                string lex = Listorec[j + 1].Lexema;
                                string le = lex.Remove(0, 1);
                                string tipo = lexe;
                                int analizartipo = tipod.TipoVariable(lexe);
                                n++;


                                TDS tds1 = new TDS(
                                n,
                                tipod.TipoVariable(lexe),
                                Listorec[j + 3].Lexema.Length,
                                le,
                                ""
                                );
                                tabla.Add(tds1);
                               
                            }
                            //if (Listorec[j + 1].Lexema[0].Equals('#') && Listorec[j+2].Lexema.Equals(":="))
                            //{
                            //    string lex = Listorec[j + 1].Lexema;
                            //    string le = lex.Remove(0, 1);
                            //    string tipo = lexe;
                            //    int analizartipo = tipod.TipoVariable(lexe);



                            //    TDS tds1 = new TDS(
                            //    Convert.ToInt16(Listorec[j].NumToken),
                            //    tipod.TipoVariable(lexe),
                            //    Listorec[j + 3].Lexema.Length,
                            //    le,
                            //    Listorec[j + 3].Lexema
                            //    );
                            //    tabla.Add(tds1);

                            //}

                            j = j + 2;

                        }
                            
                       


                        else
                            {
                                break;
                            }
                        
                    }
                }
                if (Listorec[i].Lexema.Equals("main")) { break; }


            }

           // tbl_TDS.ItemsSource = tabla;

        }

        public void ReconocerTokens() {
            tbl_reconocidos.ItemsSource = null;

            tbl_reconocidos.Columns.Clear();
            List<Token> to = new List<Token>();

            to = alfabeto.generarListaAlfabeto(alfabeto.Documento);


            for (int i = 0; i < reconocidos.Count; i++)
            {
                for (int j = 0; j < to.Count; j++)
                {
                    Token t = to.ElementAt(j);
                    String a = reconocidos[i].ToString();



                    if (t.Lexema.Equals(reconocidos[i]))
                    {
                        Listorec.Add(t);
                        break;
                    }

                    else if (reconocidos[i].ToString().Substring(0, 1).Equals("#"))
                    {
                        Token t1 = new Token(1, 'i', "identificador", reconocidos[i].ToString());
                        Listorec.Add(t1);
                        break;
                    }



                    int x = 0;

                    if (int.TryParse(reconocidos[i].ToString(), out x) == true)
                    {
                        Token t2 = new Token(43, 'a', "literalentero", reconocidos[i].ToString());
                        Listorec.Add(t2);
                        break;
                    }
                    
                    char primeracoma = reconocidos[i].ToString()[0];
                   
                    Console.WriteLine(primeracoma);
                    char ultimacomas = reconocidos[i].ToString()[reconocidos[i].ToString().Length-1];
                    Console.WriteLine(ultimacomas);


                    if (primeracoma==34) 
                    {   
                        Token t1 = new Token(1, 'a', "literalcadena", reconocidos[i].ToString());
                        Listorec.Add(t1);
                        break;
                    }







                }
            }

            tbl_reconocidos.ItemsSource = Listorec;

        }
        private void Btn_mostrarreco_Click(object sender, RoutedEventArgs e)
        {
           
           tbl_reconocidos.ItemsSource=null;
           
            tbl_reconocidos.Columns.Clear();
           List<Token> to = new List<Token>();
           
            to = alfabeto.generarListaAlfabeto(alfabeto.Documento);
          

            for (int i = 0; i < reconocidos.Count; i++)
            {
                for (int j = 0; j < to.Count; j++)
                {
                    Token t = to.ElementAt(j);
                   String a = reconocidos[i].ToString();


                    if (t.Lexema.Equals(reconocidos[i]))
                    {
                        Listorec.Add(t);
                        break;
                    }
               
                    else if (reconocidos[i].ToString().Substring(0, 1).Equals("#"))
                    {
                        Token t1 = new Token(1, 'i', "identificador", reconocidos[i].ToString());
                        Listorec.Add(t1);
                        break;
                    }

                 
                    int x=0;
                 
                    if (int.TryParse(reconocidos[i].ToString(), out x) == true)
                    {
                        Token t2 = new Token(43, 'a', "literalentero", reconocidos[i].ToString());
                        Listorec.Add(t2);
                        break;
                    }

                }
            }

            tbl_reconocidos.ItemsSource = Listorec;

        }
      
        public bool Estructura() {
            bool Bandera = false;
            for (int i = 0; i < reconocidos.Count; i++)
            {
                if (reconocidos[0].Equals("declare")) {
                   

                    Bandera = true;

                }
                else {
                    Bandera = false;
                    txtb_Error.AppendText("no hay espacio de declare");
                    break;
                }


                int mainindice = 0;
                for (int x = 0; x < reconocidos.Count; x++)
                {
                    if (reconocidos[x].Equals("main")) {
                        mainindice = x;
                    }
                }

                    if (!reconocidos.Contains("main"))
                {
                    Bandera = false;
                    txtb_Error.AppendText("no declaro main principal");
                    break;

                }

            
                if (td.RecoTipo(reconocidos[i].ToString()).Equals("tipo"))
                {
                  String cost=  reconocidos[i + 1].ToString().Substring(0, 1);



                    if (!cost.Equals("#") && !reconocidos[i + 2].ToString().Equals(","))
                    {
                        Bandera = false;
                        txtb_Error.AppendText("variable tipo (" + reconocidos[i].ToString() + ")sin identificador");
                        // reconocidos.Clear();
                        break;

                    }
                   


                }
                if (reconocidos[i].Equals("main"))
                {
                    int posicion = i+1;
                    for(int j=posicion;posicion<reconocidos.Count;posicion++){

                        if (td.RecoTipo(reconocidos[posicion].ToString()).Equals("tipo"))
                        {
                            Bandera = false;
                            txtb_Error.AppendText("no se permite declaracion de variables despues de main");
                            reconocidos.Clear();
                            break;
                        }
                        else { Bandera = true; } 
                    }
                }



                }
                return Bandera;
        }

        private void Txtb_texto_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
      
       static List<TDS> tabla= new List<TDS>();

        internal static List<Token> Listorec { get => listorec; set => listorec = value; }
        internal static List<Token> Alfa { get => alfa; set => alfa = value; }
        internal static List<TDS> Tabla { get => tabla; set => tabla = value; }

        private void Btn_mostrarTDS_Click(object sender, RoutedEventArgs e)
        {
         }

        private void Btnmostrartkr_Click(object sender, RoutedEventArgs e)
        {
            TKR r = new TKR();
            r.tbl_tkr.ItemsSource = Listorec;
            r.Show();
        }

        private void Btnmostrartds_Click(object sender, RoutedEventArgs e)
        {
            mostrarTDS tds = new mostrarTDS();
            tds.tbl_tds.ItemsSource = tabla;
            tds.Show();
        }
    }
}
