using FinalDemo.Migrations;

namespace FinalDemo.Repos.Interface
{
    public interface IGenericRepo<T> where T:class
    {
        Task Add(T entity);
        Task<T> GetbyId(int id);
        Task<List<T>> GetAll();

        void Delete(T entity);

        void Update(T entity);

    }
}
