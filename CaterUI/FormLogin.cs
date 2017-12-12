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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;

            int type;
            ManagerInfoBll miBll = new ManagerInfoBll();
            LoginState loginState = miBll.Login(name, pwd, out type);
            switch (loginState)
            {
                case LoginState.ok:
                    FormMain main = new FormMain();
                    main.Tag = type;
                    main.Show();
                    this.Hide();
                    break;
                case LoginState.NameError:
                    MessageBox.Show("UserName wrong");
                    break;
                case LoginState.PwdError:
                    MessageBox.Show("Password wrong");
                    break;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
