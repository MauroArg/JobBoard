using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JobBoard.Controller;

namespace JobBoard

{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //SQLite variables to use querys

        private SQLiteConnection sqlCon;
        private SQLiteCommand sqlCmd;
        private SQLiteDataAdapter db;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        //Load Form
        private void Main_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        //Fill DatagridView
        private void LoadDataGrid()
        {
            dgvBoard.DataSource = Query.LoadData();
        }

        //Add Job
        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        //Edit Job
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        //Delete Job
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
