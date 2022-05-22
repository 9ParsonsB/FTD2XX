using System;
using System.Runtime.InteropServices;
using FTD2XXDotNet.Enums;

namespace FTD2XXDotNet;

[StructLayout(LayoutKind.Sequential)]
public struct ftdi_context
{
    #region USB specific

    /// <summary>
    /// libusb's usb_dev_handle 
    /// </summary>
    IntPtr usb_dev;

    int usb_read_timeout;
    int usb_write_timeout;

    #endregion

    #region FTDI specific

    /// <summary>
    /// FTDI chip type
    /// </summary>
    ChipType type;

    int baudrate;
    byte bitbang_enabled;

    /// <summary>
    /// pointer to read buffer for ftdi_read_data 
    /// </summary>
    unsafe byte* readbuffer;

    uint readbuffer_offset;

    /// <summary>
    /// number of remaining data in internal read buffer 
    /// </summary>
    uint readbuffer_remaining;

    #endregion

    /// <summary>
    /// read buffer chunk size
    /// </summary>
    uint readbuffer_chunksize;

    /// <summary>
    /// write buffer chunk size
    /// </summary>
    uint writebuffer_chunksize;

    #region FTDI FT2232C requirements

    /// <summary>
    /// FT2232C interface number: 0 or 1 
    /// </summary>
    int iface; // 0 or 1

    /// <summary>
    /// FT2232C index number: 1 or 2 
    /// </summary>
    int index;

    // Endpoints
    /// <summary>
    /// FT2232C end points: 1 or 2 
    /// </summary>
    int in_ep;

    /// <summary>
    /// 1 or 2
    /// </summary>
    int out_ep;

    #endregion

    /// <summary>
    /// 1: (default) Normal bitbang mode, 2: FT2232C SPI bitbang mode
    /// </summary>
    byte bitbang_mode;

    int eeprom_size;

    // misc
    /// <summary>
    /// String representation of last error
    /// </summary>
    IntPtr error_str; /* const char * */

    /// <summary>
    /// Buffer needed for async communication 
    /// </summary>
    IntPtr async_usb_buffer;

    /// <summary>
    ///  Number of USB-structures we can buffer
    /// </summary>
    uint async_usb_buffer_size;
};