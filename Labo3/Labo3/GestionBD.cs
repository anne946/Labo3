using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    internal class GestionBD
    {

        private MySqlConnection con;
        ObservableCollection<Projet> tableP;
        ObservableCollection<Employe> tableE;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=localhost;Database=prog;Uid=root;Pwd=root;");
            tableP = new ObservableCollection<Projet>();
            tableE = new ObservableCollection<Employe>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<Projet> getProjet()
        {
            tableP.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Projet c = new Projet()
                {
                    Numero = r.GetString("numero"),
                    Debut = r.GetDateTime("debut"),
                    Budget = r.GetInt32("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetString("employe")
                };
                tableP.Add(c);
            }
            r.Close();
            con.Close();

            return tableP;
        }




        public void insererProjet(Projet c)
        {
            string numero = c.Numero;
            DateTime debut = c.Debut;
            int budget = c.Budget;
            string description = c.Description;
            string employe = c.Employe;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into projet values(@numero, @debut, @budget, @description, @employe) ";

                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@debut", debut);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@employe", employe);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public ObservableCollection<Employe> getEmploye()
        {
            tableE.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Employe c = new Employe()
                {
                    Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom")
                };
                tableE.Add(c);
            }
            r.Close();
            con.Close();

            return tableE;
        }




        public void insererEmploye(Employe c)
        {
            string matricule = c.Matricule;
            string nom = c.Nom;
            string prenom = c.Prenom;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values(@matricule, @nom, @prenom) ";

                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        
        public ObservableCollection<Employe> rechercheE(string nom)
        {
            try
            {
                tableE.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from employe Where nom = '" + nom + "'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    Employe c = new Employe()
                    {
                        Matricule = r.GetString("matricule"),
                        Nom = r.GetString("nom"),
                        Prenom = r.GetString("prenom")
                    };
                    tableE.Add(c);
                }
                r.Close();
                con.Close();

                return tableE;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return null;
            }
            

        }

        public ObservableCollection<Projet> rechercheP(String debut)
        {
            try
            {
                tableE.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from projet Where debut = '" + debut + "'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    Projet c = new Projet()
                    {
                        Numero = r.GetString("numero"),
                        Debut = r.GetDateTime("debut"),
                        Budget = r.GetInt32("budget"),
                        Description = r.GetString("description"),
                        Employe = r.GetString("employe")
                    };
                    tableP.Add(c);
                }
                r.Close();
                con.Close();

                return tableP;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return null;
            }


        }

        public ObservableCollection<Employe> selectE()
        {
            try
            {
                tableE.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from employe";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    Employe c = new Employe()
                    {
                        Matricule = r.GetString("matricule"),
                        Nom = r.GetString("nom"),
                        Prenom = r.GetString("prenom")
                    };
                    tableE.Add(c);
                }
                r.Close();
                con.Close();

                return tableE;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return null;
            }


        }

    }
}
