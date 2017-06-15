using System;
using System.Text;

namespace TekkenDB.Enums
{
    [Flags]
    public enum DirectionEnum
    {
        Neutral = 0,
        Forward = 1,
        Back = 1 << 1,
        Down = 1 << 2,
        Up = 1 << 3,
        Hold = 1 << 4
    }
}
