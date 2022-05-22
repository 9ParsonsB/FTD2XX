//***********************************************************************
/*
    FTDI CIL Bindings
	 - Original source by: Jelmer Vernstok - http://jelmer.vernstok.nl/oss/ftdi-cil
     - Updated using MonoDevelop in Linux by: Kristoffer Dominic Amora (a.k.a. coolnumber9)
*/
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibFtdiDotNet.Enums;
using LibFtdiDotNet.Structs;
using LibFtdiDotNet.Structs.LibUsb;
using static LibFtdiDotNet.Internal.Methods;

namespace LibFtdiDotNet;

// FTDI chip type
/* Definitions for flow control  */
//	#define SIO_RESET          0 /* Reset the port */
//	#define SIO_MODEM_CTRL     1 /* Set the modem control register */
//	#define SIO_SET_FLOW_CTRL  2 /* Set flow control register */
//	#define SIO_SET_BAUD_RATE  3 /* Set baud rate */
//	#define SIO_SET_DATA       4 /* Set the data characteristics of the port */

//	#define FTDI_DEVICE_OUT_REQTYPE (USB_TYPE_VENDOR | USB_RECIP_DEVICE | USB_ENDPOINT_OUT)
//	#define FTDI_DEVICE_IN_REQTYPE (USB_TYPE_VENDOR | USB_RECIP_DEVICE | USB_ENDPOINT_IN)
/* Requests */
//	#define SIO_RESET_REQUEST             SIO_RESET
//	#define SIO_SET_BAUDRATE_REQUEST      SIO_SET_BAUD_RATE
//	#define SIO_SET_DATA_REQUEST          SIO_SET_DATA
//	#define SIO_SET_FLOW_CTRL_REQUEST     SIO_SET_FLOW_CTRL
//	#define SIO_SET_MODEM_CTRL_REQUEST    SIO_MODEM_CTRL
//	#define SIO_POLL_MODEM_STATUS_REQUEST 0x05
//	#define SIO_SET_EVENT_CHAR_REQUEST    0x06
//	#define SIO_SET_ERROR_CHAR_REQUEST    0x07
//	#define SIO_SET_LATENCY_TIMER_REQUEST 0x09
//	#define SIO_GET_LATENCY_TIMER_REQUEST 0x0A
//	#define SIO_SET_BITMODE_REQUEST       0x0B
//	#define SIO_READ_PINS_REQUEST         0x0C
//	#define SIO_READ_EEPROM_REQUEST       0x90
//	#define SIO_WRITE_EEPROM_REQUEST      0x91
//	#define SIO_ERASE_EEPROM_REQUEST      0x92

//	#define SIO_RESET_SIO 0
//	#define SIO_RESET_PURGE_RX 1
//	#define SIO_RESET_PURGE_TX 2

//	#define SIO_DISABLE_FLOW_CTRL 0x0
//	#define SIO_RTS_CTS_HS (0x1 << 8)
//	#define SIO_DTR_DSR_HS (0x2 << 8)
//	#define SIO_XON_XOFF_HS (0x4 << 8)

//	#define SIO_SET_DTR_MASK 0x1
//	#define SIO_SET_DTR_HIGH ( 1 | ( SIO_SET_DTR_MASK  << 8))
//	#define SIO_SET_DTR_LOW  ( 0 | ( SIO_SET_DTR_MASK  << 8))
//	#define SIO_SET_RTS_MASK 0x2
//	#define SIO_SET_RTS_HIGH ( 2 | ( SIO_SET_RTS_MASK << 8 ))
//	#define SIO_SET_RTS_LOW ( 0 | ( SIO_SET_RTS_MASK << 8 ))

//	#define SIO_RTS_CTS_HS (0x1 << 8)
/* marker for unused usb urb structures
   //	(taken from libusb) */
//	#define FTDI_URB_USERCONTEXT_COOKIE ((void *)0x1)

public class FtdiContext : IDisposable
{
    private ftdi_context ftdi = new ftdi_context();

    private bool deviceOpen = false;

    public FtdiContext()
    {
        ftdi_init(ref ftdi);
    }

    public FtdiContext(int vendor, int product) : this()
    {
        CheckRet(ftdi_usb_open(ref ftdi, vendor, product));
        deviceOpen = true;
    }
    
    public FtdiContext(string description) : this()
    {
        var ret = ftdi_usb_open_string(ref ftdi,description);
        CheckRet(ret);
        deviceOpen = true;
    }

    public FtdiContext(int vendor, int product, string description, string serial) : this()
    {
        var ret = ftdi_usb_open_desc(ref ftdi, vendor, product, description, serial);
        CheckRet(ret);
        deviceOpen = true;
    }

    public FtdiContext(IntPtr dev) : this()
    {
        CheckRet(ftdi_usb_open_dev(ref ftdi, dev));
        deviceOpen = true;
    }

    public void OpenDevice(int vendor, int product)
    {
        // TODO: dont force the use of exceptions for control flow
        if (deviceOpen)
        {
            throw new DeviceAlreadyOpenedException();
        }
        
        // TODO: dont force the use of exceptions for control flow
        CheckRet(ftdi_usb_open(ref ftdi, vendor, product));
        deviceOpen = true;
    }
    

