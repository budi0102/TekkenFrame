using System;

namespace TekkenDB.Enums
{
    [Flags]
    public enum HitPosition
    {
        None = 0,
        High = 1,
        Mid = 1 << 1,
        SpecialMid = 1 << 2,
        Low = 1 << 3,
        Grounded = 1 << 4,
        Unblockable = 1 << 5
    }
}
