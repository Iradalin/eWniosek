using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;//wskazywanie folderu zapisu
using mysettings = eWniosek.Properties.Settings;
using MySql.Data.MySqlClient;

using System.IO;//wskazywanie folderu zapisu
using Novacode;//dotyczy dodatku DocX

namespace eWniosek
{
    public partial class KartaKM : Form
    {
        public string sciezkaZapisu;
        public string dbconnection_string;
        public KartaKM()
        {
            InitializeComponent();
            // flowLayoutPanelUzasadnienie.Controls.Add(textBoxUzasadnienie);
            ladujDane();
        } 
        private void ladujDane()
          {
              //Wczytanie z ustwień 
            textBoxInicjały.Text = mysettings.Default.Inicjały;//Inicjały
            textBoxNumerTeczki.Text = mysettings.Default.NumerTeczki;//Numer teczki
            textBoxMiejscowoscJednostki.Text = mysettings.Default.NazwaJednostki;//Nazwa jednostki
            textBoxData.Text = DateTime.Now.ToShortDateString();// Aktualna Data
            textBoxAdresat.Text = mysettings.Default.Adresat;// Adresat
            textBoxNadawca.Text = mysettings.Default.Nadawca;// Nadawca
            textBoxLiczba1.Text = mysettings.Default.LdzLiczba1.ToString();
            textBoxLiczba2.Text = mysettings.Default.LdzLiczba2.ToString();
            textBoxRok.Text = mysettings.Default.Rok.ToString();
            sciezkaZapisu = mysettings.Default.ŚcieżkaZapisu;
            comboBoxNazwaJednostkiOrganizacyjnej1.Text = mysettings.Default.NazwaJednostki;
         //  labelNazwaJednostki2.Text = mysettings.Default.NazwaJednostki;
            //Załadowanie do list z imieniem i nazwiskiem do combobox 
            ComboBox[] tableComboBoxImieNazwisko = { comboBoxImieNazwisko1, comboBoxImieNazwisko2 };
            UstawComboBoxImieNazwisko(tableComboBoxImieNazwisko);
            //Załadowanie czynności do wykonania 
            ComboBox[] tableComboBoxRodzajCzynnosci = { comboBoxCzynnosc1, comboBoxCzynnosc2 };
            UstawComboBoxCzynnosc(tableComboBoxRodzajCzynnosci);
            //Załadowanie do combobox rodzaju użytkownika(funkcjonariusz, cywil, inna instytucja)
            ComboBox[] tableComboBoxRodzajFunkcjonariusza = { comboBoxRodzaj1, comboBoxRodzaj2 };
            UstawComboBoxRodzajFuncjonariusza(tableComboBoxRodzajFunkcjonariusza);
            ComboBox[] comboBoxNazwaJednostki = { comboBoxNazwaJednostkiOrganizacyjnej1, comboBoxNazwaJednostkiOrganizacyjnej2};
            UstawComboBoxNazwaJednostkiOrganizacyjne(comboBoxNazwaJednostki);
        }


              
        //Kolumna 2 ComboBox z Imieniem i nazawiskiem z autouzupełnianiem
        private void UstawComboBoxImieNazwisko(ComboBox[] comboBox)
        {            
            foreach(ComboBox combobox in comboBox)
            {  
        try
        {
              this.dbconnection_string = "datasource=localhost;database=" + mysettings.Default.Database + ";port=" + mysettings.Default.port + ";username=" + mysettings.Default.user + ";password=" + mysettings.Default.password;
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                Database database = new Database();
                myDataAdapter = database.Select("select * from zestawienie", this.dbconnection_string);
                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);

                combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                combobox.Items.Clear();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dt.Rows[i]["nazwisko i imie"].ToString();
                item.Hidden_Id = dt.Rows[i]["ID"].ToString();
                item.Pesel = dt.Rows[i]["PESEL"].ToString();
                combobox.Items.Add(item);
            }

         }  catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                 }
                 }
     
        //wybór użytkownika wypełnia pozostałe formatyki PESEL I ID
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;
            string stringComboBoxImieNazwisko1 = "comboBoxImieNazwisko1";
            if (stringComboBoxImieNazwisko1.Equals(comboBox.Name.ToString()))
            {
                labelIDPESEL1.Text = (comboBox.SelectedItem as ComboboxItem).Hidden_Id.ToString() + Environment.NewLine + (comboBox.SelectedItem as ComboboxItem).Pesel.ToString();
                labelHidenID1.Text = (comboBox.SelectedItem as ComboboxItem).Hidden_Id.ToString() ;
                labelHidenPesel1.Text = (comboBox.SelectedItem as ComboboxItem).Pesel.ToString();
            }
            else
            {
                labelIDPESEL2.Text = (comboBox.SelectedItem as ComboboxItem).Hidden_Id.ToString() + Environment.NewLine + (comboBox.SelectedItem as ComboboxItem).Pesel.ToString();
                labelHidenID2.Text = (comboBox.SelectedItem as ComboboxItem).Hidden_Id.ToString();
                labelHidenPesel2.Text = (comboBox.SelectedItem as ComboboxItem).Pesel.ToString();
            }
          
        }
        //Kolumna 3 Rodzaj czynności do wykonania Combobox z wyborem
        private void UstawComboBoxCzynnosc(ComboBox[] comboBox)
        {
            foreach (ComboBox combobox in comboBox)
            {
                ComboboxItem[] items = { new ComboboxItem(), new ComboboxItem(), new ComboboxItem(), new ComboboxItem() };
                items[0].text = "A";
                items[1].text = "D";
                items[2].text = "R";
                items[3].text = "O";

                foreach (ComboboxItem item in items)
                {
                    combobox.Items.Add(item);
                }
                combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                combobox.Size = new Size(1500, 15);
            }
        }
        //Wypełnienie comboboxow z rodzajem funkcjonariusza
        private void UstawComboBoxRodzajFuncjonariusza(ComboBox[] comboBox)
        {
            foreach (ComboBox combobox in comboBox)
            {

                ComboboxItem[] items = { new ComboboxItem(), new ComboboxItem(), new ComboboxItem()};
                items[0].text = "F";
                items[1].text = "P";
                items[2].text = "I";
                foreach (ComboboxItem item in items)
                {
                    combobox.Items.Add(item);
                }
            }
        }
        
        private void UstawComboBoxNazwaJednostkiOrganizacyjne(ComboBox[] comboBox)
        {
            foreach (ComboBox label in comboBox)
            {
                label.Text = mysettings.Default.PelnaNazwaJednostki;
            }
        }

        
        //Obsługa przycisku Anuluj zamknięcie karty KM
        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            KartaKM.ActiveForm.Close();
        }
        //Obsługa przycisków dodawania i odejmowania do Ldz
        private void buttonLdzLiczba1Plus_Click(object sender, EventArgs e)
        {
            int temp = (Convert.ToInt32(textBoxLiczba1.Text.ToString()));
            textBoxLiczba1.Text = (temp +1).ToString();
        }
        private void buttonLdzLiczba1Minus_Click(object sender, EventArgs e)
        {
            int temp = (Convert.ToInt32(textBoxLiczba1.Text));
            textBoxLiczba1.Text = (temp-1).ToString();
        }
        private void buttonLdzLiczba2Plus_Click(object sender, EventArgs e)
        {
            int temp = (Convert.ToInt32(textBoxLiczba2.Text.ToString()));
            textBoxLiczba2.Text = (temp + 1).ToString();
        }
        private void buttonLdzLiczba2Minus_Click(object sender, EventArgs e)
        {
            int temp = (Convert.ToInt32(textBoxLiczba2.Text));
            textBoxLiczba2.Text = (temp - 1).ToString();
           
        }
        
     ///////////////////////////////////////////////////////////////////////////////////////
      //Zapis do ustawień liczb z Ldz podczas zamknięcia karty
  private void KartaKM_FormClosed(object sender, FormClosedEventArgs e)
  {
      mysettings.Default.LdzLiczba1 = Convert.ToInt32(textBoxLiczba1.Text);
      mysettings.Default.LdzLiczba2 = Convert.ToInt32(textBoxLiczba2.Text);
      mysettings.Default.Rok = textBoxRok.Text;
      Properties.Settings.Default.Save();
      Properties.Settings.Default.Upgrade();
  }
        //Tworzenie dokumentu DocX
  private void buttonZapiszDocX_Click(object sender, EventArgs e)
  {
     
      using (DocX document = DocX.Load("KM.docx"))
      {   
      document.ReplaceText("<Miejscowość>", textBoxMiejscowoscJednostki.Text);
      document.ReplaceText("<Data>", textBoxData.Text);
      document.ReplaceText("<Ldz>", textBox1.Text + textBoxLiczba1.Text + "/" + textBoxNumerTeczki.Text + "/" + textBoxLiczba2.Text + "/" + textBoxRok.Text + "/" +     textBoxInicjały.Text);
      document.ReplaceText("<Adresat>", textBoxAdresat.Text);
      document.ReplaceText("<Nadawca>", textBoxNadawca.Text);
          
      if (!comboBoxImieNazwisko1.Text.Equals(""))
      {
          document.ReplaceText("<ImieNazwisko1>", comboBoxImieNazwisko1.Text);
          document.ReplaceText("<Rodzaj1>",comboBoxRodzaj1.Text);
          document.ReplaceText("<Czynnosc1>", comboBoxCzynnosc1.Text);
          document.ReplaceText("<NumerKM1>", textBoxNumerKarty1.Text);
          document.ReplaceText("<ID1>", labelHidenID1.Text);
          document.ReplaceText("<PESEL1>", labelHidenPesel1.Text );
          document.ReplaceText("<Zalacznik1>", textBoxNumerKarty1.Text);
          if (!comboBoxImieNazwisko2.Text.Equals(""))
          {
              document.ReplaceText("<Znak1>", ",");
              document.ReplaceText("<ImieNazwisko2>", comboBoxImieNazwisko2.Text);
              document.ReplaceText("<Rodzaj2>", comboBoxRodzaj2.Text);
              document.ReplaceText("<Czynnosc2>", comboBoxCzynnosc2.Text);
              document.ReplaceText("<NumerKM2>", textBoxNumerKarty2.Text);
              document.ReplaceText("<ID2>", labelHidenID2.Text);
              document.ReplaceText("<PESEL2>", labelHidenPesel2.Text);
              document.ReplaceText("<Zalacznik2>", textBoxNumerKarty2.Text);
              document.ReplaceText("<Znak2>", ".");
          }
          else { document.ReplaceText("<Znak1>", ".");  
          document.ReplaceText("<Znak2>", "");
          document.ReplaceText("<Znak2>", "");
          document.ReplaceText("<ImieNazwisko2>", "");
          document.ReplaceText("<Rodzaj2>", "");
          document.ReplaceText("<Czynnosc2>", "");
          document.ReplaceText("<NumerKM2>", "");
          document.ReplaceText("<ID2>", "");
          document.ReplaceText("<PESEL2>", "");
          document.ReplaceText("<Zalacznik2>", "");
       
          }
      }
      else
      {
          throw new System.ArgumentException("Brak wybranego użytkownika", "original"); ;

      }
       if (!comboBoxImieNazwisko2.Text.Equals(""))
      {
          
      }
       
          //Usuwanie zbędnych pustych lini w całym dokumencie
          var emptyLines = document.Paragraphs.Where(o => string.IsNullOrEmpty(o.Text));
      foreach (var paragraph in emptyLines)
      {
          paragraph.Remove(false);
      }
      try
      {
          //Zapis dokumentu Scieżka zapisu I-PE- Liczba1 Liczba2 Inicjały
          document.SaveAs(sciezkaZapisu + "\\" + textBoxData.Text + " I-PE-" + textBoxLiczba1.Text + "-" + textBoxNumerTeczki.Text + "-" + textBoxLiczba2.Text + "-" + textBoxInicjały.Text + ".docx");
      }
      catch (IOException )
      {
          
          MessageBox.Show("Dokument o nazwie " + textBoxData.Text + " I-PE-" + textBoxLiczba1.Text + "-" + textBoxNumerTeczki.Text + "-" + textBoxLiczba2.Text + "-" + textBoxInicjały.Text + ".docx jest otwarty. Nie można dokonac zapisu"); 
          
      }
      }

  }

  private void KartaKM_Load(object sender, EventArgs e)
  {

  }

  

        }


}

       
    
