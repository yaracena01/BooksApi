using System;
using System.Collections.Generic;
using System.Text;

namespace Y.DataModels
{
    public class ResponseStatusData
    {
        public object data { get; set; }
        public int statusCode { get; set; } 
        public string error { get; set; }
    }
}
