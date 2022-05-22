using System;

namespace FTD2XX.Enums;

/// <summary>
/// Shifting commands IN MPSSE Mode
/// </summary>
[Flags]
enum MPSSEShiftCmds
{
    /// <summary>
    /// Write TDI/DO on negative TCK/SK edge
    /// </summary>
    MPSSE_WRITE_NEG = 0x01,

    /// <summary>
    /// Write bits, not bytes 
    /// </summary>
    MPSSE_BITMODE = 0x02,

    /// <summary>
    /// Sample TDO/DI on negative TCK/SK edge 
    /// </summary>
    MPSSE_READ_NEG = 0x04,

    /// <summary>
    /// LSB first
    /// </summary>
    MPSSE_LSB = 0x08,

    /// <summary>
    /// Write TDI/DO
    /// </summary>
    MPSSE_DO_WRITE = 0x10,

    /// <summary>
    /// Read TDO/DI
    /// </summary>
    MPSSE_DO_READ = 0x20,

    /// <summary>
    /// Write TMS/CS 
    /// </summary>
    MPSSE_WRITE_TMS = 0x40
};