using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TickTackToe.Shared.BindingModels;
using TickTackToe.Shared.Dto;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            CreateMap<AddNoteBindingModel, Note>();
        }
    }
}
