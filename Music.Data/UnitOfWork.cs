using Music.Core;
using Music.Core.Repositories;
using Music.Data.Repositories;
using System.Threading.Tasks;

namespace Music.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicDbContext _context;
        private SongRepository _songRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(MusicDbContext context)
        {
            _context = context;            
        }

        public ISongRepository Songs => _songRepository ??= new SongRepository (_context);
        public IArtistRepository Artists => _artistRepository ??= new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
