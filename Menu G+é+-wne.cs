using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eWniosek
{
    public partial class Menu_Główne : Form
    {
        public Menu_Główne()
        { 
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Właściwości f = new Właściwości();

            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.Sizable;
            f.Show(this); // Otwiera Włąściwości
        }

        private void buttonKartaKM_Click(object sender, EventArgs e)
        {
           
            KartaKM f = new KartaKM();
           
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.Sizable;
            f.Show(this); // Otwiera Karta KM
           // Podgląd p = new Podgląd();
          //  p.Show(this);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            TEST f = new TEST();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.Sizable;
            f.Show(this);
        }
    }
}
