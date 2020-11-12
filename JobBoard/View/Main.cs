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

            //Set min date at the current date
            dtpExpires.MinDate = DateTime.Now;
        }


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
            //Insert query
            string txtQuery = "INSERT INTO Fields (Job,JobTitle,Description,CreatedAt,ExpiresAt)" +
                "VALUES('" + txtJob.Text + "','"+txtJobTitle.Text+"','"+ txtDescription.Text +"','"+ DateTime.Now.ToString("MM/dd/yyyy") +"','"+ dtpExpires.Text +"')";

            //Call execute query to add a job
            Query.ExecuteQuery(txtQuery);

            //Reload dataGridView
            LoadDataGrid();

            //Reset Forms
            txtJob.Text = "";
            txtJobTitle.Text = "";
            txtDescription.Text = "";
            dtpExpires.Value = DateTime.Now;
        }

        //Edit Job
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        //Delete Job
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Fill form data
            txtJob.Text = dgvBoard.SelectedRows[0].Cells[1].Value.ToString();
            txtJobTitle.Text = dgvBoard.SelectedRows[0].Cells[2].Value.ToString();
            txtDescription.Text = dgvBoard.SelectedRows[0].Cells[3].Value.ToString();
            dtpExpires.Value = DateTime.ParseExact(dgvBoard.SelectedRows[0].Cells[5].Value.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
