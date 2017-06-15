using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class FrameAdvantage
    {
        #region Public Members
        [DataMember]
        public int? Number { get; set; }
        [DataMember(IsRequired =false)]
        public int? NumberUntil { get; set; }
        [DataMember(IsRequired = false)]
        public string Property { get; set; }
        #endregion

        #region Constructor
        private FrameAdvantage()
        {
            Number = null;
            NumberUntil = null;
            Property = null;
        }
        public FrameAdvantage(string property)
            : this()
        {
            Property = property;
        }
        public FrameAdvantage(int number)
            : this()
        {
            Number = number;
        }
        public FrameAdvantage(int number, int numberUntil)
            : this()
        {
            Number = number;
            NumberUntil = numberUntil;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            if (Number == null || !Number.HasValue)
            {
                return Property ?? string.Empty;
            }
            else
            {
                StringBuilder result = new StringBuilder();
                if (Number > 0)
                {
                    result.Append("+");
                }
                else if (Number == 0)
                {
                    result.Append("±");
                }
                result.Append(Number);

                if (NumberUntil != null && NumberUntil.HasValue)
                {
                    result.Append("~");
                    if (NumberUntil > 0)
                    {
                        result.Append("+");
                    }
                    else if (NumberUntil == 0)
                    {
                        result.Append("±");
                    }
                    result.Append(NumberUntil);
                }
                return result.ToString();
            }
        }
        #endregion
    }
}
