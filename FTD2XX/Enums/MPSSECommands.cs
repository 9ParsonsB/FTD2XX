namespace FTD2XX.Enums;

/// <summary>
/// FTDI MPSSE commands
/// </summary>
enum MPSSECommands
{
    SET_BITS_LOW = 0x80,

    /*BYTE DATA*/
    /*BYTE Direction*/
    SET_BITS_HIGH = 0x82,

    /*BYTE DATA*/
    /*BYTE Direction*/
    GET_BITS_LOW = 0x81,
    GET_BITS_HIGH = 0x83,
    LOOPBACK_START = 0x84,
    LOOPBACK_END = 0x85,
    TCK_DIVISOR = 0x86,
    /* Value Low */
    /* Value HIGH */ /*rate is 12000000/((1+value)*2) */
    // #define DIV_VALUE(rate) (rate > 6000000)?0:((6000000/rate -1) > 0xffff)? 0xffff: (6000000/rate -1)		

    /* Commands in MPSSE and Host Emulation Mode */
    SEND_IMMEDIATE = 0x87,
    WAIT_ON_HIGH = 0x88,
    WAIT_ON_LOW = 0x89,


    /* Commands in Host Emulation Mode */
    READ_SHORT = 0x90,

    /* Address_Low */
    READ_EXTENDED = 0x91,

    /* Address High */
    /* Address Low  */
    WRITE_SHORT = 0x92,

    /* Address_Low */
    WRITE_EXTENDED = 0x93,
    /* Address High */
    /* Address Low  */
};