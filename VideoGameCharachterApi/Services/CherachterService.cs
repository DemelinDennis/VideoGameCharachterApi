using Microsoft.EntityFrameworkCore;
using VideoGameCharachterApi.Data;
using VideoGameCharachterApi.DTO;
using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Services
{
    public class CherachterService(AppDbContext context) : ICharachterService
    {

        static List<Charachter> charachters = new List<Charachter>() {
            new Charachter { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Protagonist" },
            new Charachter { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Protagonist" },
            new Charachter { Id = 3, Name = "Master Chief", Game = "Halo", Role = "Protagonist" }
        };

        public async Task<CharachterResponse> AddCharachterAsync(CreateCharachterRequest charachter)
        {
            var newCharachter = new Charachter
            {
                Name = charachter.Name,
                Game = charachter.Game,
                Role = charachter.Role
            };
            context.Charachters.Add(newCharachter);
            await context.SaveChangesAsync();

            return new CharachterResponse
            {
                Id = newCharachter.Id,
                Name = newCharachter.Name,
                Game = newCharachter.Game,
                Role = newCharachter.Role
            };
        }

        public Task<bool> DeleteCharachterAsync(int id)
        {
            var charachter = context.Charachters.Find(id);
            if (charachter != null)
            {
                context.Charachters.Remove(charachter);
                context.SaveChanges();
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }

        public async Task<CharachterResponse?> GetCharachterByIdAsync(int id)
        {

            var result = await context.Charachters
                .Where(c => c.Id == id)
                .Select(c => new CharachterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<CharachterResponse>> GetCharachtersAsync()
        {
            return await context.Charachters.Select(c => new CharachterResponse
            {
                    Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();
        }

        public async Task<bool> UpdateCharachterAsync(int id, UpdateCharachterRequest characher)
        {
            var existingCharachter = await context.Charachters.FindAsync(id);
            if (existingCharachter != null)
            {
                existingCharachter.Name = characher.Name;
                existingCharachter.Game = characher.Game;
                existingCharachter.Role = characher.Role;
                await context.SaveChangesAsync();
                return true;
            }
            else return false;

        }
    }
}
