using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;
using TekkenDB.Enums;

namespace TekkenDB.Interface
{
    public interface IMove
    {
        Name MoveName { get; set; }
        Commands Commands { get; set; }
        Command LastCommand { get; }

        Damage Damage { get; }
        int TotalDamage { get; }
        HitPosition HitPosition { get; }
        Frame ActiveFrame { get; }
        FrameAdvantage GuardedFrame { get; }
        FrameAdvantage HitFrame { get; }
        FrameAdvantage CounterHitFrame { get; }
        string EnemyProperty { get; }

        string Note { get; set; }
    }
}
