using System;

namespace LibFtdiDotNet.Structs;

public unsafe struct ftdi_device_list
{
    /// <summary>
    /// Pointer to next entry
    /// </summary>
    public ftdi_device_list* next = (ftdi_device_list*)IntPtr.Zero;

    /// <summary>
    /// Pointer to libusb's usb_device struct
    /// </summary>
    public IntPtr dev = IntPtr.Zero;

    public ftdi_device_list()
    {
    }
}