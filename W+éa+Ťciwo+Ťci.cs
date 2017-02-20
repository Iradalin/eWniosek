using System;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using mysettings = eWniosek.Properties.Settings;
using System.Linq;
using System.Data.Entity;

namespace eWniosek
{
    public partial class Właściwości : Form
    {
        private string dbconnection_string;
       
        
        public Właściwości()
        { 
            InitializeComponent();
         
              textBoxNazwaJednostki.Text=mysettings.Default.NazwaJednostki;
              textBoxInicjały.Text = mysettings.Default.Inicjały;
              textBoxNumerTeczki.Text = mysettings.Default.NumerTeczki;
              textBoxAdresat.Text = mysettings.Default.Adresat;
              textBoxNadawca.Text = mysettings.Default.Nadawca;
              textBoxPort.Text = mysettings.Default.port;
              textBoxNazwaBazy.Text =mysettings.Default.Database ;
              textBoxUżytkownik.Text=mysettings.Default.user ;
              textBoxHasło.Text= mysettings.Default.password ;
              textBoxŚcieżkaZapisu.Text = mysettings.Default.ŚcieżkaZapisu;
              textBoxPelnaNazwaJednostki.Text = mysettings.Default.PelnaNazwaJednostki;
           
        }

        private void Właściwości_Load(object sender, EventArgs e)
        {

        }
        //Przycisk Zapisz
        private void button1_Click(object sender, EventArgs e)
        {
             mysettings.Default.NazwaJednostki = textBoxNazwaJednostki.Text;
             mysettings.Default.Inicjały = textBoxInicjały.Text;
             mysettings.Default.NumerTeczki = textBoxNumerTeczki.Text;
             mysettings.Default.Adresat = textBoxAdresat.Text;
             mysettings.Default.Nadawca = textBoxNadawca.Text;
             mysettings.Default.port = textBoxPort.Text;
             mysettings.Default.Database = textBoxNazwaBazy.Text;
             mysettings.Default.user = textBoxUżytkownik.Text;
             mysettings.Default.password = textBoxHasło.Text;
             mysettings.Default.ŚcieżkaZapisu = textBoxŚcieżkaZapisu.Text;
             mysettings.Default.PelnaNazwaJednostki = textBoxPelnaNazwaJednostki.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            System.Windows.Forms.MessageBox.Show("Zapisano");
            this.Close();
        }

        //Przycisk scieżki zapisu do pliku
        private void button1_Click_1(object sender, EventArgs e)
        {
          FolderBrowserDialog fbd = new FolderBrowserDialog();
          DialogResult result = fbd.ShowDialog();
          textBoxŚcieżkaZapisu.Text = fbd.SelectedPath;;
        }

        private void buttonDodajKomorkeOrganizacyjna_Click(object sender, EventArgs e)
        {

        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
