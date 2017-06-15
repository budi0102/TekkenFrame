using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Interface;
using TekkenDB.Helpers;
using Newtonsoft.Json;

namespace TekkenDB.DbReader
{
    public static class DbReader
    {
        public static Moves ReadMoves(string filename)
        {
            Moves moves = new Moves();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return moves;
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string data = sr.ReadToEnd();
                moves = JsonConvert.DeserializeObject<Moves>(data);
            }

            return moves;
        }
        public static T Read<T>(string filename)where T : new()
        {
            T moves = new T();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return moves;
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string data = sr.ReadToEnd();
                moves = JsonConvert.DeserializeObject<T>(data);
            }

            return moves;
        }
    }
}
