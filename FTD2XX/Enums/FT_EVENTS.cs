namespace FTD2XX.Enums;

/// <summary>
/// FTDI device event types that can be monitored
/// </summary>
public enum FT_EVENTS : uint
{
    /// <summary>
    /// Event on receive character
    /// </summary>
   FT_EVENT_RXCHAR = 0x00000001,

    /// <summary>
    /// Event on modem status change
    /// </summary>
    FT_EVENT_MODEM_STATUS = 0x00000002,

    /// <summary>
    /// Event on line status change
    /// </summary>
    FT_EVENT_LINE_STATUS = 0x00000004,
}