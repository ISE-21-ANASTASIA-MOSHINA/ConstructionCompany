using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBudget.Models
{
    public class ZdanieForPokupka
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Sum { get; set; }

        public string Comment { get; set; }

        public int User { get; set; }

    }
}