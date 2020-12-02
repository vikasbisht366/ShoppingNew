using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AustraliaDAL
{
    public sealed class Cls_ConnectionString
    {
        public static string GetBayrueConnectionString()
        {
            return AustraliaDAL.Properties.Settings.Default.AustraliaConnectionString;
            //return "";
        }
    }
}
