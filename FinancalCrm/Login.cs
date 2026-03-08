using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db=new FinancalCrmDbEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var user=db.Users.FirstOrDefault();
            if(user.UserName==txtUserName.Text && user.Password==txtUserPassword.Text)
            {
                FrmBilling frm = new FrmBilling();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Şifre Yanlış");
            }
            
        }
    }
}
