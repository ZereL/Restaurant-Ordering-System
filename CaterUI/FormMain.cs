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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        OrderInfoBll oiBll = new OrderInfoBll();

        private void menuQuit_Click(object sender, EventArgs e)
        {

        }

        private void menuQuit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(this.Tag);
            if (type==1)
            {
                   
            }
            else
            {
                menuManagerInfo.Visible = false;
            }

            LoadHallInfo();
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FormManagerInfo formManagerInfo = FormManagerInfo.Create();
            formManagerInfo.Show();
            formManagerInfo.Focus();
        }

        private void menuMemberInfo_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo form = new FormMemberTypeInfo();
            form.Show();
        }

        private void LoadHallInfo()
        {
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            tcHallInfo.TabPages.Clear();
            TableInfoBll tiBll = new TableInfoBll();
            foreach (var hi in list)
            {
                TabPage tp = new TabPage(hi.HTitle);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("thallid", hi.HId.ToString());
                var listTableInfo = tiBll.GetList(dic);
                ListView lvTableInfo = new ListView();
                lvTableInfo.LargeImageList = imageList1;
                lvTableInfo.DoubleClick += LvTableInfo_DoubleClick;
                lvTableInfo.Dock = DockStyle.Fill;
                tp.Controls.Add(lvTableInfo);
                foreach (var ti in listTableInfo)
                {
                    var lvi = new ListViewItem(ti.TTitle, ti.TIsFree ? 0 : 1);
                    lvi.Tag = ti.TId;
                    lvTableInfo.Items.Add(lvi);
                }
                tcHallInfo.TabPages.Add(tp);
            }
        }

        private void LvTableInfo_DoubleClick(object sender, EventArgs e)
        {
            var lv1 = sender as ListView;
            var lvi = lv1.SelectedItems[0];
            int tableId = Convert.ToInt32(lvi.Tag);
            if (lvi.ImageIndex == 0)
            {
                
                
                int orderId = oiBll.KaiDan(tableId);
                lvi.Tag = orderId;
                lv1.SelectedItems[0].ImageIndex = 1;
            }
            else
            {
                lvi.Tag = oiBll.GetOrderIdByTableId(tableId);
            }

            FormOrderDish formOrderDish = new FormOrderDish();
            formOrderDish.Tag = lvi.Tag;
            formOrderDish.Show();
        }

        private void menuTableInfo_Click(object sender, EventArgs e)
        {
            FormTableInfo formTableInfo = new FormTableInfo();
            formTableInfo.Refresh += LoadHallInfo;
            formTableInfo.Show();
        }

        private void menuDishInfo_Click(object sender, EventArgs e)
        {
            FormDishInfo formDishInfo = new FormDishInfo();
            formDishInfo.Show();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            var listView = tcHallInfo.SelectedTab.Controls[0] as ListView;
            var lvTable = listView.SelectedItems[0];
            if (lvTable.ImageIndex == 0)
            {
                MessageBox.Show("还未使用,无法结账");
                return;
            }
            int tableId = Convert.ToInt32(lvTable.Tag);
            int orderId = oiBll.GetOrderIdByTableId(tableId);
            FormOrderPay formOrderPay = new FormOrderPay();
            formOrderPay.Tag = orderId;
            formOrderPay.Show();
        }
    }
}
