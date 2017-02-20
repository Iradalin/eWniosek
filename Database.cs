using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace eWniosek
{  
    class Database
    {

        public MySqlDataAdapter Select(string query, string db_connection){
                MySqlConnection myConn = new MySqlConnection(db_connection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand(query, myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
  
                    return myDataAdapter;
        }
     
      public void Delete(string query, string db_connection)
        {
            MySqlConnection MyConn = new MySqlConnection(db_connection);
            MySqlCommand MyCommand = new MySqlCommand(query, MyConn);
            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();
            MessageBox.Show("Data Deleted");
            while (MyReader.Read())
            {

            }
            MyConn.Close();

        }
     
      public void Update(string query, string db_connection)
      {
          try
          {
             
              MySqlConnection myConn = new MySqlConnection(db_connection);
              MySqlCommand MyCommand = new MySqlCommand(query, myConn);
              MySqlDataReader MyReader;
              myConn.Open();
              MyReader = MyCommand.ExecuteReader();
              MessageBox.Show("Data Updated");
              while (MyReader.Read())
              {

              }
              myConn.Close();


          }

          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
      }

      

        public void Insert(string query, string db_connection)
        {
            MySqlConnection conDataBase = new MySqlConnection(db_connection);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                
                while (myReader.Read())
                {
                    MessageBox.Show("DODANE");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
