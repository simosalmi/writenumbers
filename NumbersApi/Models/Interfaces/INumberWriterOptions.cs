using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersApi.Models.Interfaces
{
    public interface INumberWriterOptions
    {
        string Value { get; set; }

        string CultureName { get; set; }

        bool AllowCultureFallback { get; set; }
    }
}