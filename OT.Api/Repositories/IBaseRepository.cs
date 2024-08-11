namespace OT.Api.Repositories
{
    public interface IBaseRepository
    {
        Task<bool> ExistsAsync(int id);
    }
}
