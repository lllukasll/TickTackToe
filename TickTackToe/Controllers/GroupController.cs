using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TickTackToe.Services.Interfaces;

namespace TickTackToe.Controllers
{
    [Route("Group")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var response = await _groupService.GetGroups();

            if (response.ErrorOccurred)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup()
        {
            var response = await _groupService.AddGroup();

            if (response.ErrorOccurred)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
