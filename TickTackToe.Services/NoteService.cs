using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TickTackToe.Data.Repository.Interface;
using TickTackToe.Services.Interfaces;
using TickTackToe.Shared.BindingModels;
using TickTackToe.Shared.Dto.Common;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public NoteService(IRepository<Note> noteRepository, IGroupService groupService, IMapper mapper, IRepository<Group> groupRepository)
        {
            _noteRepository = noteRepository;
            _groupService = groupService;
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        public async Task<Response> AddNote(AddNoteBindingModel addNoteBindingModel)
        {
            var response = new Response();

            var addGroupResult = await _groupService.AddGroup();
            if (addGroupResult.ErrorOccurred)
            {
                response.Errors = addGroupResult.Errors;
                return response;
            }

            var noteModel = _mapper.Map<Note>(addNoteBindingModel);
            //var tmpGroupModel = (Group)addGroupResult.Data;
            noteModel.Group = new Group();

            var addNoteResult = await _noteRepository.AddAsync(noteModel);
            if (addNoteResult == null)
            {
                response.AddError("Note", "An error occurred while trying to add note");
                return response;
            }

            return response;
        }

        public async Task<Response> AddNoteToGroup(AddNoteToGroupBindingModel addNoteToGroupBindingModel)
        {
            var response = new Response();

            var groupExists = await _groupRepository.ExistAsync(x => x.Id == addNoteToGroupBindingModel.GroupId);
            if (!groupExists)
            {
                response.AddError("Group", "Group with given id don't exists");
                return response;
            }

            var noteModel = new Note();
            noteModel.Group.Id = addNoteToGroupBindingModel.GroupId;
            noteModel.Content = addNoteToGroupBindingModel.Content;

            var addNoteToGroupResponse = await _noteRepository.AddAsync(noteModel);
            if (addNoteToGroupResponse == null)
            {
                response.AddError("Note", "An error occurred while trying to add note to a group");
                return response;
            }

            return response;
        }
    }
}
