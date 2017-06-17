using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Name
    {
        [DataMember(IsRequired = false)]
        public int ID { get; set; }
        [DataMember]
        public string IDString { get; set; }
        [DataMember(IsRequired = false)]
        public string Japanese { get; set; }
        [DataMember(IsRequired = false)]
        public string English { get; set; }

        public override string ToString()
        {
            return IDString;
        }

        public Name()
        {
            ID = -1;
            IDString = null;
            Japanese = null;
            English = null;
        }
        public Name(string idString)
        {
            IDString = idString;
            if (idString.Any(o => o > byte.MaxValue))
            {
                Japanese = idString;
            }
            else
            {
                English = idString;
            }
        }
        public Name(string idString, string english, string japanese = null)
        {
            IDString = idString;
            English = english;
            Japanese = japanese;
        }
        public Name(Name name)
        {
            ID = name.ID;
            IDString = name.IDString;
            English = name.English;
            Japanese = name.Japanese;
        }
    }
}
