namespace LibFtdiDotNet.Structs.LibUsb;

public partial class Device
{
    /// <inheritdoc/>
    protected override bool ReleaseHandle()
    {
        NativeMethods.UnrefDevice(this.handle);
        return true;
    }
}