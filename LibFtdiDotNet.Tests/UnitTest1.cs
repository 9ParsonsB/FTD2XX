using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using Xunit;

namespace LibFtdiDotNet.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var ftdiContext = new FtdiContext();

        var devices = ftdiContext.GetDeviceList(0x0403, 0x6014);

        UsbDevice.OpenUsbDevice(registry => registry.Vid == 0x0403 && registry.Pid == 0x6014);
    }
}