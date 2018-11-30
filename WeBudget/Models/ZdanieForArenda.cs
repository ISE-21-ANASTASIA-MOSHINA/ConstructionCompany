using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBudget.Models
{
    public class ZdanieForArenda
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public double Sum { get; set; }

        public string Comment { get; set; }

        public int User { get; set; }
    }
}