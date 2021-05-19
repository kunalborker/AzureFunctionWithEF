using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionWithEF.Class
{
    public class CSVData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccesskeyID { get; set; }
        public string Secretaccesskey { get; set; }
        public string Consoleloginlink { get; set; }
    }

    public class RootObject
    {
        public List<CSVData> CSVData { get; set; }
    }
}
