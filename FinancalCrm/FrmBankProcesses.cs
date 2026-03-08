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
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db=new FinancalCrmDbEntities();

        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now.AddDays(-30);
            var sonGönderilen = db.BankProcesses.Where(x => x.ProcessDate >= tarih && x.ProcessType.StartsWith("Giden")).Sum(y=>y.Amount);
            lblTotalSent.Text = sonGönderilen.ToString();

            var sonGelen = db.BankProcesses.Where(x => x.ProcessDate >= tarih && x.ProcessType.StartsWith("Gelen")).Sum(y => y.Amount);
            lblTotalComing.Text = sonGelen.ToString();

            var total = db.Banks.Sum(x => x.BankBalance);

            lblTotalBalance.Text = (total+sonGelen-sonGönderilen).ToString();

            var sonGiden3 = db.BankProcesses.Where(z => z.ProcessType.StartsWith("Giden")).OrderByDescending(x => x.ProcessDate).Take(3).Select(x => new { x.Sender, x.Amount }).ToList();

            lblGiden1.Text = sonGiden3[0].Sender + " - " + sonGiden3[0].Amount + " ₺";
            lblGiden2.Text = sonGiden3[1].Sender + " - " + sonGiden3[1].Amount + " ₺";
            lblGiden3.Text = sonGiden3[2].Sender + " - " + sonGiden3[2].Amount + " ₺";

            var sonGelen3 = db.BankProcesses.Where(z => z.ProcessType.StartsWith("Gelen")).OrderByDescending(x => x.ProcessDate).Take(3).Select(x => new { x.Sender, x.Amount }).ToList();

            lblGelen1.Text = sonGelen3[0].Sender + " + " + sonGelen3[0].Amount + " ₺";
            lblGelen2.Text = sonGelen3[1].Sender + " + " + sonGelen3[1].Amount + " ₺";
            lblGelen3.Text = sonGelen3[2].Sender + " + " + sonGelen3[2].Amount + " ₺";
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnSpendingsForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcessesForm_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
