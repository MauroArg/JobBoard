using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace JobBoard.Controller
{

    class Query
    {
        //SQLite variables to use querys

        private SQLiteConnection sqlCon;
        private SQLiteCommand sqlCmd;
        private SQLiteDataAdapter db;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        //Set connection

        private void SetConnection()
        {
            sqlCon = new SQLiteConnection("Data Source=data.db;Version3;New=False;Compress=True");
        }

        //Set Executequery
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sqlCon.Open();
            sqlCmd = sqlCon.CreateCommand();
            sqlCmd.CommandText = txtQuery;
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
           
        }
    }
}
