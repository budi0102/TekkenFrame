using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB
{
    [DataContract]
    public class Frame
    {
        #region Public Members
        [DataMember]
        public int Active { get; set; }
        [DataMember(IsRequired = false)]
        public int FastestInput { get; set; }
        #endregion

        #region Constructors
        private Frame()
        {
            Active = 0;
            FastestInput = 0;
        }
        public Frame(int active)
        {
            Active = active;
            FastestInput = active;
        }
        public Frame(int active, int fastest)
        {
            Active = active;
            FastestInput = fastest;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            if (FastestInput != Active)
            {
                return string.Format("{0} ({1})", Active, FastestInput);
            }
            else
            {
                return Active.ToString();
            }
        }
        #endregion
    }
}
