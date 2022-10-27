
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriScience_truckscale.model
{
    class weighingrecords
    {
        public string date { get; set; }
        public string customer_name { get; set; }
        public string commodity { get; set; }
        public string plate_no { get; set; }
        public string gross_weight { get; set; }
        public string tare_weight { get; set; }
        public string net_weight { get; set; }
        public string entry_time { get; set; }
        public string exit_time { get; set; }
    }
}
