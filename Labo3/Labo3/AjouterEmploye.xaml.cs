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
            pb.Text = " ";
            de.Text = " ";
            em.Text = " ";
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (n.Text.Trim() == "")
            {
                ErreurN.Visibility = Visibility.Visible;
                valide = false;
            }

            if (d.Text.Trim() == "")
            {
                ErreurD.Visibility = Visibility.Visible;
                valide = false;
            }
            if (b.Text.Trim() == "")
            {
                ErreurB.Visibility = Visibility.Visible;
                valide = false;
            }
            if (de.Text.Trim() == "")
            {
                ErreurDe.Visibility = Visibility.Visible;
                valide = false;
            }

            if (em.Text.Trim() == "")
            {
                ErreurE.Visibility = Visibility.Visible;
                valide = false;
            }

            if (valide == true)
            {
                Projet cc = new Projet()
                {
                    Numero = Convert.ToString(n.Text),
                    Debut = Convert.ToDateTime(d.Text),
                    Budget = Convert.ToInt32(b.Text),
                    Description = Convert.ToString(de.Text),
                    Employe = Convert.ToString(em.Text)
                };

                GestionBD.getInstance().insererProjet(cc);

                reset();
            }


        }
    }
}
