namespace LibFtdiDotNet.Constants;

public static class FTDI_Constants
{
    #region DEFAULT_VALUES

    public const uint FT_DEFAULT_BAUD_RATE = 9600;
    public const uint FT_DEFAULT_DEADMAN_TIMEOUT = 5000;
    public const int FT_COM_PORT_NOT_ASSIGNED = -1;
    public const uint FT_DEFAULT_IN_TRANSFER_SIZE = 0x1000;
    public const uint FT_DEFAULT_OUT_TRANSFER_SIZE = 0x1000;
    public const byte FT_DEFAULT_LATENCY = 16;
    public const uint FT_DEFAULT_DEVICE_ID = 0x04036001;
    
    #endregion
}