using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public static class GlobalConnection
    {
        private static string _ConnectionString;
        public static string DBConnection
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"].ToString(); 
            } 
            set
            {
                _ConnectionString = value;
            }
        }
    }
}
