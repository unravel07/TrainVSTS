using System;
using System.Collections.Generic;

namespace NSOVarTestAPI.Models
{
    public class model3
    {
        public string _id { get; set; }
        public SN1P1 SN1P1 { get; set; }
        public int status_data { get; set; }
        public int status_approve { get; set; }
        public List<SN1P2> SN1P2 { get; set; }
        public string SN1_ID { get; set; }
        public DateTime submit_date { get; set; }
        public int __v { get; set; }
    }
}