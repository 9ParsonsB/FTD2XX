using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTD2XX.Internal
{
    public static class Methods
    {
        public static void ftdi_status_to_exception(Internal.Constants.FT_STATUS status,
            ref Internal.Structures.ftdi_context ftdi)
        {
            string message = null;
            IntPtr hStr = Internal.Methods.ftdi_get_error_string(ref ftdi);
            if (hStr != IntPtr.Zero)
            {
                message = System.Runtime.InteropServices.Marshal.PtrToStringAuto(hStr);
            }

            ftdi_status_to_exception(status, message);
        }

        private static IntPtr ftdi_get_error_string(ref Structures.ftdi_context ftdi)
        {
            return Internal.Linux.Methods.ftdi_get_error_string(ref ftdi);
        }

        public static void ftdi_status_to_exception(Internal.Constants.FT_STATUS status, string message = null)
        {
            if (status != Constants.FT_STATUS.None && message != null)
            {
                Console.Error.WriteLine("ftdi: error {0} ({1}): {2}", (int)status, status.ToString(), message);
            }

            switch (status)
            {
                case Internal.Constants.FT_STATUS.DeviceNotFound:
                {
                    throw new DeviceNotFoundException();
                }
                case Internal.Constants.FT_STATUS.DeviceNotOpened:
                {
                    throw new DeviceNotOpenedException();
                }
                case Internal.Constants.FT_STATUS.DeviceNotOpenedForErase:
                {
                    throw new DeviceNotOpenedException(DeviceOpenPurpose.Erase);
                }
                case Internal.Constants.FT_STATUS.DeviceNotOpenedForWrite:
                {
                    throw new DeviceNotOpenedException(DeviceOpenPurpose.Write);
                }
                case Internal.Constants.FT_STATUS.EEPROMEraseFailed:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Erase);
                }
                case Internal.Constants.FT_STATUS.EEPROMNotPresent:
                {
                    throw new EEPROMNotPresentException();
                }
                case Internal.Constants.FT_STATUS.EEPROMNotProgrammed:
                {
                    throw new EEPROMNotProgrammedException();
                }
                case Internal.Constants.FT_STATUS.EEPROMReadFailed:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Read);
                }
                case Internal.Constants.FT_STATUS.EEPROMWriteFailed:
                {
                    throw new EEPROMOperationFailedException(DeviceOperation.Write);
                }
                case Internal.Constants.FT_STATUS.FailedToWriteDevice:
                {
                    throw new DeviceOperationFailedException(DeviceOperation.Erase);
                }
                case Internal.Constants.FT_STATUS.InsufficientResources:
                {
                    throw new InsufficientMemoryException();
                }
                case Internal.Constants.FT_STATUS.InvalidArguments:
                {
                    throw new ArgumentException();
                }
                case Internal.Constants.FT_STATUS.InvalidBaudRate:
                {
                    throw new ArgumentException("The baud rate is invalid", "BaudRate");
                }
                case Internal.Constants.FT_STATUS.InvalidHandle:
                {
                    throw new ArgumentException("The handle is invalid", "Handle");
                }
                case Internal.Constants.FT_STATUS.InvalidParameter:
                {
                    throw new ArgumentException("The parameter is invalid");
                }
                case Internal.Constants.FT_STATUS.IOError:
                {
                    throw new System.IO.IOException();
                }
                case Internal.Constants.FT_STATUS.UnknownError:
                {
                    throw new Exception("Unknown error occurred");
                }
            }
        }

        public static Constants.FT_STATUS ftdi_usb_open_string(ref Structures.ftdi_context ftdi, string desc)
        {
            return Internal.Linux.Methods.ftdi_usb_open_string(ref ftdi, desc);
        }

        internal static Constants.FT_STATUS ftdi_set_line_property2(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi, BitsPerWord bits, StopBits stopBits,
            Parity parity, bool break_on)
        {
            return Linux.Methods.ftdi_set_line_property2(ref ftdi, bits, stopBits, parity, break_on);
        }

        internal static Constants.FT_STATUS ftdi_set_line_property(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi, BitsPerWord bits, StopBits stopBits,
            Parity parity)
        {
            return Linux.Methods.ftdi_set_line_property(ref ftdi, bits, stopBits, parity);
        }

        public static Constants.FT_STATUS ftdi_set_baudrate(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi, int baudRate)
        {
            return Linux.Methods.ftdi_set_baudrate(ref ftdi, baudRate);
        }

        internal static Constants.FT_STATUS ftdi_usb_reset(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi)
        {
            return Linux.Methods.ftdi_usb_reset(ref ftdi);
        }

        public static Constants.FT_STATUS ftdi_usb_open(ref Internal.Structures.ftdi_context ftdi, int vendor,
            int product)
        {
            return Linux.Methods.ftdi_usb_open(ref ftdi, vendor, product);
        }

        public static Constants.FT_STATUS ftdi_init(ref Internal.Structures.ftdi_context ftdi)
        {
            return Linux.Methods.ftdi_init(ref ftdi);
        }

        public static Constants.FT_STATUS ftdi_usb_close(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi)
        {
            return Linux.Methods.ftdi_usb_close(ref ftdi);
        }

        public static Constants.FT_STATUS ftdi_read_data(
            ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi, IntPtr buf, int size)
        {
            return Linux.Methods.ftdi_read_data(ref ftdi, buf, size);
        }

        public static int ftdi_write_data(ref Internal.Structures.ftdi_context /*struct ftdi_context*/ ftdi, IntPtr buf,
            int size)
        {
            return Linux.Methods.ftdi_write_data(ref ftdi, buf, size);
        }

        public static unsafe Constants.FT_STATUS ftdi_usb_find_all(ref Structures.ftdi_context context, out Structures.ftdi_device_list list, uint vid, uint pid)
        {
            list = new Structures.ftdi_device_list();
            Constants.FT_STATUS result;
            fixed (Structures.ftdi_device_list* p = &list)
            {
                result = Linux.Methods.ftdi_usb_find_all(ref context, p, vid, pid);
            }
               
            return result;
        }
    }
}