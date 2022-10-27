using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutriScience_truckscale.model;
using System.IO;
using ClosedXML.Excel;

namespace NutriScience_truckscale.view
{
    public partial class export : Form
    {
        public export()
        {
            InitializeComponent();
            listMonths();
        }
        void listMonths()
        {
            bunifuDropdown1.Items.Add("Select");
          
            string[] month = { "","Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec","rex" };
            bunifuDropdown1.DataSource = month;
            bunifuDropdown1.SelectedIndex = 0;

            string[] year = { "", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029" };
            bunifuDropdown2.DataSource = year;
            bunifuDropdown2.SelectedIndex = 0;


        }
        private DataTable dt;
        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthSelected = bunifuDropdown1.Text;
        }
        private string monthSelected { get; set; }
        private string yearSelected { get; set; }
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedIndex == 0 || bunifuDropdown2.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the month and year to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var history = JsonConvert.DeserializeObject<List<weighingrecords>>(weighingHistoryTab._history);

                var filter = from u in history where u.date.Contains(bunifuDropdown1.Text + " " + bunifuDropdown2.Text) select u;

                string json = JsonConvert.SerializeObject(filter);
                dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                string folderPath = "C:\\Excel\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, $"Truckscale_records_{monthSelected} ");
                    wb.SaveAs(folderPath + $"Truckscalerecordsbymonthof{monthSelected}{yearSelected}.xlsx");
                }
                MessageBox.Show($"Datas of {monthSelected} {yearSelected} exported to C:\\Excel.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }

        }

        private void export_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearSelected = bunifuDropdown2.Text;
        }
    }
}
