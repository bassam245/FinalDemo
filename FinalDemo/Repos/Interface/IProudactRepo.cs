using FinalDemo.Models;

namespace FinalDemo.Repos.Interface
{
    public interface IProudactRepo:IGenericRepo<Product>
    {
        Task<List<Product>> pignation(int? Id, int page, int pagesize, string Sortby);
        Task<Product> SocendMostexpensivproudact(int? id);

        Task<List<Product>> SerachByName(string name);
    }
}
