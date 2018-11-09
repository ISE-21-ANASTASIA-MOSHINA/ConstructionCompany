﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBudget.Models
{
    public class Dohod
    {
        public int Id { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public double Sum { get; set; }

        public string Comment { get; set; }

        public virtual User User { get; set; }

    }
}