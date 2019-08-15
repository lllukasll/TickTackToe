using System;
using System.Collections.Generic;
using System.Text;
using TickTackToe.Shared.Enums;

namespace TickTackToe.Shared.Entities
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public string Player1 { get; set; }
        public string Palyer2 { get; set; }
        public RoomState RoomState { get; set; }
    }
}
