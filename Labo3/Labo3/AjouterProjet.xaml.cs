using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Labo3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterProjet : Page
    {
        public AjouterProjet()
        {
            this.InitializeComponent();
        }

        private void reset()
        {
            ErreurN.Visibility = Visibility.Collapsed;
            ErreurD.Visibility = Visibility.Collapsed;
            ErreurB.Visibility = Visibility.Collapsed;
            ErreurBu.Visibility = Visibility.Collapsed;
            ErreurDe.Visibility = Visibility.Collapsed;

            n.Text = " ";
            d.Text = " ";
            b.Text = " ";
            de.Text = " ";
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (n.Text.Trim() == "")
            {
                ErreurN.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurN.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if (d.Text.Trim() == "")
            {
                ErreurD.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurD.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if (b.Text.Trim() == "") 
            {
                ErreurB.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurB.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if ((Convert.ToInt32(b.Text) <= 10000) || (Convert.ToInt32(b.Text) > 100000))
            {
                ErreurBu.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurBu.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if (de.Text.Trim() == "")
            {
                ErreurDe.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurDe.Visibility = Visibility.Collapsed;
                valide = true;
            }

         

            if (valide == true)
            {
                Projet cc = new Projet()
                {
                    Numero = Convert.ToString(n.Text),
                    Debut = Convert.ToDateTime(d.Text),
                    Budget = Convert.ToInt32(b.Text),
                    Description = Convert.ToString(de.Text),
                };

                GestionBD.getInstance().insererProjet(cc);

                reset();
                //mainFrame.Navigate(typeof(MainWindow));
                
            }

     


    }
    }
}
