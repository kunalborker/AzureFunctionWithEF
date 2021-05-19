using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AzureFunctionWithEF.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzureFunctionWithEF.Utils
{
    public class GetCSVDetails
    {
        public static List<CSVData> GetCSVContent(string filePath)
        {
            try
            {
                var csv = new List<string[]>();
                var lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                    csv.Add(line.Split(','));
                var properties = lines[0].Split(',');
                var listObjResult = new List<Dictionary<string, string>>();
                for (int i = 1; i < lines.Length; i++)
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                        objResult.Add(properties[j], csv[i][j]);

                    listObjResult.Add(objResult);
                }
                var json =  JsonConvert.SerializeObject(listObjResult);
                var csvdata = JsonConvert.DeserializeObject<List<CSVData>>(json);
                return csvdata;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
