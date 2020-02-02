using NavigationDrawerPopUpMenu2.Clases.Semantico;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Lógica de interacción para TablaSemantica.xaml
    /// </summary>
    public partial class TablaSemantica : Window
    {
        //Funciones f = new Funciones();

        public TablaSemantica()
        {
            InitializeComponent();
        }


        private void Btn_mostrarCodigo_Click(object sender, RoutedEventArgs e)
        {
           // TablaSemantica c = new TablaSemantica();

            List<Cuadruplos> CodigoIntermedio = Funciones.CodigoIntermedio1;

            tbl_cuadruplos.ItemsSource = null;

            tbl_cuadruplos.Columns.Clear();
            tbl_cuadruplos.ItemsSource = CodigoIntermedio;

            // CARGAR TDS
            //TDSSemantico ws = new TDSSemantico();
            //   ws.tbl_TDS.ItemsSource=
           tbl_tdsemntico.ItemsSource = Funciones.ListaTDS;
            tbl_reglas.ItemsSource = winSintactico.ReglaReco1;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
