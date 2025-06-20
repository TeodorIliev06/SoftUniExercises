namespace Horizons.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using Horizons.Data;
    using Horizons.Web.ViewModels.Terrain;
    using Horizons.Services.Core.Contracts;

    public class TerrainService(
        ApplicationDbContext dbContext) : ITerrainService
    {
        public async Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync()
        {
            var allTerrains = await dbContext.Terrains
                .AsNoTracking()
                .Select(t => new TerrainViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return allTerrains;
        }
    }
}
