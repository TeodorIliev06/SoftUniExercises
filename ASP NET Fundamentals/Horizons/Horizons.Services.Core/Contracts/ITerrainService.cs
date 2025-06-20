namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Terrain;

    public interface ITerrainService
    {
        Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync();
    }
}
