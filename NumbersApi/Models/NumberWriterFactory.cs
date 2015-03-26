using NumbersApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersApi.Models
{
    public static class NumberWriterFactory
    {
        public static NumberWriterService Create(string CultureName)
        {
            INumberWriter strategy;
            if(CultureName == null)
            {
                var paramName = "CultureName";
                throw new ArgumentNullException(paramName, Resources.Numbers.ArgumentNullErrorMessage);
            }
            switch (CultureName.ToLower())
            {
                case "en-gb":
                    strategy = new EnGbNumberWriter();
                    break;
                default:
                    strategy = new EnGbNumberWriter();
                    break;
            }

            return new NumberWriterService(strategy);

        }
    }
}