using Microsoft.Win32;
using NavigationDrawerPopUpMenu2.Clases;
using NavigationDrawerPopUpMenu2.Clases.Sintactico;
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
    public partial class winSintactico : UserControl
    {
        
        //Gramatica g= new Gramatica(@"C:\Users\Samantha1\Desktop\Gramatica_SLR.xml");
        //Transicion tr = new Transicion(@"C:\Users\Samantha1\Desktop\Gramatica_SLR.xml");
         Gramatica g= new Gramatica(@"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\Gramatica_SLR.xml");
        Transicion tr = new Transicion(@"E:\UTN\VII SEMESTRE\COMPILADORES\PJT_ANALIZ_SEMANTICO\v4\ProyectoACSv3\archivos\Gramatica_SLR.xml");

        public winSintactico()
        {
            InitializeComponent();
           
        }


      
        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
        FirstNext fn = new FirstNext();
        TipoDato td = new TipoDato();
        Movimiento afd = new Movimiento();
      
   
        ArrayList Listafin;
        ArrayList reconocidos = new ArrayList();
        ArrayList noreconocidos = new ArrayList();
        List<FirstNext> FN = new List<FirstNext>();
        TDS tds = new TDS();
        List<string> der= new List<string>();
        List<char> izq = new List<char>();
        List<Produccion> P = new List<Produccion>();
        static List<Produccion> ReglaReco = new List<Produccion>();
        List<Transicion> GoTo = new List<Transicion>();
        List<Transicion> accion = new List<Transicion>();

        winLexical wl = new winLexical();
        List<Token> tkr = new List<Token>();
        public Stack<object> pila = new Stack<object>();
        int nerror = 0;
        int idtk = 0;
        int estado;
        int n;
        int newEstado;
        int regla;
        Token tk = new Token();
        AnalizadorSLR slr = new AnalizadorSLR();
        List<Printsintactico> print = new List<Printsintactico>();

        internal static List<Produccion> ReglaReco1 { get => ReglaReco; set => ReglaReco = value; }

        private void Btn_fyn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog buscar = new OpenFileDialog();
            buscar.Filter = "Archivos TXT|*.txt";
            if (buscar.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(buscar.FileName, System.Text.Encoding.ASCII);
                while (!sr.EndOfStream) // mientras no llegue a la linea final
                {
                    string[] linea = sr.ReadLine().Split('\t');
                   string nt = linea[0];
                   string first = linea[1];
                  string  next = linea[2];
                    FirstNext fn = new FirstNext(nt, first, next);
                    FN.Add(fn);

                }
                sr.Close();
            }

            tbl_fn.ItemsSource= FN;

            


        }

        private void Txtb_gramatica_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_cargarGramatica_Click(object sender, RoutedEventArgs e)// carga las producciones usando metodos de la clase Gramatica
        {
            List<Token> troken = winLexical.Alfa;
            int r = winLexical.Listorec.Count;
            for (int i = 0; i < r; i++)
            {
                int numToken = winLexical.Listorec[i].NumToken;
                char sinonimo = winLexical.Listorec[i].Sinonimo;
                string nombreToken = winLexical.Listorec[i].NombreToken;
                string lexema = winLexical.Listorec[i].Lexema;

                Token t = new Token(numToken, sinonimo, nombreToken, lexema);
                tkr.Add(t);

            }
            Token tr = new Token(tkr.Count+1, '~', "blanco", "$");
            // tbl_reco.ItemsSource = tkr;
            tkr.Add(tr);
           // tbl_reco.ItemsSource = tkr;


            der = g.AsignarListaT();
            izq = g.AsignarNoT();
            P = g.AsignarProd();

            txtb_gramatica.AppendText("T= {");
            for (int i = 0; i < der.Count; i++)
            {
               
                txtb_gramatica.AppendText(der[i]+", " );
            }
            txtb_gramatica.AppendText("}\n");

            txtb_gramatica.AppendText("N= {");
            for (int i = 0; i < izq.Count; i++)
            {

                txtb_gramatica.AppendText(izq[i] + ", ");
            }
            txtb_gramatica.AppendText("}");

            txtb_gramatica.AppendText("P= {");
            for (int i = 0; i < P.Count; i++)
            {

                txt_produccion.AppendText(P[i].n +" : "+P[i].izq+" -> "+P[i].der+"\n");
            }
            txtb_gramatica.AppendText("}");
        }

        private void Btn_cargarAP_Click(object sender, RoutedEventArgs e)// carga el Goto y accion usando metodos de la clase Transicion
        {
            GoTo = tr.list_GoTo();
            accion = tr.Accion();

            for (int i = 0; i < accion.Count; i++)
            {
                txtb_accion.AppendText(accion[i].eInicial + "   " + accion[i].lee + "   " + accion[i].eFinal + "\n");
            }
            for (int i = 0; i < GoTo.Count; i++)
            {
                txt_Goto.AppendText(GoTo[i].eInicial + "   " + GoTo[i].lee + "   " + GoTo[i].eFinal + "\n");
            }
           


        }

        public void Btn_movimiento_Click(object sender, RoutedEventArgs e)
        {
            Btn_cargarGramatica_Click(sender, e);
            Btn_cargarAP_Click(sender, e);
            pila.Push(estado);

            String cadenapila="";
            String entrada="";
            do {
               
                estado = Convert.ToInt16(pila.First());
                char sinonimo = tkr[idtk].Sinonimo;
                newEstado = buscarColumna(estado, sinonimo);

                if (newEstado != 0)
                {
                    for (int i = 0; i < pila.Count; i++)
                    {
                        cadenapila += pila.ElementAt(i) + ", ";
                    }
                    print.Add(new Printsintactico(cadenapila, "", ""));
                    cadenapila = "";

                    for (int i = idtk; i < tkr.Count; i++)
                    {
                        entrada += tkr.ElementAt(i).Sinonimo + " ";
                    }
                    print[print.Count - 1].en = entrada;
                    entrada = "";

                }

                if (newEstado > 0 && newEstado < 200)
                {

                    pila.Push(sinonimo);
                    pila.Push(newEstado);
                    idtk++;
                    print[print.Count - 1].a = "desplaza";


                }
                else if (newEstado < 0 )
                {
                    //aqui es reconocimiento de regla
                    int regla0 = P[15].n;

                    int regla = -newEstado; //cambiamos de signo para que busque la regla 
                    //if (regla == 32) {
                    //    int r = -newEstado;
                    //}
                    char parteizq = P[regla-1].izq;
                    String parteder = P[regla-1].der;
                   print[print.Count - 1].a = "reconoce" +" ("+parteizq+"-->"+parteder+")";
                    
                    int longitud_regla;
                    if (P[regla - 1].der.Equals("λ"))
                    {
                        longitud_regla = 0;
                    }

                    else
                    {
                       longitud_regla = P[regla - 1].der.Length;
                    }
                    char noterminal = P[regla-1].izq; // pendiente

                    for (int i = 1; i <= 2 * longitud_regla; i++)
                    {
                      
                  
                        
                            pila.Pop();
                        
                    }
                    int numeropila = Convert.ToInt16(pila.First());
                    estado = buscarColumnaGoTo(numeropila, noterminal);
                    if (estado == 0)   //sirve para ver el error==============================
                    {
                        int numeroactpila = numeropila;
                        char noterminalactual = noterminal;
                    }//========================================================================

                    pila.Push(noterminal);

                    pila.Push(estado);
                    if (regla == 12)
                    {
                        Produccion p = new Produccion(regla - 1, P[regla - 2].izq, P[regla-2].der , tkr[idtk - 3].Lexema, tkr[idtk - 1].NombreToken);
                        ReglaReco.Add(p);

                    }

                    if (regla == 32)
                    {
                        Produccion p = new Produccion(regla, P[regla -1].izq, P[regla-1].der, tkr[idtk - 2].Lexema, tkr[idtk - 1].NombreToken);
                        ReglaReco.Add(p);

                    }

                    if (regla == 56 || regla == 58 || regla == 39)
                    {
                        Produccion p = new Produccion(regla, parteizq, parteder, tkr[idtk - 1].Lexema, tkr[idtk - 1].NombreToken);
                      
                        ReglaReco.Add(p);

                        /*imprimir("uuuuuuuu -> regla: " + regla + " r_partDer: " + reglas_parteDerechar(regla) + " n_term: " + no_terminal +
                            " numElem: " + numElementosParteDerecha + " lexema: " + this.listaTokens[idtk].lexema);*/
                        if (regla == 39) {
                            for(int i = idtk-1; i>0; i--)
                            {
                                if (tkr[i].Lexema == ":=") {
                                    p.dato = tkr[i - 1].Lexema;
                                    break;

                                }


                            }
                        }

                    }
                    else if(regla!=32)
                    {
                        ReglaReco.Add(new Produccion(regla, parteizq, parteder, tkr[idtk - 1].Lexema, tkr[idtk - 1].NombreToken));

                    }

                }
                else if (newEstado == 999)
                {
                   print[print.Count - 1].a = "Fin";
                 
                    break;
                }
                else if(newEstado == 0)
                {
                    char s = tkr[idtk].Sinonimo;
                    int estadoactual = estado;
                    buscarColumna(estado, sinonimo);
                    nerror++;
                }
            } while (nerror <= 5);
            if (newEstado == 999 && nerror == 0)
            {
             tb_error.AppendText("programa fuente reconocido sin errores sintácticos");
            }
            else
            {
                
               print[print.Count - 1].a = "error";
               tb_error.AppendText("programa fuente con errores sintácticos");
            }
        }

        int buscarColumna(int estado, char c)
        {

            int res = 0;
            for (int i = 0; i < accion.Count; i++)
            {
                int est = estado;
                int a = accion[i].eInicial;
                if (accion[i].eInicial == estado)

                {
                    char caracter = c;
                    char lee = accion[i].lee;
                    int fin = accion[i].eFinal;

                    if (lee.Equals(caracter))
                    {
                        res = accion[i].eFinal;
                        break;
                    }
                    
                }
            }
            return res;
        }

        

        int buscarColumnaGoTo(int estado, char c)
        {
            int res = 0;
            for (int i = 0; i < GoTo.Count; i++)
            {
                int est = estado;
                int a = GoTo[i].eInicial;
                if (GoTo[i].eInicial == estado)

                {
                    char caracter = c;
                    char lee = GoTo[i].lee;
                    int fin = GoTo[i].eFinal;

                    if (lee.Equals(caracter))
                    {
                        res = GoTo[i].eFinal;
                              break;
                    }
                  
                }
            }
            return res;
        }


        public void imprimir(string a)
        {
            Console.WriteLine(a);
        }
        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Txtb_error_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_mostrar_Click(object sender, RoutedEventArgs e)
        {
            movimientos m = new movimientos();
            m.tbl_movimientos.ItemsSource = print;
            m.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reglasreconocidas r = new reglasreconocidas();
            r.tbl_reglasreconocidas.ItemsSource = ReglaReco;
            r.Show();
        }
    }
}
