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
    public sealed partial class AjouterEmploye : Page
    {
        public AjouterEmploye()
        {
            this.InitializeComponent();
        }

        private void reset()
        {
            ErreurM.Visibility = Visibility.Collapsed;
            ErreurN.Visibility = Visibility.Collapsed;
            ErreurP.Visibility = Visibility.Collapsed;

            m.Text = " ";
            n.Text = " ";
            p.Text = " ";
           
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (m.Text.Trim() == "")
            {
                ErreurM.Visibility = Visibility.Visible;
                valide = false;
            }

            if (n.Text.Trim() == "")
            {
                ErreurN.Visibility = Visibility.Visible;
                valide = false;
            }
            if (p.Text.Trim() == "")
            {
                ErreurP.Visibility = Visibility.Visible;
                valide = false;
            }
           

            if (valide == true)
            {
                Employe cc = new Employe()
                {
                    Matricule = Convert.ToString(m.Text),
                    Nom = Convert.ToString(n.Text),
                    Prenom = Convert.ToString(p.Text),
                };

                GestionBD.getInstance().insererEmploye(cc);

                reset();
            }


        }
    }
}
