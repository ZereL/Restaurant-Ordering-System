using CaterBll;
using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormHallInfo : Form
    {
        public FormHallInfo()
        {
            InitializeComponent();

            hiBll = new HallInfoBll();
        }

        private HallInfoBll hiBll;

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "Edit"; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo()
            {
                HTitle = txtTitle.Text
            };

            if (txtId.Text == "No ID")
            {
                //添加
                if (hiBll.Add(hi))
                {
                    LoadList();
                }
            }
            else
            {
                //修改
                hi.HId = int.Parse(txtId.Text);
                if (hiBll.Edit(hi))
                {
                    LoadList();
                }
            }

            txtId.Text = "No ID";
            txtTitle.Text = "";
            btnSave.Text = "Add";
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = hiBll.GetList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("Delete?","Alert",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (hiBll.Remove(id))
            {
                LoadList();
            }

        }
    }
}
