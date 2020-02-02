using NavigationDrawerPopUpMenu2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationDrawerPopUpMenu2
{
    public partial class FrmTransicion : Form
    {
        public FrmTransicion()
        {
            InitializeComponent();
        }
        Movimiento afd = new Movimiento();

        private void button1_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            
        }
        string rutaCSV = @"E:\UTN\VII SEMESTRE\COMPILADORES\comas.txt";
        Object[,] prifil;
        Object[,] valor;
        private void butto_Click(object sender, EventArgs e)
        {

            LeerMatrizAFD lm;
            OpenFileDialog buscar = new OpenFileDialog
            {
                InitialDirectory = @"E:\UTN\VII SEMESTRE\COMPILADORES",
                Title = "Examniar ALFABETO ",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt;*.xml)|*.txt;*.xml", //solo permite cargar txt y xml
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            buscar.ShowDialog();
            string rutamatriz;
            rutamatriz = buscar.FileName;
            lm = new LeerMatrizAFD(rutamatriz);
            // int [,] m = lm.crearMatrizTransicion(rutaCSV);
           string [,] m= lm.matrizTransicion;
            lm.generarTableMatrizTransicion(tblTransicion, m);
            lm.imprimirTablaMatrizTransicion(tblTransicion, m);


        }
   

        public void Print(Object[,] est, RichTextBox rtb)
        {
            string s = "\n";

            for (int i = 0; i < est.GetLength(0); i++)
            {
                s += "     ";
                for (int j = 0; j < est.GetLength(1); j++)
                {
                    s += est[i, j].ToString() + "  ";

                }

                s += "\n";
            }
            s += "\n";
            rtb.AppendText(s);

        }


    }
}
