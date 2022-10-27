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
using Newtonsoft.Json.Linq;
using Guna.UI2.WinForms;
using System.IO;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;


namespace NutriScience_truckscale.view
{
    public partial class weighingHistoryTab : UserControl
    {
        private DataTable dt;
        private Guna2DataGridView dgv;
        public static string _history { get; set; }

        public weighingHistoryTab()
        {
            InitializeComponent();
            dgv = guna2DataGridView1;
            
        }

        private async void weighingHistoryTab_Load(object sender, EventArgs e)
        {

            try
            {
                _history = await $"{API._api}/api/getweighingrecords"
            .GetStringAsync();
                var names = JsonConvert.DeserializeObject<List<weighingrecords>>(_history);

                if(_history.Length != 0)
                {
                    bunifuLoader1.Hide();
                }
                //Loop to datagrid view
                foreach (var result in names)
                {
                    guna2DataGridView1.Rows.Add(result.date, result.customer_name, result.commodity, result.plate_no, result.gross_weight, result.tare_weight,
                        result.net_weight, result.entry_time, result.exit_time);
                }

                foreach(DataGridViewColumn column in guna2DataGridView1.Columns)
                {
                   
                }

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                       
                    }
                }
            }
            catch (FlurlHttpException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (this.guna2DataGridView1.SelectedCells[0].Value == null)
            {
                MessageBox.Show("Please select the cell to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printForm form = new printForm();

                printForm._date.Text = this.guna2DataGridView1.SelectedCells[0].Value.ToString();
                printForm._customerName.Text = this.guna2DataGridView1.SelectedCells[1].Value.ToString();
                printForm._commodity.Text = this.guna2DataGridView1.SelectedCells[2].Value.ToString();
                printForm._plateNo.Text = this.guna2DataGridView1.SelectedCells[3].Value.ToString();
                printForm._grosssWeight.Text = this.guna2DataGridView1.SelectedCells[4].Value.ToString();
                printForm._tareWeight.Text = this.guna2DataGridView1.SelectedCells[5].Value.ToString();
                printForm._netWeight.Text = this.guna2DataGridView1.SelectedCells[6].Value.ToString();
                printForm._entryTime.Text = this.guna2DataGridView1.SelectedCells[7].Value.ToString();
                printForm._exitTime.Text = this.guna2DataGridView1.SelectedCells[8].Value.ToString();
                form.Show();
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(customerOption.Checked == true)
            {
                var names = JsonConvert.DeserializeObject<List<weighingrecords>>(_history);

                //Filter the json datas before looping to datagridview.
                var filter = from u in names where u.customer_name.ToLower().Contains(bunifuTextBox1.Text.ToString().ToLower()) select u;

                guna2DataGridView1.Rows.Clear();
                foreach (var result in filter)
                {
                    guna2DataGridView1.Rows.Add(result.date, result.customer_name, result.commodity, result.plate_no, result.gross_weight, result.tare_weight,
                           result.net_weight, result.entry_time, result.exit_time);
                }
            }

            if(commodityOption.Checked == true)
            {
                var names = JsonConvert.DeserializeObject<List<weighingrecords>>(_history);

                //Filter the json datas before looping to datagridview.
                var filter = from u in names where u.commodity.ToLower().Contains(bunifuTextBox1.Text.ToString().ToLower()) select u;

                guna2DataGridView1.Rows.Clear();
                foreach (var result in filter)
                {
                    guna2DataGridView1.Rows.Add(result.date, result.customer_name, result.commodity, result.plate_no, result.gross_weight, result.tare_weight,
                           result.net_weight, result.entry_time, result.exit_time);
                }
            }
            

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            export form = new export();
            form.Show();
            /*
            var names = JsonConvert.DeserializeObject<List<weighingrecords>>(_history);
            dt = (DataTable)JsonConvert.DeserializeObject(_history, (typeof(DataTable)));
            string folderPath = "C:\\Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Truckscale records ");
                wb.SaveAs(folderPath + "truckscale.xlsx");
            }
            */
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            var history = JsonConvert.DeserializeObject<List<weighingrecords>>(_history);

            //Filter the json datas before looping to datagridview.
            var filter = from u in history where u.date == bunifuDatePicker1.Value.ToShortDateString() select u;

            guna2DataGridView1.Rows.Clear();
            foreach (var result in filter)
            {
                guna2DataGridView1.Rows.Add(result.date, result.customer_name, result.commodity, result.plate_no, result.gross_weight, result.tare_weight,
                       result.net_weight, result.entry_time, result.exit_time);
            }


            // dt = (DataTable)JsonConvert.DeserializeObject(_history, (typeof(DataTable)));
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }   
    }
}
