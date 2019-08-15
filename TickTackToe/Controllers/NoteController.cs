using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TickTackToe.Services.Interfaces;
using TickTackToe.Shared.BindingModels;

namespace TickTackToe.Controllers
{
    [Route("Note")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNote(AddNoteBindingModel addNoteBindingModel)
        {
            var response = await _noteService.AddNote(addNoteBindingModel);

            if (response.ErrorOccurred)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("AddToGroup")]
        public async Task<IActionResult> AddNoteToGroup(AddNoteToGroupBindingModel addNoteToGroupBindingModel)
        {
            var response = await _noteService.AddNoteToGroup(addNoteToGroupBindingModel);

            if (response.ErrorOccurred)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
