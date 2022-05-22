using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTD2XXDotNet.Constants;
using FTD2XXDotNet.Enums;
using FTD2XXDotNet.Structs;

namespace FTD2XXDotNet.Internal
{
    public static class Methods
    {
        public static void ftdi_status_to_exception(FT_STATUS status,
            ref ftdi_context ftdi)
        {
            string message = null;
            IntPtr hStr = Internal.Methods.ftdi_get_error_string(ref ftdi);
            if (hStr != IntPtr.Zero)
            {
                message = System.Runtime.InteropServices.Marshal.PtrToStringAuto(hStr);
            }

            ftdi_status_to_exception(status, message);
        }

        public static IntPtr ftdi_get_error_string(ref ftdi_context ftdi)
        {
            return Internal.Linux.Methods.ftdi_get_error_string(ref ftdi);
        }

        public static void ftdi_status_to_exception(FT_STATUS status, string message = null)
        {
            if (status != FT_STATUS.FT_OK && message != null)
            {
                Console.Error.WriteLine("ftdi: error {0} ({1}): {2}", (int)status, status.ToString(), message);
            }

            switch (status)
            {
                case FT_STATUS.FT_DEVICE_NOT_FOUND:
                {
                    throw new DeviceNotFoundException();
                }
                case FT_STATUS.FT_DEVICE_NOT_OPENED:
                {
                    throw new DeviceNotOpenedException();
                }
                case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_ERASE:
                {
                    throw new DeviceNotOpenedException(DeviceOpenPurpose.Erase);
                }
                case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_WRITE:
                {
                    throw new DeviceNotOpenedException(DeviceOpenPurpose.Write);
                }
                case FT_STATUS.FT_EEPROM_ERASE_FAILED:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Erase);
                }
                case FT_STATUS.FT_EEPROM_NOT_PRESENT:
                {
                    throw new EEPROMNotPresentException();
                }
                case FT_STATUS.FT_EEPROM_NOT_PROGRAMMED:
                {
                    throw new EEPROMNotProgrammedException();
                }
                case FT_STATUS.FT_EEPROM_READ_FAILED:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Read);
                }
                case FT_STATUS.FT_EEPROM_WRITE_FAILED:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Write);
                }
                case FT_STATUS.FT_FAILED_TO_WRITE_DEVICE:
                {
                    throw new DeviceOperationFailedException(DeviceOperation.Erase);
                }
                case FT_STATUS.FT_INSUFFICIENT_RESOURCES:
                {
                    throw new InsufficientMemoryException();
                }
                case FT_STATUS.FT_INVALID_ARGS:
                {
                    throw new ArgumentException();
                }
                case FT_STATUS.FT_INVALID_BAUD_RATE:
                {
                    throw new ArgumentException("The baud rate is invalid", "BaudRate");
                }
                case FT_STATUS.FT_INVALID_HANDLE:
                {
                    throw new ArgumentException("The handle is invalid", "Handle");
                }
                case FT_STATUS.FT_INVALID_PARAMETER:
                {
                    throw new ArgumentException("The parameter is invalid");
                }
                case FT_STATUS.FT_IO_ERROR:
                {
                    throw new System.IO.IOException();
                }
                case FT_STATUS.FT_OTHER_ERROR:
                {
                    throw new Exception("Unknown error occurred");
                }
            }
        }

        public static FT_STATUS ftdi_usb_open_string(ref ftdi_context ftdi, string desc)
        {
            return Internal.Linux.Methods.ftdi_usb_open_string(ref ftdi, desc);
        }

        internal static FT_STATUS ftdi_set_line_property2(
            ref ftdi_context /*struct ftdi_context*/ ftdi, BitsPerWord bits, StopBits stopBits,
            Parity parity, bool break_on)
        {
            return Linux.Methods.ftdi_set_line_property2(ref ftdi, bits, stopBits, parity, break_on);
        }

        internal static FT_STATUS ftdi_set_line_property(
            ref ftdi_context /*struct ftdi_context*/ ftdi, BitsPerWord bits, StopBits stopBits,
            Parity parity)
        {
            return Linux.Methods.ftdi_set_line_property(ref ftdi, bits, stopBits, parity);
        }

        public static FT_STATUS ftdi_set_baudrate(
            ref ftdi_context /*struct ftdi_context*/ ftdi, int baudRate)
        {
            return Linux.Methods.ftdi_set_baudrate(ref ftdi, baudRate);
        }

        internal static FT_STATUS ftdi_usb_reset(
            ref ftdi_context /*struct ftdi_context*/ ftdi)
        {
            return Linux.Methods.ftdi_usb_reset(ref ftdi);
        }

        public static FT_STATUS ftdi_usb_open(ref ftdi_context ftdi, int vendor,
            int product)
        {
            return Linux.Methods.ftdi_usb_open(ref ftdi, vendor, product);
        }

        public static FT_STATUS ftdi_init(ref ftdi_context ftdi)
        {
            return Linux.Methods.ftdi_init(ref ftdi);
        }

        public static FT_STATUS ftdi_usb_close(
            ref ftdi_context /*struct ftdi_context*/ ftdi)
        {
            return Linux.Methods.ftdi_usb_close(ref ftdi);
        }

        public static FT_STATUS ftdi_read_data(
            ref ftdi_context /*struct ftdi_context*/ ftdi, IntPtr buf, int size)
        {
            return Linux.Methods.ftdi_read_data(ref ftdi, buf, size);
        }

        public static int ftdi_write_data(ref ftdi_context /*struct ftdi_context*/ ftdi, IntPtr buf,
            int size)
        {
            return Linux.Methods.ftdi_write_data(ref ftdi, buf, size);
        }

        public static unsafe FT_STATUS ftdi_usb_find_all(ref ftdi_context context, out ftdi_device_list list, uint vid, uint pid)
        {
            list = new ftdi_device_list();
            FT_STATUS result;
            fixed (ftdi_device_list* p = &list)
            {
                result = Linux.Methods.ftdi_usb_find_all(ref context, p, vid, pid);
            }
               
            return result;
        }

        public static FT_STATUS ftdi_usb_open_desc(ref ftdi_context ftdi, int vid, int pid, string desc, string serial)
        {
            return Linux.Methods.ftdi_usb_open_desc(ref ftdi, vid, pid, desc, serial);
        }

        public static FT_STATUS ftdi_usb_open_dev(ref ftdi_context ftdi, IntPtr dev)
        {
            return Linux.Methods.ftdi_usb_open_dev(ref ftdi, dev);
        }

        public static void ftdi_deinit(ref ftdi_context ftdi)
        {
            Linux.Methods.ftdi_deinit(ref ftdi);
        }

        public static FT_STATUS ftdi_write_eeprom(ref ftdi_context ftdi, ref byte[] eeprom)
        {
            return Linux.Methods.ftdi_write_eeprom(ref ftdi, ref eeprom);
        }

        public static FT_STATUS ftdi_erase_eeprom(ref ftdi_context ftdi)
        {
            return Linux.Methods.ftdi_erase_eeprom(ref ftdi);
        }
    }
}