using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace FinancalCrm
{
    public partial class FrmDashboard : Form
    {

        private readonly IBankService _bankService;
        private readonly IBillService _billService;
        private readonly IBankProcessService _bankProcessService;
        private readonly ISpendingService _spendingService;
        public FrmDashboard()
        {
            _bankService = new BankManager(new EfBankDal());
            _billService = new BillManager(new EfBillDal());
            _bankProcessService=new BankProcessManager(new EfBankProcessDal());
            _spendingService=new SpendingManager(new EfSpendingDal());
            InitializeComponent();
        }

        private List<BillListDto> _billValues;
        private int _billIndex = 0;

        private List<ComingAndGoingTransferDto> _incomingValues;
        private int _incomingIndex = 0;

        private List<CategorySpendingDto> _spendingValues;




        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            //Toplam bakiyemizi yazdırdık.
            lblTotalBalance.Text=_bankService.TGetTotalBalance().ToString()+"₺";

            //---------------------//
            // Bu işlemde DTO kullanabilirdik ancak doğrudan Entity kullanarak verileri alıyoruz.
            // BankService üzerinden Bank entity listesini çekiyoruz.
            // Entity içindeki tüm propertyler gelir fakat burada sadece gerekli olan
            // BankTitle ve BankBalance alanlarını kullanarak Chart kontrolüne aktarıyoruz.
            List<Bank> banks = _bankService.TGetAll();
            chart1.Series["Series1"].Points.Clear();

            foreach (var bank in banks)
            {
                chart1.Series["Series1"].Points.AddXY(bank.BankTitle, bank.BankBalance);
            }
            //-------------------//


            
            _billValues =_billService.TGetActiveBillsDto();
            _incomingValues = _bankProcessService.TGetIncomingOrOutgoingTransferDtos("Gelen");
            _spendingValues=_spendingService.TGetCategorySpendingDtos();

            chart2.Series.Clear();

            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = SeriesChartType.Pie;
            series2.IsValueShownAsLabel = true;

            foreach (var value in _spendingValues)
            {
                series2.Points.AddXY(value.CategoryName, value.TotalSpendingAmount);
            }




        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_billValues != null && _billValues.Count > 0)
            {
                lblBillTitle.Text = _billValues[_billIndex].BillTitle;
                lblBillAmount.Text = "-"+_billValues[_billIndex].BillAmount.ToString()+"₺";
                _billIndex++;
                if (_billIndex >= _billValues.Count)
                {
                    _billIndex = 0;
                }
            }

            if (_incomingValues != null && _incomingValues.Count > 0)
            {
                lblGelenHavale.Text = "Gönderen: "+_incomingValues[_incomingIndex].Sender;
                lblHavaleTutarı.Text = "+"+_incomingValues[_incomingIndex].Amount.ToString()+"₺";
                _incomingIndex++;
                if (_incomingIndex >= _incomingValues.Count)
                {
                    _incomingIndex = 0;
                }

            }
        }

        

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
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

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
