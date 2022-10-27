using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriScience_truckscale.view
{
    public partial class printForm : Form
    {
        public static Label _customerName;
        public static Label _commodity;
        public static Label _date;
        public static Label _entryTime;
        public static Label _exitTime;
        public static Label _grosssWeight;
        public static Label _tareWeight;
        public static Label _netWeight;
        public static Label _plateNo;
        public static Label _driver;
        public static Label _weigher;

        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        PrintDocument prntdoc = new PrintDocument();

        public printForm()
        {
            InitializeComponent();
            _customerName = customerName;
            _commodity = commodity;
            _date = date;
            _entryTime = entryTime;
            _exitTime = exitTime;
            _grosssWeight = grossWeght;
            _tareWeight = tareWeight;
            _netWeight = netWeight;
            _plateNo = plateNo;
            _driver = driverName;
            _weigher = weigherName;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void customerName_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printPanel(this.panel1);
        }

        private void printPanel(Panel panel)
        {
            System.Drawing.Printing.PrinterSettings ps = new PrinterSettings();
            panel1 = panel;
            getprintarea(panel);

            prntdoc.PrintPage += new PrintPageEventHandler(prntdoc_printpage);

            PrintDialog pd = new PrintDialog();

            if (pd.ShowDialog() == DialogResult.OK)
            {
                prntdoc.Print();
                prntdoc.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;
                prntdoc.PrinterSettings.Copies = pd.PrinterSettings.Copies;
            }
        }
        Bitmap memoryimg;
        private void getprintarea(Panel panel)
        {

            memoryimg = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(memoryimg, new Rectangle(0, 0, panel.Width, panel.Height));
        }

        private void prntdoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), -this.panel1.Location.Y);
        }
    }
}
