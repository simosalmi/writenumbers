using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersApi.Models
{
    public class NumberWriterResult
    {
        public string Value { get; set; }
        public string Error { get; set; }
        public string CultureName { get; set; }        
    }
}
