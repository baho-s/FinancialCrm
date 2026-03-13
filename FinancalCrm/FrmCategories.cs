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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db = new FinancalCrmDbEntities();

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var categoryCount = db.Categories.Count();
            lblCategoryCount.Text = categoryCount.ToString();

            //var maxId = db.Spendings.OrderByDescending(x => x.SpendingAmount).Select(y => y.CategoryId).FirstOrDefault();
            //var minId= db.Spendings.OrderBy(x => x.SpendingAmount).Select(y => y.CategoryId).FirstOrDefault();

            //var maxSpending=db.Categories.Where(x=>x.CategoryId==maxId).Select(y=>y.CategoryName).FirstOrDefault();
            //var minSpending=db.Categories.Where(x=>x.CategoryId==minId).Select(y=>y.CategoryName).FirstOrDefault();

            var maxCategory = db.Spendings.GroupBy(x => x.CategoryId).Select(y => new { CategoryId = y.Key, Total = y.Sum(x => x.SpendingAmount) }).OrderByDescending(x => x.Total).FirstOrDefault();

            var maxName = db.Categories.Where(x => x.CategoryId == maxCategory.CategoryId).Select(x => x.CategoryName).FirstOrDefault();

            var minCategory = db.Spendings.GroupBy(x => x.CategoryId).Select(g => new { CategoryId = g.Key, Total = g.Sum(x => x.SpendingAmount) }).OrderBy(x => x.Total).FirstOrDefault();

            var minName = db.Categories.Where(x => x.CategoryId == minCategory.CategoryId).Select(x => x.CategoryName).FirstOrDefault();

            lblMaxCategoryPrice.Text=maxCategory.Total.ToString()+"₺";
            lblMinCategoryPrice.Text=minCategory.Total.ToString()+"₺";

            lblMaxSpending.Text = maxName.ToString();
            lblMinSpending.Text = minName.ToString();

            var values = db.Spendings.Select(x => new
            {
                Kategori_Adi=x.Categories.CategoryName,
                Harcanan_Miktar=x.SpendingAmount,
                Harcama_Zamani=x.SpendingDate
            }).ToList();

            dataGridView2.DataSource = values;



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
