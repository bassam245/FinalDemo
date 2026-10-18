using FinalDemo.Models;

namespace FinalDemo.Repos.Interface
{
    public interface IOrderrepo:IGenericRepo<Order>
    {
        Task<decimal> TottallRenue();
        Task<Order> GetwithItemsTotallAmount(int id);
    }
}
