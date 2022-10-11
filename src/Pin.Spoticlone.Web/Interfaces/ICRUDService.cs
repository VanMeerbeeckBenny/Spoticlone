using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface ICRUDService<T> where T : BaseEntitie
    {
        Task<ItemResultModel<T>> GetAllAsync();
        Task<ItemResultModel<T>> GetById(int id);
        Task Create(ItemResultModel<T> item);
        Task Update(ItemResultModel<T> item);
        Task Delete(Guid id);
    }
}
