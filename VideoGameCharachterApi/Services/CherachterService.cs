using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Services
{
    public class CherachterService : ICharachterService
    {
        static List<Charachter> charachters = new List<Charachter>() {
            new Charachter { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Protagonist" },
            new Charachter { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Protagonist" },
            new Charachter { Id = 3, Name = "Master Chief", Game = "Halo", Role = "Protagonist" }
        };

        public Task<Charachter> AddCharachterAsync(Charachter charachter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharachterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Charachter?> GetCharachterByIdAsync(int id)
        {
            var result = charachters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<List<Charachter>> GetCharachtersAsync()
        {
            return await Task.FromResult(charachters);
        }

        public Task<bool> UpdateCharachterAsync(int id, Charachter characher)
        {
            throw new NotImplementedException();
        }
    }
}
