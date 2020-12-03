using Music.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Music.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository Songs { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}
