namespace LibFtdiDotNet.Enums;

/// <summary>
/// Parity mode for ftdi_set_line_property()
/// </summary>
public enum ParityType
{
    NONE = 0,
    ODD = 1,
    EVEN = 2,
    MARK = 3,
    SPACE = 4
};