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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            

            //GridMain.Children.Clear();

            

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    //usc = new UserControlHome();
                    //GridMain.Children.Add(usc);
                    break;
                case "ItemLexico":
                    usc = new winLexical();
                    GridMain.Children.Add(usc);
                    break;

                case "itemSintactico":
                    
                    usc= new winSintactico();
                    GridMain.Children.Add(usc);
                   
                    break;

               

                case "itemSemantico":

                    usc = new winSemantico();
                    GridMain.Children.Add(usc);
                    break;



            }
        }






        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ItemLexico_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ItemSintactico_Selected(object sender, RoutedEventArgs e)
        {
            

        }

        private void ItemSemantico_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ItemPrograma_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNuevoApp(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            //Application.Current.Activated();
           


        }
    }
}
