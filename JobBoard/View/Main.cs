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

            //Disable unused fields and buttons
            txtId.Enabled = false;
            txtId.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
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
            //Validate Fields

            if(txtJob.Text.Trim() != String.Empty && txtJobTitle.Text.Trim() != String.Empty && txtDescription.Text.Trim() != String.Empty)
            {
                //Calll method InsertFields with form data and validate process
                if(Query.InsertFields(txtJob.Text, txtJobTitle.Text, txtDescription.Text, dtpExpires.Text))
                {

                    MessageBox.Show("Added successfully");

                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Something went wrong");

                    ResetForm();
                }

            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }


            //Reload dataGridView
            LoadDataGrid();
        }

        //Edit Job
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate Fields

            if (txtJob.Text.Trim() != String.Empty && txtJobTitle.Text.Trim() != String.Empty && txtDescription.Text.Trim() != String.Empty)
            {
                //Show message to validate update
                if (MessageBox.Show("Are you sure you want to update the record "+ txtId.Text + "?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Calll method UpdateFields with form data
                    if(Query.UpdateFields(txtId.Text, txtJob.Text, txtJobTitle.Text, txtDescription.Text, dtpExpires.Text))
                    {
                        MessageBox.Show("Updated successfully");


                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");

                    }
                    ResetForm();

                    SetDefault();
                }
            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }

            //Reload dataGridView
            LoadDataGrid();

            ResetForm();

        }


        //Delete Job
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Show message to validate delete
            if (MessageBox.Show("Are you sure you want to delete the record " + txtId.Text + "?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Call method DeleteFields with id
                if(Query.DeleteFields(txtId.Text))
                {
                    MessageBox.Show("Deleted successfully");

                }
                else
                {
                    MessageBox.Show("Something went wrong");

                }

            }

            ResetForm();
            SetDefault();


            //Reload dataGridView
            LoadDataGrid();

        }

        //Restart buttons enabled properties
        private void SetDefault()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Enabled = true;
            dtpExpires.MinDate = DateTime.Now;
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
            try
            {
                //Enable delete and update buttons
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                dtpExpires.MinDate = new DateTime(2020, 11, 1);

                //Disable create button
                btnCreate.Enabled = false;

                //Fill form data
                txtId.Text = dgvBoard.SelectedRows[0].Cells[0].Value.ToString();
                txtJob.Text = dgvBoard.SelectedRows[0].Cells[1].Value.ToString();
                txtJobTitle.Text = dgvBoard.SelectedRows[0].Cells[2].Value.ToString();
                txtDescription.Text = dgvBoard.SelectedRows[0].Cells[3].Value.ToString();
                dtpExpires.Value = DateTime.ParseExact(dgvBoard.SelectedRows[0].Cells[5].Value.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                MessageBox.Show("Please use a side and valid column to select job");

                SetDefault();
                ResetForm();
            }
        }

        //Cancel delete and update status
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel changes?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SetDefault();

                ResetForm();
            }
                
        }
    }
}
