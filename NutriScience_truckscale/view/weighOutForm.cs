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
using Bunifu.UI.WinForms;
using NutriScience_truckscale.view;
using Flurl.Http;

namespace NutriScience_truckscale.view
{
    public partial class weighOutForm : Form
    {
        public static BunifuLabel plate_no;
        public static BunifuLabel gross;
        public static BunifuLabel tare;
        public static BunifuLabel net;
        public static BunifuLabel customer;
        public static BunifuLabel _commodity;
        public static BunifuLabel entry_time;
        public static BunifuLabel exit_time;
        public static BunifuLabel _date;

        public weighOutForm()
        {
            InitializeComponent();
        }

        private void weighOutForm_Load(object sender, EventArgs e)
        {
            plate_no = plateNo;
            gross = grossWeight;
            tare = tareWeight;
            net = netWeight;
            customer = customerName;
            _commodity = commodity;
            entry_time = entryTime;
            exit_time = exitTime;
            _date = date;
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            //Post the datas to the database
            var result = await $"{API._api}/api/postweighingrecords"
                .PostJsonAsync(new
                {
                    plateNo = plateNo.Text,
                    grossWeight = grossWeight.Text,
                    tareWeight = tareWeight.Text,
                    netWeight = netWeight.Text,
                    date = date.Text,
                    customerName = customerName.Text,
                    commodity = commodity.Text,
                    entryTime = entryTime.Text,
                    exitTime = exitTime.Text
                });

            //Load the datas to print form
            printForm form = new printForm();

            printForm._customerName.Text = customerName.Text.ToString();
            printForm._date.Text = date.Text.ToString();
            printForm._entryTime.Text = entryTime.Text.ToString();
            printForm._exitTime.Text = exitTime.Text.ToString();
            printForm._grosssWeight.Text = grossWeight.Text.ToString();
            printForm._netWeight.Text = netWeight.Text.ToString();
            printForm._tareWeight.Text = tareWeight.Text.ToString();
            printForm._plateNo.Text = plateNo.Text.ToString();
            printForm._commodity.Text = commodity.Text.ToString();
            
           
            this.Close();
            form.Show();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
