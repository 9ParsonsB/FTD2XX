using System;
using System.Runtime.InteropServices;

namespace LibFtdiDotNet.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct ftdi_device_list
{
    /// <summary>
    /// Pointer to next entry
    /// </summary>
    public ftdi_device_list* next;

    /// <summary>
    /// Pointer to libusb's usb_device struct
    /// </summary>
    public IntPtr dev;


}