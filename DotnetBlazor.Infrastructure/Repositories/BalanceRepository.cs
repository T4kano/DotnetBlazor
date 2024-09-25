using DotnetBlazor.Application.Interfaces;
using DotnetBlazor.Domain.Entities;
using DotnetBlazor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DotnetBlazor.Infrastructure.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly AppDbContext context;

        public BalanceRepository(IDbContextFactory<AppDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        // Listar todas as balanças
        public async Task<IEnumerable<Balance>> GetAllAsync()
        {
            return await context.Balances.Include(b => b.Cameras).ToListAsync(); // Inclui as câmeras vinculadas
        }

        // Obter uma balança pelo ID
        public async Task<Balance?> GetByIdAsync(int id)
        {
            return await context.Balances.Include(b => b.Cameras)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Adicionar uma nova balança
        public async Task AddAsync(Balance balance)
        {
            await context.Balances.AddAsync(balance);
            await context.SaveChangesAsync();
        }

        // Atualizar uma balança existente
        public async Task UpdateAsync(Balance balance)
        {
            context.Balances.Update(balance);
            await context.SaveChangesAsync();
        }

        // Remover uma balança pelo ID
        public async Task DeleteAsync(int id)
        {
            var balance = await context.Balances.FindAsync(id);
            if (balance != null)
            {
                context.Balances.Remove(balance);
                await context.SaveChangesAsync();
            }
        }
    }
}
