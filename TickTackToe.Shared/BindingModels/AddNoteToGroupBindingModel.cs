using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe.Shared.BindingModels
{
    public class AddNoteToGroupBindingModel
    {
        public string Content { get; set; }
        public int GroupId { get; set; }
    }
}
