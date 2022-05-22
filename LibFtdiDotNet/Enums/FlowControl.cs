namespace LibFtdiDotNet.Enums
{
    public enum FlowControl : ushort
    {
        None = 0x000,
        RTSCTS = 0x100,
        DTRDSR = 0x200,
        XonXoff = 0x400
    }
}
