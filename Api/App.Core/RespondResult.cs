using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core
{
    public class RespondResult
    {
        public string code { get; set; } = "200";

        public bool is_success { get; set; }

        public string msg { get; set; }

        public object result { get; set; }
    }
}
