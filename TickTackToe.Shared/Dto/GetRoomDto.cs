using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe.Shared.Dto
{
    public class GetRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Player1 { get; set; }
        public string Palyer2 { get; set; }
        public string RoomState { get; set; }
    }
}
