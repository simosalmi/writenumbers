using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NumbersApi.Models
{
    public static class Utilities
    {

        public static List<String> SplitToList(string value, string separator)
        {
            List<String> result = new List<String>();
            
            String[] values = value.Split(separator.ToCharArray());
            result = values.ToList<String>();
                    
            return result;
        }        
    }
}