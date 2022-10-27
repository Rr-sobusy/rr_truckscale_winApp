using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace NutriScience_truckscale.model
{
    class deliverymodel
    {
        public string plate_no { get; set; }
        public string cust_name { get; set; }
        public int gross_weight { get; set; }
        public string commodity { get; set; }
        public string date { get; set; }
        public string entry_time { get; set; }
    }
}
