using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class ServiceReponse
    {
        public List<string> Msg { get; set; } = new List<string>();
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
