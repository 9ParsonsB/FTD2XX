using System;
using System.Runtime.InteropServices;

namespace LibFtdiDotNet.Structs.LibUsb;

internal static class NativeMethods
{

// #if WIN_X64 || WIN_X86 || NET45 || WIN7_X64 || WIN7_X86 // win7-x64, win7-x64 during testing only.
//         internal const string LibUsbNativeLibrary = "libusb-1.0.dll";
//         internal const CallingConvention LibUsbCallingConvention = CallingConvention.StdCall;
// #elif LINUX_X64 || LINUX_ARM64 || LINUX_ARM || UBUNTU || UBUNTU_16_04_X64 || UBUNTU_16_04_ARM64 // ubuntu during testing only.
    internal const string LibUsbNativeLibrary = "libusb-1.0.so.0";

    internal const CallingConvention LibUsbCallingConvention = CallingConvention.Cdecl;

// #elif OSX_X64 || OSX_10_12_X64 // osx during testing only
//         internal const string LibUsbNativeLibrary = "libusb-1.0.0.dylib";
//         internal const CallingConvention LibUsbCallingConvention = CallingConvention.Cdecl;
// #elif REFERENCE_ASSEMBLY
//         internal const string LibUsbNativeLibrary = "usb";
//         internal const CallingConvention LibUsbCallingConvention = CallingConvention.Cdecl;
// #endif
//         
    [DllImport(LibUsbNativeLibrary, CallingConvention = LibUsbCallingConvention, EntryPoint = "libusb_unref_device")]
    public static extern void UnrefDevice(IntPtr dev);

    [DllImport(LibUsbNativeLibrary, CallingConvention = LibUsbCallingConvention, EntryPoint = "libusb_close")]
    public static extern void Close(IntPtr devHandle);
}