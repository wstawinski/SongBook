using System;

namespace SongBook.Domain.Enums
{
    [Flags]
    public enum ChordSchema : int
    {
        None = 0,

        /*----- Fret 1 -----*/
        F1Eh1 = 1 << 0,
        F1B = 1 << 1,
        F1G = 1 << 2,
        F1D = 1 << 3,
        F1A = 1 << 4,
        F1El = 1 << 5,

        /*----- Fret 2 -----*/
        F2Eh = 1 << 6,
        F2B = 1 << 7,
        F2G = 1 << 8,
        F2D = 1 << 9,
        F2A = 1 << 10,
        F2El = 1 << 11,

        /*----- Fret 3 -----*/
        F3Eh = 1 << 12,
        F3B = 1 << 13,
        F3G = 1 << 14,
        F3D = 1 << 15,
        F3A = 1 << 16,
        F3El = 1 << 17
    }
}
