namespace LibFtdiDotNet.Enums;

/// <summary>
/// Number of stop bits for ftdi_set_line_property()
/// </summary>
public enum StopBitsType
{
    STOP_BIT_1 = 0,
    STOP_BIT_15 = 1,
    STOP_BIT_2 = 2
};