namespace FTD2XX.Enums;

/// <summary>
/// MPSSE bitbang modes
/// </summary>
enum MpsseMode : uint
{
    BITMODE_RESET = 0x00,
    BITMODE_BITBANG = 0x01,
    BITMODE_MPSSE = 0x02,
    BITMODE_SYNCBB = 0x04,
    BITMODE_MCU = 0x08,

    /// <summary>
    ///  CPU-style fifo mode gets set via EEPROM */	coolnumber9, 03/01/10
    /// </summary>
    BITMODE_OPTO = 0x10,
    BITMODE_CBUS = 0x20
};