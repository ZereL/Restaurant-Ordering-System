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
    public partial class FormOrderPay : Form
    {
        public FormOrderPay()
        {
            InitializeComponent();
        }
        private int orderId;
        private OrderInfoBll oiBll = new OrderInfoBll();
        private void FormOrderPay_Load(object sender, EventArgs e)
        {
            orderId = Convert.ToInt32(this.Tag);
            gbMember.Enabled = false;
            GetMoneyByOrderID();
        }
        private void GetMoneyByOrderID()
        {
            lblPayMoney.Text=lblPayMoneyDiscount.Text= oiBll.GetTotalMoneyByOrderId(orderId).ToString();
        }

        private void cbkMember_CheckedChanged(object sender, EventArgs e)
        {
                gbMember.Enabled = cbkMember.Checked;
        }

        private void LoadMember()
        {
            //Search
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtId.Text != "")
            {
                dic.Add("mid", txtId.Text);
            }
            if (txtPhone.Text != "")
            {
                dic.Add("mPhone", txtPhone.Text);
            }

            MemberInfoBll miBll = new MemberInfoBll();
            var list = miBll.Getlist(dic);
            if (list.Count > 0)
            {
                //Get MemberInfo
                MemberInfo mi = list[0];
                lblMoney.Text = mi.MMoney.ToString();
                lblTypeTitle.Text = mi.MTypeTitle;
                lblDiscount.Text = mi.MDiscount.ToString();

                //Discount
                lblPayMoneyDiscount.Text =
                    (Convert.ToDecimal(lblPayMoney.Text) * Convert.ToDecimal(lblDiscount.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Wrong info");
            }
        }
        private void txtId_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void btnOrderPay_Click(object sender, EventArgs e)
        {

            if (oiBll.Pay(cbkMoney.Checked, int.Parse(txtId.Text), Convert.ToDecimal(lblPayMoneyDiscount.Text), orderId,
                Convert.ToDecimal(lblDiscount.Text)))
            {
                Refresh();
                this.Close();
            }
            else
            {
                MessageBox.Show("check out failed");
            }

        }
    }
}
