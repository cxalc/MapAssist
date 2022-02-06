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

using GameOverlay.Drawing;
using MapAssist.Helpers;
using MapAssist.Interfaces;
using System;
using System.Linq;

namespace MapAssist.Types
{
    public class Room : IUpdatable<Room>
    {
        private Structs.Room _room;
        public IntPtr PtrRoom { get; set; } = IntPtr.Zero;
        public Point Position => new Point(X, Y);
        public uint X => _room.startX;
        public uint Y => _room.startY;
        public ushort[][] CollisionGrid { get; private set; } = new ushort[][] { };

        public Room(IntPtr pRoom)
        {
            PtrRoom = pRoom;
            Update();
        }

        public Room Update()
        {
            using (var processContext = GameManager.GetProcessContext())
            {
                _room = processContext.Read<Structs.Room>(PtrRoom);

                if (_room.pCollisionGrid != IntPtr.Zero)
                {
                    var grid = processContext.Read<Structs.CollisionGrid>(_room.pCollisionGrid);
                    var vals = processContext.Read<ushort>(grid.pCollisionMask, (int)(grid.subtilesWidth * grid.subtilesHeight));
                    CollisionGrid = Enumerable.Range(0, (int)grid.subtilesWidth).Select(x => Enumerable.Range(0, (int)grid.subtilesHeight).Select(y => vals[x * grid.subtilesHeight + y]).ToArray()).ToArray();
                }
            }

            return this;
        }

        public IntPtr[] RoomsNear
        {
            get
            {
                using (var processContext = GameManager.GetProcessContext())
                {
                    return processContext.Read<IntPtr>(_room.pRoomsNear, (int)Math.Min(NumRoomsNear, 9));
                }
            }
        }

        public override bool Equals(object obj) => obj is Room other && Equals(other);

        public bool Equals(Room room) => PtrRoom == room.PtrRoom;

        public override int GetHashCode() => PtrRoom.GetHashCode();

        public RoomEx RoomEx => new RoomEx(_room.pRoomEx);
        public uint NumRoomsNear => _room.numRoomsNear;
        public Act Act => new Act(_room.pAct);
        public Room RoomNext => new Room(_room.pRoomNext);
    }
}
