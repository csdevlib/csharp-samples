using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Extending {
    //low-level system 
    //20180205154537
    //950130162456

    public static class DateTimeExtensions {
        public static string ToDeviceFormat(this DateTime dt) {
            string result = dt.ToString("yyyyMMddhhmmss");
            return dt.Year >= 2000 ? result : result.Substring(2);
        }
    }
}