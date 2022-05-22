namespace FTD2XXDotNet.Enums;

/// <summary>
/// List of FTDI device types
/// </summary>
public enum FT_DEVICE
{
    /// <summary>
    /// FT232B or FT245B device
    /// </summary>
    FT_DEVICE_BM = 0,

    /// <summary>
    /// FT8U232AM or FT8U245AM device
    /// </summary>
    FT_DEVICE_AM = 1,

    /// <summary>
    /// FT8U100AX device
    /// </summary>
    FT_DEVICE_100AX = 2,

    /// <summary>
    /// Unknown device
    /// </summary>
    FT_DEVICE_UNKNOWN = 3,

    /// <summary>
    /// FT2232 device
    /// </summary>
    FT_DEVICE_2232 = 4,

    /// <summary>
    /// FT232R or FT245R device
    /// </summary>
    FT_DEVICE_232R = 5,
    
    /// <summary>
    /// FT2232H device
    /// </summary>
    FT_DEVICE_2232H = 6,
    
    /// <summary>
    /// FT4232H device
    /// </summary>
    FT_DEVICE_4232H = 7,
    
    /// <summary>
    /// FT232H device
    /// </summary>
    FT_DEVICE_232H = 8,

    /// <summary>
    /// FT X-Series device
    /// </summary>
    FT_DEVICE_X_SERIES = 9,

    /// <summary>
    /// FT4222 hi-speed device Mode 0 - 2 interfaces
    /// </summary>
    FT_DEVICE_4222H_0 = 10,

    /// <summary>
    /// FT4222 hi-speed device Mode 1 or 2 - 4 interfaces
    /// </summary>
    FT_DEVICE_4222H_1_2 = 11,

    /// <summary>
    /// FT4222 hi-speed device Mode 3 - 1 interface
    /// </summary>
    FT_DEVICE_4222H_3 = 12,

    /// <summary>
    /// OTP programmer board for the FT4222.
    /// </summary>
    FT_DEVICE_4222_PROG = 13,

    /// <summary>
    /// OTP programmer board for the FT900.
    /// </summary>
    FT_DEVICE_FT900 = 14,

    /// <summary>
    /// OTP programmer board for the FT930.
    /// </summary>
    FT_DEVICE_FT930 = 15,

    /// <summary>
    /// Flash programmer board for the UMFTPD3A.
    /// </summary>
    FT_DEVICE_UMFTPD3A = 16,

    /// <summary>
    /// FT2233HP hi-speed device.
    /// </summary>
    FT_DEVICE_2233HP = 17,

    /// <summary>
    /// FT4233HP hi-speed device.
    /// </summary>
    FT_DEVICE_4233HP = 18,

    /// <summary>
    /// FT2233HP hi-speed device.
    /// </summary>
    FT_DEVICE_2232HP = 19,

    /// <summary>
    /// FT4233HP hi-speed device.
    /// </summary>
    FT_DEVICE_4232HP =20,

    /// <summary>
    /// FT233HP hi-speed device.
    /// </summary>
    FT_DEVICE_233HP = 21,

    /// <summary>
    /// FT232HP hi-speed device.
    /// </summary>
    FT_DEVICE_232HP = 22,

    /// <summary>
    /// FT2233HA hi-speed device.
    /// </summary>
    FT_DEVICE_2232HA = 23,

    /// <summary>
    /// FT4233HA hi-speed device.
    /// </summary>
    FT_DEVICE_4232HA = 24, 
};