using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMessageGenerator
{
    public static class AppSettings
    {
        public static string ColumnNames { get { return ConfigurationManager.AppSettings["columnNames"]; } }
        public static string RuntimeValuesForColumns { get { return ConfigurationManager.AppSettings["runtimeValuesForColumns"]; } }
        public static string DirectoryName { get { return ConfigurationManager.AppSettings["directoryName"]; } }
        public static int NumberOfRecords { get { return Convert.ToInt32(ConfigurationManager.AppSettings["numberOfRecords"]); } }
    }
}
