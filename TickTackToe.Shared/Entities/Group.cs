using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe.Shared.Entities
{
    public class Group : Entity
    {
        public ICollection<Note> Notes { get; set; }
    }
}
