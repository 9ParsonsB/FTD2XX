using System;

namespace FTD2XX.Enums;

/// <summary>
/// Flags for FT_OpenEx
/// </summary>
[Flags]
public enum FT_OPEN_EX_FLAGS
{
    FT_OPEN_BY_SERIAL_NUMBER = 0x00000001,
    FT_OPEN_BY_DESCRIPTION = 0x00000002,
    FT_OPEN_BY_LOCATION = 0x00000004
}