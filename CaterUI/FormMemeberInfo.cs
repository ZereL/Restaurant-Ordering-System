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
    public partial class FormMemeberInfo : Form
    {
        public FormMemeberInfo()
        {
            InitializeComponent();
        }
        MemberInfoBll miBll = new MemberInfoBll();
        private void FormMemeberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtiBll.GetList();

            ddlType.DataSource = list;
            ddlType.DisplayMember = "mtitle";
            ddlType.ValueMember = "mid";
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtNameSearch.Text != "")
            {
                dic.Add("mname", txtNameSearch.Text);
            }
            if (txtPhoneSearch.Text != "")
            {
                dic.Add("MPhone", txtPhoneSearch.Text);
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.Getlist(dic);
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }

        private void txtNameSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo()
            {
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue)
            };
            if (txtId.Text.Equals("No ID"))
            {
                if (miBll.add(mi))
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
                mi.MId = int.Parse(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }

            txtId.Text = "No ID";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "No ID";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString(); 
            txtPhoneAdd.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "Edit";
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo formMti = new FormMemberTypeInfo();
            DialogResult result = formMti.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }
    }
}
