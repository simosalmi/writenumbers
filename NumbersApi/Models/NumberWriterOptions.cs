using NumbersApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersApi.Models
{
    public class NumberWriterOptions : INumberWriterOptions
    {
        public string CultureName { get; set; }

        public string Value { get; set; }

        public bool AllowCultureFallback { get; set; }

    }
}
