namespace LibFtdiDotNet.Enums;

/// <summary>
///  Port interface code for FT2232C 
/// </summary>
public enum FtdiInterface : uint
{
    INTERFACE_ANY = 0,
    INTERFACE_A = 1,
    INTERFACE_B = 2,

    // + coolnumber9, 03/01/10
    INTERFACE_C = 3,

    INTERFACE_D = 4
    // - coolnumber9, 03/01/10
};