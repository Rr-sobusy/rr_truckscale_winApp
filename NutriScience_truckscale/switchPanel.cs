using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriScience_truckscale
{
    public static class switchPanel
    {
        public static void dispuc(Control cont, Panel pnl)
        {
            pnl.Controls.Clear();
            cont.BringToFront();
            pnl.Controls.Add(cont);
        }
    }
}
