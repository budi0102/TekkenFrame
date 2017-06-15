using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Enums;
using TekkenDB.Interface;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Move : IMove
    {
        [DataMember(Name ="Name")]
        public Name MoveName { get; set; }
        [DataMember]
        public Commands Commands { get; set; }
        [IgnoreDataMember]
        public Command LastCommand { get { return Commands.Last(); } }
        
        [IgnoreDataMember]
        public Damage Damage { get { return LastCommand.Damage; } }
        [IgnoreDataMember]
        public int TotalDamage { get { return Commands.Sum(o => o.Damage.NormalDamage); } }
        [IgnoreDataMember]
        public HitPosition[] HitPositions { get { return Commands.Select(c => c.HitPosition).ToArray(); } }
        [IgnoreDataMember]
        public HitPosition HitPosition { get { return LastCommand.HitPosition; } }
        [IgnoreDataMember]
        public Frame ActiveFrame { get { return Commands.First().ActiveFrame; } }
        [IgnoreDataMember]
        public FrameAdvantage GuardedFrame { get { return LastCommand.GuardedFrame; } }
        [IgnoreDataMember]
        public FrameAdvantage HitFrame { get { return LastCommand.HitFrame; } }
        [IgnoreDataMember]
        public FrameAdvantage CounterHitFrame { get { return LastCommand.CounterHitFrame; } }
        [IgnoreDataMember]
        public string EnemyProperty { get { return LastCommand.EnemyProperty; } }

        [DataMember]
        public string Note { get; set; }

        public override string ToString()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}",
                '\t',
                MoveName,
                Commands,
                TotalDamage,
                string.Join(";", HitPositions),
                ActiveFrame,
                GuardedFrame,
                HitFrame,
                CounterHitFrame,
                EnemyProperty ?? string.Empty
                );
        }

    }
}
