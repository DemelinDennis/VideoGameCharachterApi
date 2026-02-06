using VideoGameCharachterApi.DTO;
using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Services
{
    public interface ICharachterService
    {
        Task<List<CharachterResponse>> GetCharachtersAsync();
        Task<CharachterResponse?> GetCharachterByIdAsync(int id);
        Task<CharachterResponse> AddCharachterAsync(CreateCharachterRequest charachter);
        Task<bool> UpdateCharachterAsync(int id, UpdateCharachterRequest characher);
        Task<bool> DeleteCharachterAsync(int id);
    }
}
