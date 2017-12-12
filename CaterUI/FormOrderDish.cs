using CaterBll;
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
    public partial class FormOrderDish : Form
    {
        public FormOrderDish()
        {
            InitializeComponent();
        }

        OrderInfoBll oiBll = new OrderInfoBll();

        private void FormOrderDish_Load(object sender, EventArgs e)
        {
            LoadDishType();
            LoadDishInfo();
            LoadDetailList();
        }

        private void LoadDishType()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            var list = dtiBll.GetList();
            list.Insert(0, new CaterModel.DishTypeInfo() {
                DId = 0,
                DTitle ="All"
            });
            ddlType.ValueMember = "did";
            ddlType.DisplayMember = "dtitle";
            ddlType.DataSource = dtiBll.GetList();
        }

        private void LoadDishInfo()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtTitle.Text != "")
            {
                dic.Add("dchar", txtTitle.Text);
            }
            if (ddlType.SelectedValue.ToString() != "0")
            {
                dic.Add("dtypeId", ddlType.SelectedValue.ToString());
            }
            DishInfoBll diBll = new DishInfoBll();
            dgvAllDish.AutoGenerateColumns = false;
            dgvAllDish.DataSource = diBll.GetList(dic);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void dgvAllDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int orderId = Convert.ToInt32(this.Tag);


            int dishId = Convert.ToInt32(dgvAllDish.Rows[e.RowIndex].Cells[0].Value);


            if (oiBll.DianCai(orderId, dishId))
            {

                LoadDetailList();
            }
        }

        private void LoadDetailList()
        {
            int orderId = Convert.ToInt32(this.Tag);
            dgvOrderDetail.AutoGenerateColumns = false;
            dgvOrderDetail.DataSource = oiBll.GetDetailList(orderId);
            GetTotalMoneyByOrderId();
        }

        private void dgvOrderDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrderDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvOrderDetail.Rows[e.RowIndex];
            int oid = Convert.ToInt32(row.Cells[0].Value);
            int count = Convert.ToInt32(row.Cells[2].Value);
            oiBll.UpdateCountByOid(oid, count);
            GetTotalMoneyByOrderId();
        }

        private void GetTotalMoneyByOrderId()
        {
            int orderId = Convert.ToInt32(this.Tag);
            lblMoney.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            int orderId = Convert.ToInt32(this.Tag);

            decimal money = Convert.ToDecimal(lblMoney.Text);

            if (oiBll.SetOrderMoney(orderId, money))
            {
                MessageBox.Show("order success");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete？", "Alert", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //GetID
            int oid = Convert.ToInt32(dgvOrderDetail.SelectedRows[0].Cells[0].Value);
            //Delete
            if (oiBll.DeleteDetailById(oid))
            {
                LoadDetailList();
            }
        }

    }
}
