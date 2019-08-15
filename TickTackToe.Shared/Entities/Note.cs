using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe.Shared.Entities
{
    public class Note : Entity
    {
        public string Content { get; set; }
        public Group Group { get; set; }
    }
}
