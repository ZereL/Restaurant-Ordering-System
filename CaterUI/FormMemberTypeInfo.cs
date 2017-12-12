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
    public partial class FormMemberTypeInfo : Form
    {
        public FormMemberTypeInfo()
        {
            InitializeComponent();
        }

        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();

        private DialogResult result = DialogResult.Cancel;

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = mtiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text)
            };
            if (txtId.Text.Equals("No ID"))
            {
                if (mtiBll.Add(mti))
                {
                    LoadList();
                }
            }
            else
            {
                mti.MId = int.Parse(txtId.Text);
                if (mtiBll.Edit(mti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
            txtId.Text = "No ID";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "Add";

            result = DialogResult.OK;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "Edit";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row = dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            //确认
            DialogResult result = MessageBox.Show("Delete？", "Alert", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (mtiBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("Falied");
            }

            result = DialogResult.OK;
        }

        private void FormMemberTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
