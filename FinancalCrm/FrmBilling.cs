using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using FinancalCrm.Entity.Concrete;
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class FrmBilling : Form
    {
        private readonly IBillService _billService;
        public FrmBilling()
        {
            _billService = new BillManager(new EfBillDal());
            InitializeComponent();
        }

        

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var valueBill=_billService.TGetActiveBillsDto();
            dataGridView1.DataSource=valueBill;

        }

        

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBillTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtBillPeriod.Text) ||
                    string.IsNullOrWhiteSpace(txtBillAmount.Text))
                {
                    MessageBox.Show("Lütfen Id hariç diğer alanları doldurunuz.");
                    return;
                }

                Bill bill = new Bill
                {
                    BillAmount = decimal.Parse(txtBillAmount.Text),
                    BillPeriod = txtBillPeriod.Text,
                    BillTitle = txtBillTitle.Text
                };


                _billService.TInsert(bill);

                MessageBox.Show("Fatura Başarıyla Eklendi.");
                dataGridView1.DataSource = _billService.TGetActiveBillsDto();

                txtBillId.Clear();
                txtBillTitle.Clear();
                txtBillAmount.Clear();
                txtBillPeriod.Clear();
                txtBillTitle.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBillId.Text))
            {
                MessageBox.Show("Silinecek Fatura İd'sini Giriniz");
                return;
            }

            int id = int.Parse(txtBillId.Text);
            var bill = _billService.TGetById(id);
            if (bill.IsDeleted == true)
            {
                MessageBox.Show("Bu kayıt oluşturulmamış veya silinmiş.");
                return;
            }
            _billService.TDelete(bill);
            MessageBox.Show("Ürün Başarıyla Silindi.");

            dataGridView1.DataSource = _billService.TGetActiveBillsDto();

        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {


            int id = int.Parse(txtBillId.Text);
            
            var updateBill = _billService.TGetById(id);

            if (updateBill == null)
            {
                MessageBox.Show("Kayıt bulunamadı.");
                return;
            }
            if (updateBill.IsDeleted)
            {
                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                return;
            }

            updateBill.BillAmount = decimal.Parse(txtBillAmount.Text);
            updateBill.BillPeriod = txtBillPeriod.Text;
            updateBill.BillTitle = txtBillTitle.Text;

            _billService.TUpdate(updateBill);

            MessageBox.Show("Kayıt başarıyla güncellendi.");
            dataGridView1.DataSource= _billService.TGetActiveBillsDto();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBillId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBillTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBillAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBillPeriod.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _billService.TGetActiveBillsDto();
        }

        private void btnGetDeletedBills_Click(object sender, EventArgs e)
        {
            var value = _billService.TGetDeletedBillsDto();
            dataGridView1.DataSource = value;
        }
    }
}
