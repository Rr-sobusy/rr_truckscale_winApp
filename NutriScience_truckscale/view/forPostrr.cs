using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using System.Drawing.Printing;

namespace NutriScience_truckscale.view
{
    public partial class forPostrr : Form
    {
        public BunifuLabel _supplier, _date, _poNumber, _drNumber, _siNumber, _quantity1, _unit1, _description1, _quantity2, _unit2, _description2
            , _quantity3, _unit3, _description3, _quantity4, _unit4, _description4, _quantity5, _unit5, _description5;

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            PrinterSettings ps = new PrinterSettings();

            PrintDocument pdc = new PrintDocument();
            PrintDialog pd = new PrintDialog();
            pdc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.AllowSelection = false;
            pd.AllowSomePages = false;



            if (pd.ShowDialog() == DialogResult.OK)
            {
                pdc.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;
                pdc.PrinterSettings.Copies = pd.PrinterSettings.Copies;
                pdc.Print();


            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(supplier.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(136, 121));
            e.Graphics.DrawString(dateReceived.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(136, 164));
            e.Graphics.DrawString(poNumber.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(581, 122));
            e.Graphics.DrawString(drNumber.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(581, 146));
            e.Graphics.DrawString(siNumber.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(581, 166));

            //First Item
            e.Graphics.DrawString(quantity1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(48, 260));
            e.Graphics.DrawString(unit1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 260));
            e.Graphics.DrawString(description1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 260));

            //Second Item
            e.Graphics.DrawString(quantity2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(48, 283));
            e.Graphics.DrawString(unit2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 283));
            e.Graphics.DrawString(description2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 283));

            //Third Item
            e.Graphics.DrawString(quantity3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(48, 306));
            e.Graphics.DrawString(unit3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 306));
            e.Graphics.DrawString(description3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 306));

            //fourth item
            e.Graphics.DrawString(quantity4.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(48, 330));
            e.Graphics.DrawString(unit4.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 330));
            e.Graphics.DrawString(description4.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 330));

            //Fifth Item
            e.Graphics.DrawString(quantity5.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(48, 355));
            e.Graphics.DrawString(unit5.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 355));
            e.Graphics.DrawString(description5.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 355));

        }

        public forPostrr()
        {
            InitializeComponent();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void dateReceived_Click(object sender, EventArgs e)
        {

        }

        private void forPostrr_Load(object sender, EventArgs e)
        {
            printReceivingReport form = new printReceivingReport();
          

           
            _supplier = supplier;
            _date = dateReceived;
            _poNumber = poNumber;
            _drNumber = drNumber;
            _siNumber = siNumber;
            _quantity1 = quantity1;
            _quantity2 = quantity2;
            _quantity3 = quantity3;
            _quantity4 = quantity4;
            _quantity5 = quantity5;
            _unit1 = unit1;
            _unit2 = unit2;
            _unit3 = unit3;
            _unit4 = unit4;
            _unit5 = unit5;
            _description1 = description1;
            _description2 = description2;
            _description3 = description3;
            _description4 = description4;
            _description5 = description5;
          


        }
    }
}
