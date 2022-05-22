namespace FTD2XX.Enums;

public enum FtdiBitMode : byte
{
    /// Reset the IO Bit Mode
    Reset = 0x0,

    /// <summary>
    /// Asynchronous Bit Bang Mode
    /// </summary>
    Asynchronous = 0x1,

    /// <summary>
    /// MPSSE
    /// </summary>
    MPSSE = 0x2,

    /// <summary>
    /// Synchronous Bit Bang Mode
    /// </summary>
    Synchronous = 0x4,

    /// <summary>
    /// MCU Host Bus Emulation
    /// </summary>
    McuHostBusEmulation = 0x8,

    /// <summary>
    /// Fast Serial For Opto-Isolation
    /// </summary>
    FastSerial = 0x10,
}