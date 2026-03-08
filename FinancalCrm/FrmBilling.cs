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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db=new FinancalCrmDbEntities();

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var value=db.Bills.ToList();
            dataGridView1.DataSource=value;

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title=txtBillTitle.Text;
            decimal amount=decimal.Parse(txtBillAmount.Text);
            string period=txtBillPeriod.Text;

            Bills bills=new Bills();
            bills.BillTitle=title;
            bills.BillPeriod=period;
            bills.BillAmount=amount;

            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde sisteme eklendi");

            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue=db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde silindi");

            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;

        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id=int.Parse(txtBillId.Text);
            var updateValue=db.Bills.Find(id);
            
            updateValue.BillTitle=title; 
            updateValue.BillAmount=amount;
            updateValue.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme faturası güncellendi");

            var values2=db.Bills.ToList();
            dataGridView1.DataSource=values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm=new FrmBanks();
            frm.Show();
            this.Hide();
            
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            
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
