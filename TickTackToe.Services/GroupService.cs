using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TickTackToe.Data.Repository.Interface;
using TickTackToe.Services.Interfaces;
using TickTackToe.Shared.Dto.Common;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IRepository<Group> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<Response> GetGroups()
        {
            var response = new Response();

            var groups = await _groupRepository.GetAllAsync(false, x => x.Notes);

            response.Data = groups;

            return response;
        }

        public async Task<Response> AddGroup()
        {
            var response = new Response();

            var result = await _groupRepository.AddAsync(new Group());

            if (result == null)
            {
                response.AddError("Group", "An error occurred while trying to add new note group");
                return response;
            }

            response.Data = result;

            return response;
        }
    }
}
