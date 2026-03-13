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
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class FrmBankProcesses : Form
    {
        private readonly IBankProcessService _bankProcessService;
        private readonly IBankService _bankService;
        public FrmBankProcesses()
        {
            _bankProcessService = new BankProcessManager(new EfBankProcessDal());
            _bankService=new BankManager(new EfBankDal());
            InitializeComponent();
        }

        

        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            var sonGelen3Hav = _bankProcessService.TGetIncomingOrOutgoingTransferDtos("Gelen", 3);
            var sonGiden3Hav = _bankProcessService.TGetIncomingOrOutgoingTransferDtos("Giden", 3);
            Label[] labelsGelen = { lblGelen1, lblGelen2, lblGelen3 };
            Label[] labelsGiden = { lblGiden1, lblGiden2, lblGiden3 };


            for (int i = 0;i<sonGelen3Hav.Count || i<sonGiden3Hav.Count;i++)
            {
                labelsGelen[i].Text=sonGelen3Hav[i].Sender+": +" + sonGelen3Hav[i].Amount.ToString()+"₺";
                labelsGiden[i].Text=sonGiden3Hav[i].Sender+": -" + sonGiden3Hav[i].Amount.ToString()+"₺";
            }

            decimal totalSent = _bankProcessService.TGetLast30DaysTotalAmount("Giden");
            decimal totalComing = _bankProcessService.TGetLast30DaysTotalAmount("Gelen");
            decimal totalBalance = _bankService.TGetTotalBalance();

            lblTotalSent.Text = totalSent.ToString();
            lblTotalComing.Text = totalComing.ToString();
            lblTotalBalance.Text= (totalBalance + totalComing - totalSent).ToString();

            
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
