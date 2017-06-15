using System;

namespace TekkenDB.Enums
{
    [Flags]
    public enum LimbEnum
    {
        Neutral = 0,
        LeftPunch = 1,
        RightPunch = 1 << 1,
        LeftKick = 1 << 2,
        RightKick = 1 << 3,
        Tag = 1 << 4,
        Hold = 1 << 5
    }
}
