using Microsoft.EntityFrameworkCore;
using PhotoAlbumApp.Data;
using PhotoAlbumApp.Models;

namespace PhotoAlbumApp.Services
{
    public class PhotoService
    {
        private readonly ApplicationDbContext _context;

        public PhotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Photo>> GetAllPhotos(string sortBy, bool ascending)
        {
            var query = _context.Photos.AsQueryable();

            query = sortBy switch
            {
                "name" => ascending
                    ? query.OrderBy(p => p.Name)
                    : query.OrderByDescending(p => p.Name),

                "date" => ascending
                    ? query.OrderBy(p => p.UploadDate)
                    : query.OrderByDescending(p => p.UploadDate),

                _ => query.OrderByDescending(p => p.UploadDate)
            };

            return await query.ToListAsync();
        }

        public async Task<List<Photo>> GetPhotos(string userId, string sortBy)
        {
            var query = _context.Photos.Where(p => p.UserId == userId);

            query = sortBy switch
            {
                "name" => query.OrderBy(p => p.Name),
                "date" => query.OrderBy(p => p.UploadDate),
                _ => query.OrderByDescending(p => p.UploadDate)
            };

            return await query.ToListAsync();
        }

        public async Task AddPhoto(Photo photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }
    }
}