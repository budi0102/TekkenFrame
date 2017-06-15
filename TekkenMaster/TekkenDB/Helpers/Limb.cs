using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Enums;

namespace TekkenDB.Helpers
{
    public class Limb
    {
        #region Public Members
        [DataMember(Name = "Limb")]
        public LimbEnum Button { get; set; }

        [IgnoreDataMember]
        public Locale Locale = Locale.English;
        [IgnoreDataMember]
        public bool ForceShowNeutral = false;
        #endregion

        #region Constructors
        public Limb()
        {
            this.limb = LimbEnum.Neutral;
        }
        public Limb(Locale locale = Locale.English, bool forceShowNeutral = false)
        {
            this.limb = LimbEnum.Neutral;
            this.Locale = locale;
            this.ForceShowNeutral = forceShowNeutral;
        }
        public Limb(Limb limb)
        {
            this.limb = limb.limb;
            this.Locale = limb.Locale;
            this.ForceShowNeutral = limb.ForceShowNeutral;
        }
        public Limb(Limb limb, Locale locale = Locale.English, bool forceShowNeutral = false)
        {
            this.limb = limb.limb;
            this.Locale = locale;
            this.ForceShowNeutral = forceShowNeutral;
        }
        public Limb(LimbEnum limb, Locale locale = Locale.English, bool forceShowNeutral = false)
        {
            this.limb = limb;
            this.Locale = locale;
            this.ForceShowNeutral = forceShowNeutral;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            string result = string.Empty;
            if(Locale == Locale.English)
            {
                if (limb == LimbEnum.Neutral)
                {
                    if (ForceShowNeutral)
                    {
                        result +="N";
                    }
                }
                else
                {
                    if ((limb & LimbEnum.LeftPunch) != 0)
                    {
                        result += "1";
                    }
                    if((limb & LimbEnum.RightPunch) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "2";
                    }
                    if ((limb & LimbEnum.LeftKick) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "3";
                    }
                    if ((limb & LimbEnum.RightKick) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "4";
                    }
                    if ((limb & LimbEnum.Tag) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "5";
                    }
                    if ((limb & LimbEnum.Hold) != 0)
                    {
                        result += "H";
                    }
                }
            }
            else
            {
                if (limb == LimbEnum.Neutral)
                {
                    if (ForceShowNeutral)
                    {
                        result += "N";
                    }
                }
                else
                {
                    if ((limb & LimbEnum.LeftPunch) != 0)
                    {
                        result += "LP";
                    }
                    if ((limb & LimbEnum.RightPunch) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "RP";
                    }
                    if ((limb & LimbEnum.LeftKick) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "LK";
                    }
                    if ((limb & LimbEnum.RightKick) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "RK";
                    }
                    if ((limb & LimbEnum.Tag) != 0)
                    {
                        if (result.Any())
                        {
                            result += "+";
                        }
                        result += "Tag";
                    }
                    if ((limb & LimbEnum.Hold) != 0)
                    {
                        result += "H";
                    }
                }
            }
            return result;
        }
        #endregion

        #region private members
        private LimbEnum limb;
        #endregion

        
    }
}
