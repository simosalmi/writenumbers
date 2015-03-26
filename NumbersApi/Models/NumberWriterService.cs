using NumbersApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NumbersApi.Models
{
    public class NumberWriterService
    {
        //strategy
        private INumberWriter NumberWritingStrategy;

        public CultureInfo Culture { get; set; }

        public NumberWriterService(INumberWriter numberWritingStrategy)
        {
            if(numberWritingStrategy != null)
            {
                this.Culture = numberWritingStrategy.Culture;
            }
            this.NumberWritingStrategy = numberWritingStrategy;
        }

        //do work
        public string Write(INumberWriterOptions options)
        {
            return NumberWritingStrategy.Write(options).WrittenNumber;
        }


        public string Error {
            get
            {
                if(NumberWritingStrategy != null)
                {
                    return NumberWritingStrategy.Error;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}