using DotnetBlazor.Domain.Entities;

namespace DotnetBlazor.Application.Interfaces
{
    public interface IBalanceRepository
    {
        Task<IEnumerable<Balance>> GetAllAsync();

        Task<Balance?> GetByIdAsync(int id);

        Task AddAsync(Balance balance);

        Task UpdateAsync(Balance balance);

        Task DeleteAsync(int id);
    }
}
