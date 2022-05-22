namespace FTD2XX.Enums
{
    /// <summary>
    /// I think this was for the old ftdi lib, not `libftdi1`
    /// </summary>
    public enum FT_LISTDEVICES : uint
    {
        None = 0x00000000,
        OpenBySerialNumber = 0x00000001,
        OpenByDescription = 0x00000002,
        ListAll = 0x20000000,
        ListByIndex = 0x40000000,
        ListNumberOnly = 0x80000000
    }
}