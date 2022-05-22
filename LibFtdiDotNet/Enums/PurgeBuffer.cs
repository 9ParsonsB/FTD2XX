using System;

namespace LibFtdiDotNet.Enums
{
    [Flags()]
    public enum PurgeBuffer : uint
    {
        None = 0,
        RX = 1,
        TX = 2,
        Both = RX | TX
    }
}
