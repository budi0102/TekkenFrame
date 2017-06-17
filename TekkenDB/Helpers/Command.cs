using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TekkenDB.Enums;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Command
    {
        [DataMember]
        public Directions Directions { get; set; }
        [DataMember]
        public Limb Limb { get; set; }

        [DataMember]
        public HitPosition HitPosition { get; set; }
        [DataMember]
        public string Property { get; set;}
        [DataMember]
        public Damage Damage { get; set; }
        [DataMember]
        public Frame ActiveFrame { get; set; }
        [DataMember]
        public FrameAdvantage GuardedFrame { get; set; }
        [DataMember]
        public FrameAdvantage HitFrame { get; set; }
        [DataMember]
        public FrameAdvantage CounterHitFrame { get; set; }
        [DataMember]
        public string EnemyProperty { get; set; }

        public Command()
        {
            Directions = new Directions();
            Limb = new Limb();

            Directions.Locale = Locale.English;
            Limb.Locale = Locale.English;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if(Directions!=null && Directions.Any())
            {
                result.Append(Directions);
            }
            result.Append(Limb.ToString());

            return result.ToString();
        }

        public Locale Locale = Locale.English;
    }
}
