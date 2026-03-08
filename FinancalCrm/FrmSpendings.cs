using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db=new FinancalCrmDbEntities();

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            

            //var categoryId=db.Categories.Select(x=>x.CategoryId).ToList();
            cmbCategory.DataSource= db.Categories.ToList();
            cmbCategory.DisplayMember= "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

        }

        private void btnCreateSpending_Click(object sender, EventArgs e)
        {
            Spendings spendings = new Spendings();

            spendings.SpendingTitle = txtSpendingTitle.Text;
            spendings.SpendingAmount = decimal.Parse(txtSpendingAmount.Text);
            spendings.SpendingDate = dtpHistory.Value;
            spendings.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());

            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");

            var values = db.Spendings.Select(x => new
            {
                Id = x.SpendingId,
                Başlık = x.SpendingTitle,
                Tutar = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori_Id = x.CategoryId,
                Kategori_Adı = x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;

        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.Select(x => new
            {
                Id = x.SpendingId,
                Başlık = x.SpendingTitle,
                Tutar = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori_Id = x.CategoryId,
                Kategori_Adı = x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveSpending_Click(object sender, EventArgs e)
        {
            int spendingId = int.Parse(txtSpendingId.Text);
            var deletedValue=db.Spendings.FirstOrDefault(x=>x.SpendingId== spendingId); //Where ile baktıktan sonrada FirstOrDefault diyebiliriz ama gereksiz.
            db.Spendings.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");

            var values = db.Spendings.Select(x => new
            {
                Id = x.SpendingId,
                Başlık = x.SpendingTitle,
                Tutar = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori_Id = x.CategoryId,
                Kategori_Adı = x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            int spendingId = int.Parse(txtSpendingId.Text);
            var updateValue=db.Spendings.FirstOrDefault(x=>x.SpendingId == spendingId);
            updateValue.SpendingDate = dtpHistory.Value;
            updateValue.SpendingAmount = decimal.Parse(txtSpendingAmount.Text);
            updateValue.SpendingTitle = txtSpendingTitle.Text;
            updateValue.CategoryId=int.Parse(cmbCategory.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Harcama Güncellendi");
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSatir = e.RowIndex;

            txtSpendingId.Text = dataGridView1.Rows[secilenSatir].Cells[0].Value.ToString();
            txtSpendingTitle.Text = dataGridView1.Rows[secilenSatir].Cells[1].Value.ToString();
            txtSpendingAmount.Text = dataGridView1.Rows[secilenSatir].Cells[2].Value.ToString();
            dtpHistory.Value = Convert.ToDateTime(dataGridView1.Rows[secilenSatir].Cells[3].Value);
            cmbCategory.Text = dataGridView1.Rows[secilenSatir].Cells[5].Value.ToString();
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

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