    /// <param name="description">can be a device node if prefixed by 'd:'</param>
    /// <exception cref="DeviceAlreadyOpenedException"></exception>
    public void OpenDevice(string description)
    {
        // TODO: dont force the use of exceptions for control flow
        if (deviceOpen)
        {
            throw new DeviceAlreadyOpenedException();
        }
        
        // TODO: dont force the use of exceptions for control flow
        CheckRet(ftdi_usb_open_string(ref ftdi, description));
        deviceOpen = true;
    }

    /// <summary>
    /// Get the underlying ftdi_context struct
    /// </summary>
    public ftdi_context GetContext() => ftdi;

    public int Baudrate
    {
        set { CheckRet(ftdi_set_baudrate(ref ftdi, value)); }
    }

    public uint ReadChunkSize
    {
        set { CheckRet(ftdi_read_data_set_chunksize(ref ftdi, value)); }
        get
        {
            uint chunksize;
            CheckRet(ftdi_read_data_get_chunksize(ref ftdi, out chunksize));
            return chunksize;
        }
    }

    public uint WriteChunkSize
    {
        set { CheckRet(ftdi_write_data_set_chunksize(ref ftdi, value)); }
        get
        {
            uint chunksize;
            CheckRet(ftdi_write_data_get_chunksize(ref ftdi, out chunksize));
            return chunksize;
        }
    }

    public byte LatencyTimer
    {
        set { CheckRet(ftdi_set_latency_timer(ref ftdi, value)); }
        get
        {
            byte latency;
            CheckRet(ftdi_get_latency_timer(ref ftdi, out latency));
            return latency;
        }
    }

    public Interface Interface
    {
        set { CheckRet(ftdi_set_interface(ref ftdi, value)); }
    }

    // destructor
    ~FtdiContext()
    {
        ReleaseUnmanagedResources();
    }

    [DllImport("libftdi1")]
    internal static extern int ftdi_set_baudrate(ref ftdi_context ftdi, int baudrate);

    internal void CheckRet(int ret)
    {
        if (ret >= 0)
            return;

        IntPtr str = ftdi_get_error_string(ref ftdi);

        Console.WriteLine("{0}", ret);
        throw new Exception(Marshal.PtrToStringAnsi(str));
    }
    
    internal void CheckRet(FT_STATUS ret)
    {
        if (ret >= 0)
            return;

        IntPtr str = ftdi_get_error_string(ref ftdi);

        Console.WriteLine("{0}", ret);
        throw new Exception(Marshal.PtrToStringAnsi(str));
    }


    public void Reset()
    {
        CheckRet(ftdi_usb_reset(ref ftdi));
    }


    public void Close()
    {
        CheckRet(ftdi_usb_close(ref ftdi));
    }


    public void PurgeBuffers()
    {
        CheckRet(ftdi_usb_purge_buffers(ref ftdi));
    }


    public void WriteEEPROM(ftdi_eeprom eeprom)
    {
        byte[] data = new byte[128];

        ftdi_eeprom.ftdi_eeprom_build(ref eeprom, ref data);

        CheckRet(ftdi_write_eeprom(ref ftdi, ref data));
    }

    public void EraseEEPROM()
    {
        CheckRet(ftdi_erase_eeprom(ref ftdi));
    }

    public byte[] ReadEEPROM()
    {
        /* FIXME */
        return null;
    }


    public unsafe FT_STATUS ReadData(byte[] buf, int size)
    {
        FT_STATUS ret;
        fixed (byte* p = buf)
        {
            ret = ftdi_read_data(ref ftdi, p, size);
        }
        CheckRet(ret);
        return ret;
    }


    public unsafe FT_STATUS WriteData(byte[] buf, int size)
    {
        FT_STATUS ret;
        fixed (byte* p = buf)
        {
             ret = ftdi_write_data(ref ftdi, p, size);
        }
        
        CheckRet(ret);
        return ret;
    }

    [DllImport("libftdi1")]
    internal static extern int ftdi_read_pins(ref ftdi_context ftdi, out byte pins);

    public byte GetPins()
    {
        byte pins;
        CheckRet(ftdi_read_pins(ref ftdi, out pins));
        return pins;
    }


    public void EnableBitBang(byte bitmask)
    {
        CheckRet(ftdi_enable_bitbang(ref ftdi, bitmask));
    }

    public void DisableBitBang()
    {
        CheckRet(ftdi_disable_bitbang(ref ftdi));
    }
    
    public void SetBitMode(byte bitmask, FT_BIT_MODE mode)
    {
        CheckRet(ftdi_set_bitmode(ref ftdi, bitmask, mode));
    }
    

    public void SetLineProperty(BitsPerWord bits, StopBits sbit, Parity parity)
    {
        CheckRet(ftdi_set_line_property(ref ftdi, bits, sbit, parity));
    }

    public unsafe Structs.LibUsb.Device[] GetDeviceList(int vendor, int product)
    {
        List<Structs.LibUsb.Device> list = new ();
        ftdi_device_list devlist, d;
        ftdi_init(ref ftdi);

        if (ftdi_usb_find_all(ref ftdi, out devlist, vendor, product) < 0)
        {
            throw new Exception("ftdi_usb_find_all failed");
        }

        for (d = devlist; d.dev != IntPtr.Zero; d = *d.next)
        {
            // TODO: dispose?
            list.Add( LibFtdiDotNet.Structs.LibUsb.Device.DangerousCreate(d.dev));
        }

        ftdi_deinit(ref ftdi);

        ftdi_list_free(&devlist);

        return list.ToArray();
    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    public void ListDevices()
    {
        
    }
}