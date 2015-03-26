using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NumbersApi.Models.Interfaces
{
    public interface INumberWriter
    {
        CultureInfo Culture { get; }

        List<DigitGroup> Groups { get; set; }

        string WrittenNumber { get; set; }

        //not null in case of non-blocking errors. The value is the error message
        string Error { get; }

        BasicNumberWriter Write(INumberWriterOptions options);

        BasicNumberWriter PostProcessWrittenNumber();

        DigitGroup ProcessGroup(DigitGroup group);

    }
}