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
            Query.InsertFields(txtJob.Text, txtJobTitle.Text, txtDescription.Text, dtpExpires.Text);

            //Reload dataGridView
            LoadDataGrid();

            ResetForm();
        }

        //Edit Job
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string txtQuery = "UPDATE Fields SET Job='"+ txtJob.Text +"', JobTitle='"+ txtJobTitle.Text +"', Description='"+ txtDescription.Text +"', ExpiresAt='"+ dtpExpires.Text + "' WHERE Id="+txtId.Text;

            //Call execute query to add a job
            Query.ExecuteQuery(txtQuery);

            //Reload dataGridView
            LoadDataGrid();

            ResetForm();

        }


        //Delete Job
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string txtQuery = "DELETE FROM Fields WHERE Id=" + txtId.Text;

            //Call execute query to add a job
            Query.ExecuteQuery(txtQuery);

            //Reload dataGridView
            LoadDataGrid();

            ResetForm();
        }



        //Reset Form
        private void ResetForm()
        {
            txtId.Text = "";
            txtJob.Text = "";
            txtJobTitle.Text = "";
            txtDescription.Text = "";
            dtpExpires.Value = DateTime.Now;
        }

        private void dgvBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Fill form data
            txtId.Text = dgvBoard.SelectedRows[0].Cells[0].Value.ToString();
            txtJob.Text = dgvBoard.SelectedRows[0].Cells[1].Value.ToString();
            txtJobTitle.Text = dgvBoard.SelectedRows[0].Cells[2].Value.ToString();
            txtDescription.Text = dgvBoard.SelectedRows[0].Cells[3].Value.ToString();
            dtpExpires.Value = DateTime.ParseExact(dgvBoard.SelectedRows[0].Cells[5].Value.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
