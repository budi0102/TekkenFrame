using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;
using Newtonsoft.Json;

namespace TekkenDB.DBWriter
{
    public static class DbWriter
    {
        public static void Write(object moves, string filepath)
        {
            using (StreamWriter sr = new StreamWriter(filepath))
            {
                string data = JsonConvert.SerializeObject(moves);
                sr.Write(data);
            }
        }

        /*public static async void WriteAsync(string filepath)
        {

        }*/
    }
}
