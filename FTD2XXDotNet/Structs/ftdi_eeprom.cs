using System.Runtime.InteropServices;

namespace FTD2XXDotNet.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ftdi_eeprom
{
    // init and build eeprom from ftdi_eeprom structure
    [DllImport("libftdi1")]
    internal static extern int ftdi_eeprom_build(ref ftdi_eeprom eeprom, ref byte[] output);

    [DllImport("libftdi1")]
    internal static extern void ftdi_eeprom_initdefaults(out ftdi_eeprom eeprom);

    int vendor_id;
    int product_id;

    int self_powered;
    int remote_wakeup;
    int BM_type_chip;

    int in_is_isochronous;
    int out_is_isochronous;
    int suspend_pull_downs;

    int use_serial;
    int change_usb_version;
    int usb_version;
    int max_power;

    string manufacturer;
    string product;

    string serial;

    /* EEPROM size in bytes. This doesn't get stored in the EEPROM
    but is the only way to pass it to ftdi_eeprom_build. */
    int size; // coolnumber9, 03/01/10
};