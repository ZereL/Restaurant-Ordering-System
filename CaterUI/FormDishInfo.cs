using CaterBll;
using CaterCommon;
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
    public partial class FormDishInfo : Form
    {
        public FormDishInfo()
        {
            InitializeComponent();
        }
        private DishInfoBll diBll = new DishInfoBll();
        private DishTypeInfoBll dtiBll = new DishTypeInfoBll();
        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadTypeList()
        {
            List<DishTypeInfo> list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });

            ddlTypeSearch.DataSource = list;
            ddlTypeSearch.ValueMember = "did";//对应于SelectedValue属性
            ddlTypeSearch.DisplayMember = "dtitle";//用于显示的值 
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtTitleSearch.Text != "")
            {
                dic.Add("dtitle", txtTitleSearch.Text);
            }
            if (ddlTypeSearch.SelectedValue.ToString()  != "0")
            {
                dic.Add("DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = diBll.GetList(dic);
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;//全部
            LoadList();
        }

        private void txtTitleSave_Leave(object sender, EventArgs e)
        {
            txtChar.Text = PinyinHelper.GetPinyin(txtTitleSave.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //收集用户输入信息
            DishInfo di = new DishInfo()
            {
                DTitle = txtTitleSave.Text,
                DChar = txtChar.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue)
            };

            if (txtId.Text == "添加时无编号")
            {
                #region 添加

                if (diBll.Add(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("逗b，怎么加的");
                }
                #endregion
            }
            else
            {
                #region 修改

                di.DId = int.Parse(txtId.Text);
                if (diBll.Update(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("你是猴子请来的救兵吗？");
                }
                #endregion
            }

            #region 恢复控件

            txtId.Text = "添加时无编号";
            txtTitleSave.Text = "";
            txtPrice.Text = "";
            txtChar.Text = "";
            ddlTypeAdd.SelectedIndex = 0;

            #endregion
        }
    }
}
