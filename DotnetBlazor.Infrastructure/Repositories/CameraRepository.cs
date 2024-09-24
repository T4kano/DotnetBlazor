using DotnetBlazor.Application.Interfaces;
using DotnetBlazor.Domain.Entities;
using DotnetBlazor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DotnetBlazor.Infrastructure.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        private readonly AppDbContext context;

        public CameraRepository(IDbContextFactory<AppDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        // Listar todas as câmeras
        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await context.Cameras.ToListAsync();
        }

        // Obter uma câmera pelo ID
        public async Task<Camera?> GetByIdAsync(int id)
        {
            return await context.Cameras.FindAsync(id);
        }

        // Adicionar uma nova câmera
        public async Task AddAsync(Camera camera)
        {
            await context.Cameras.AddAsync(camera);
            await context.SaveChangesAsync();
        }

        // Atualizar uma câmera existente
        public async Task UpdateAsync(Camera camera)
        {
            //context.Entry(camera).State = EntityState.Modified;
            context.Cameras.Update(camera);
            await context.SaveChangesAsync();
        }

        // Remover uma câmera pelo ID
        public async Task DeleteAsync(int id)
        {
            var camera = await GetByIdAsync(id);
            if (camera is not null)
            {
                context.Cameras.Remove(camera);
                await context.SaveChangesAsync();
            }
        }
    }
}
