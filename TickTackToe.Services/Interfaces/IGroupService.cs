using System.Threading.Tasks;
using TickTackToe.Shared.Dto.Common;

namespace TickTackToe.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Response> GetGroups();
        Task<Response> AddGroup();
    }
}