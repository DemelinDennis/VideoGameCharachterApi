using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Services
{
    public interface ICharachterService
    {
        Task<List<Charachter>> GetCharachtersAsync();
        Task<Charachter?> GetCharachterByIdAsync(int id);
        Task<Charachter> AddCharachterAsync(Charachter charachter);
        Task<bool> UpdateCharachterAsync(int id, Charachter characher);
        Task<bool> DeleteCharachterAsync(int id);
    }
}
