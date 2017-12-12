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
    public partial class FormManagerInfo : Form
    {
        private FormManagerInfo()
        {
            InitializeComponent();
        }
        private static FormManagerInfo _form;
        public static FormManagerInfo Create()
        {
            if (_form == null)
            {
                 _form = new FormManagerInfo();
            }

            return _form;
        }

        ManagerInfoBll miBll = new ManagerInfoBll();

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rb1.Checked ? 1 : 0
            };
            if (txtId.Text.Equals("No ID"))
            {
                if (miBll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                mi.Mid = int.Parse(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
            }
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "Add";
            txtId.Text = "No ID";
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "Manager" : "Staff";
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            txtPwd.Text = "这是原来的密码";
            btnSave.Text = "Edit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "No ID";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "Add";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var rows = dgvList.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Delete?", "Alert", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                int id = int.Parse(rows[0].Cells[0].Value.ToString());

                if (miBll.Remove(id))
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Select a row");
            }
        }

        private void FormManagerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
