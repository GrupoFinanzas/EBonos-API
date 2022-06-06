using System.Threading.Tasks;

namespace EBono_API.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}