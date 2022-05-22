﻿using System;
using System.Runtime.InteropServices;
using FTD2XX.Constants;
using FTD2XX.Enums;
using FTD2XX.Structs;

namespace FTD2XX.Internal.Linux
{
	internal static class Methods
	{
		private const string LIBRARY_FILENAME = "libftdi1";

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_init(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_open(ref ftdi_context ftdi, int vendor, int product);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_read_data(ref ftdi_context  /*struct ftdi_context*/ ftdi, IntPtr buf, int size);
		[DllImport(LIBRARY_FILENAME)]
		public static extern int ftdi_write_data(ref ftdi_context  /*struct ftdi_context*/ ftdi, IntPtr buf, int size);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_close(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_reset(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_set_baudrate(ref ftdi_context ftdi, int baudRate);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_set_line_property(ref ftdi_context ftdi, BitsPerWord bits, StopBits stopBits, Parity parity);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_set_line_property2(ref ftdi_context ftdi, BitsPerWord bits, StopBits stopBits, Parity parity, bool break_on);

		[DllImport(LIBRARY_FILENAME)]
		public static extern IntPtr ftdi_get_error_string(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_open_string(ref ftdi_context ftdi, string desc);
		
		[DllImport(LIBRARY_FILENAME)]
		public static extern unsafe FT_STATUS ftdi_usb_find_all(ref ftdi_context ftdi, ftdi_device_list* devList, uint vendor, uint product );
		
		

		/// <summary>
		/// "eeprom" needs to be valid 128 byte eeprom (generated by the eeprom generator)
		/// the checksum of the eeprom is validated
		/// </summary>
		/// <param name="ftdi"></param>
		/// <param name="eeprom"></param>
		/// <returns></returns>
		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_read_eeprom(ref ftdi_context ftdi, ref byte[] eeprom);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_write_eeprom(ref ftdi_context ftdi, ref byte[] eeprom);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_erase_eeprom(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern void ftdi_deinit(ref ftdi_context ftdi);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_open_desc(ref ftdi_context ftdi, int vendor, int product, string description,
			string serial);

		[DllImport(LIBRARY_FILENAME)]
		public static extern FT_STATUS ftdi_usb_open_dev(ref ftdi_context ftdi, IntPtr dev);

	}
}
