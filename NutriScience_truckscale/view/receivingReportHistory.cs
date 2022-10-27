using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutriScience_truckscale.model;
using Flurl.Http;
using Newtonsoft.Json;

namespace NutriScience_truckscale.view
{
    public partial class receivingReportHistory : UserControl
    {
        private string _history;

        public receivingReportHistory()
        {
            InitializeComponent();         
        }

        private async void receivingReportHistory_Load(object sender, EventArgs e)
        {
            _history = await $"{API._api}/api/getreceivingreportrecords"
          .GetStringAsync();
            if(_history.Length != 0)
            {
                bunifuLoader1.Hide();
            }

            var records = JsonConvert.DeserializeObject<List<receivingReportRecords>>(_history);

            foreach(var result in records)
            {
                guna2DataGridView1.Rows.Add(result.receipt_number,result.date,result.supplier,result.content,result.po_number,result.dr_no,result.si_no);
            }           
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

            if(supplierOption.Checked == true)
            {
                guna2DataGridView1.Rows.Clear();
                var history = JsonConvert.DeserializeObject<List<receivingReportRecords>>(_history);   
                
                //Filter the json datas before looping to data table.
                var filtered = from u in history where u.supplier.ToLower().Contains(bunifuTextBox1.Text.ToString().ToLower()) select u;

                foreach(var result in filtered)
                {                 
                    guna2DataGridView1.Rows.Add(result.receipt_number, result.date, result.supplier, result.content, result.po_number, result.dr_no, result.si_no);
                }

            }

            if(itemOption.Checked == true)
            {
                guna2DataGridView1.Rows.Clear();
                var history = JsonConvert.DeserializeObject<List<receivingReportRecords>>(_history);

                //Filter the json datas before looping to data table.
                var filtered = from u in history where u.content.ToLower().Contains(bunifuTextBox1.Text.ToString().ToLower()) select u;

                foreach(var result in filtered)
                {
                    guna2DataGridView1.Rows.Add(result.receipt_number, result.date, result.supplier, result.content, result.po_number, result.dr_no, result.si_no);
                }
            }
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

            guna2DataGridView1.Rows.Clear();
            var history = JsonConvert.DeserializeObject<List<receivingReportRecords>>(_history);

            //Filter the json datas before looping to data table.
            var filtered = from u in history where u.date == bunifuDatePicker1.Value.ToShortDateString() select u;

            foreach (var result in filtered)
            {
                guna2DataGridView1.Rows.Add(result.receipt_number, result.date, result.supplier, result.content, result.po_number, result.dr_no, result.si_no);
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
