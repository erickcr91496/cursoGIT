using Microsoft.Win32;
using NavigationDrawerPopUpMenu2.Clases;
using NavigationDrawerPopUpMenu2.Clases.Semantico;
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
    public partial class winSemantico : UserControl
    {

        Funciones f = new Funciones();
        public winSemantico()
        {
            InitializeComponent();
           
        }


        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
        
   
       

       

        private void Txtb_gramatica_TextChanged(object sender, TextChangedEventArgs e)
        {

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
           
        }

        private void Btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            winLexical wl = new winLexical();
            winSintactico ws = new winSintactico();
            wl.Btn_reconocerTodo_Click(sender, e);
            ws.Btn_movimiento_Click(sender, e);
            f.GenerarCodigoCuadruplos();
        
        }

        private void Btn_mostrarCodigo_Click(object sender, RoutedEventArgs e)
        {

             codigointermedio c= new codigointermedio();
           
            List<Cuadruplos> CodigoIntermedio = Funciones.CodigoIntermedio1;
           
            c.tbl_codigointermedio.ItemsSource = null;

            c.tbl_codigointermedio.Columns.Clear();
            c.tbl_codigointermedio.ItemsSource = CodigoIntermedio;
        
        c.Show();
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TDSSemantico ws = new TDSSemantico();
            //   ws.tbl_TDS.ItemsSource=
            ws.tbl_TDS.ItemsSource = Funciones.ListaTDS;
            ws.Show();
        }

        private void btn_CargarSemantico(object sender, RoutedEventArgs e)
        {
            //codigointermedio c = new codigointermedio();

            //List<Cuadruplos> CodigoIntermedio = Funciones.CodigoIntermedio1;

            //c.tbl_codigointermedio.ItemsSource = null;

            //c.tbl_codigointermedio.Columns.Clear();
            //c.tbl_codigointermedio.ItemsSource = CodigoIntermedio;

            //// CARGAR TDS
            //TDSSemantico ws = new TDSSemantico();
            ////   ws.tbl_TDS.ItemsSource=
            //ws.tbl_TDS.ItemsSource = Funciones.ListaTDS;

            // 
            TablaSemantica ts = new TablaSemantica();
            ts.Show();
        }

        private void btn_nuevoArchivo(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            winLexical le = new winLexical();
            
           
            
            
        }
    }
}
