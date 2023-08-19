namespace CatalogAPI.Services.InterfaceService
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
