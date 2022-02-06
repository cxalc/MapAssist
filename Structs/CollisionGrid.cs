/**
 *   Copyright (C) 2021 okaygo
 *
 *   https://github.com/misterokaygo/MapAssist/
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 **/

using System;
using System.Runtime.InteropServices;

namespace MapAssist.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct CollisionGrid
    {
        [FieldOffset(0x0)] public uint subtilesLeft;
        [FieldOffset(0x4)] public uint subtilesTop;
        [FieldOffset(0x8)] public uint subtilesWidth;
        [FieldOffset(0xC)] public uint subtilesHeight;
        [FieldOffset(0x10)] public uint tilesLeft;
        [FieldOffset(0x14)] public uint tilesTop;
        [FieldOffset(0x18)] public uint tilesWidth;
        [FieldOffset(0x1C)] public uint tilesHeight;
        [FieldOffset(0x20)] public IntPtr pCollisionMask;
    }
}
