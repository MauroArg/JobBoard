﻿using System;
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

        public static SQLiteConnection sqlCon;
        public static SQLiteCommand sqlCmd;
        public static SQLiteDataAdapter db;
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        //Set connection

        private static void SetConnection()
        {
            sqlCon = new SQLiteConnection("Data Source=data.db;Version=3;New=False;Compress=True");
        }

        //Set Executequery
        public  static void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sqlCon.Open();
            sqlCmd = sqlCon.CreateCommand();
            sqlCmd.CommandText = txtQuery;
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
           
        }

        //Load Data
        public static DataTable LoadData()
        {
            SetConnection();
            sqlCon.Open();
            sqlCmd = sqlCon.CreateCommand();
            string commandText = "SELECT * FROM Fields";
            db = new SQLiteDataAdapter(commandText, sqlCon);
            ds.Reset();
            db.Fill(ds);
            dt = ds.Tables[0];
            sqlCon.Close();
            return dt;
        }

        //Insert a Job
        public static bool InsertFields (string job, string jobTitle, string description, string expiresAt)
        {
            bool res;

            try
            {
                //Insert query
                string txtQuery = "INSERT INTO Fields (Job,JobTitle,Description,CreatedAt,ExpiresAt)" +
                    "VALUES('" + job + "','" + jobTitle + "','" + description + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + expiresAt + "')";

                //Call execute query to add a job
                ExecuteQuery(txtQuery);
                res = true;
            }
            catch(Exception)
            {
                res = false;
            }

            return res;
        }

        //Update a Job
        public static bool UpdateFields(string id, string job, string jobTitle, string description, string expiresAt)
        {
            bool res;

            try
            {
                //Update Query
                string txtQuery = "UPDATE Fields SET Job='" + job + "', JobTitle='" + jobTitle + "', Description='" + description + "', ExpiresAt='" + expiresAt + "' WHERE Id=" + id;

                //Call execute query to update a job
                ExecuteQuery(txtQuery);

                res = true;
            }
            catch(Exception)
            {
                res = false;
            }

            return res;
        }

        //Delete a Job
        public static bool DeleteFields(string id)
        {
            bool res;

            try
            {
                //Delete Query
                string txtQuery = "DELETE FROM Fields WHERE Id=" + id;

                //Call execute query to delete a job
                Query.ExecuteQuery(txtQuery);

                res = true;
            }
            catch(Exception)
            {
                res = false;
            }

            return res;
        }


    }
}
