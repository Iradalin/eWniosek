using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;
using mysettings = eWniosek.Properties.Settings;

namespace eWniosek
{
    public partial class Podgląd : Form
    {
        
        public Podgląd()
        {
            InitializeComponent();
//

           // System.IO.DriveInfo di = new System.IO.DriveInfo("H:\\Users\\Maciej\\Documents\\Visual Studio 2012\\Projects\\eWniosek\\eWniosek\\bin\\Debug");
         //   Console.WriteLine(di.TotalFreeSpace);
          //  Console.WriteLine(di.VolumeLabel);
            ListView listView1 = new ListView();
            listView1.Bounds = new System.Drawing.Rectangle(new System.Drawing.Point(500, 500), new Size(300, 200));

            // Set the view to show details.
            listView1.View = System.Windows.Forms.View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;
            ListViewItem item1 = new ListViewItem();
            item1.Checked = true;
            
           // item1.SubItems.Add(di.TotalFreeSpace.ToString());
            //item1.SubItems.Add(dirInfo.Attributes.ToString());
           // item1.SubItems.Add(di.Name);
            string [] fileNames = System.IO.Directory.GetFiles(mysettings.Default.ŚcieżkaZapisu,"*.docx*");
            ListViewItem a = new ListViewItem();

            foreach (string s in fileNames)
            {
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    // To inform the user and continue is
                    // sufficient for this demonstration.
                    // Your application may require different behavior.
                   MessageBox.Show(e.Message);
                    continue;
                }
                ListViewItem curent = new ListViewItem();
                curent.SubItems.Add(fi.Name.ToString());
                curent.SubItems.Add(fi.LastAccessTime.ToShortDateString());
                curent.SubItems.Add(fi.Length.ToString());
                curent.SubItems.Add(fi.DirectoryName.ToString());
                listView1.Items.AddRange(new ListViewItem[] { curent });
               
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);
             listView1.SelectedIndexChanged+= new System.EventHandler(selected);
           // listView1.Items.AddRange(new ListViewItem[] { item1 });
            this.Controls.Add(listView1);
             
        }
        private void selected(object sender, System.EventArgs e)
        {
           
           
                DocBrowser docBrowser1 = new DocBrowser();

                docBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
                docBrowser1.Location = new System.Drawing.Point(0, 0);
                docBrowser1.MinimumSize = new System.Drawing.Size(200, 200);
                docBrowser1.Name = "webBrowser1";
                docBrowser1.Size = new System.Drawing.Size(532, 514);
                docBrowser1.TabIndex = 0;
                this.Controls.Add(docBrowser1);
                ListView l = (ListView)sender;
                // 
                //MessageBox.Show("A");

                ListView.SelectedListViewItemCollection breakfast = l.SelectedItems;
                foreach (ListViewItem item in breakfast)
                {
                    docBrowser1.LoadDocument(mysettings.Default.ŚcieżkaZapisu + "\\" + item.SubItems[1].Text);
                   

                }
            }
           
           // docBrowser1.Dispose();
            //docBrowser1.LoadDocument();
            // Output the price to TextBox1.
            //TextBox1.Text = price.ToString();
            
        }
      
    }
 

