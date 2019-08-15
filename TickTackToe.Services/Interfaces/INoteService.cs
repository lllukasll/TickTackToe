using System.Threading.Tasks;
using TickTackToe.Shared.BindingModels;
using TickTackToe.Shared.Dto.Common;

namespace TickTackToe.Services.Interfaces
{
    public interface INoteService
    {
        Task<Response> AddNote(AddNoteBindingModel addNoteBindingModel);
        Task<Response> AddNoteToGroup(AddNoteToGroupBindingModel addNoteToGroupBindingModel);
    }
}