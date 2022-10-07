using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface ICRUDService<T> where T : BaseEntitie
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}
