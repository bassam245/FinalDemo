using FinalDemo.Models;

namespace FinalDemo.Repos.Interface
{
    public interface IUnitOffWork
    {
        IGenericRepo<User> users { get; }
        IGenericRepo<Category>  Catogryrepo { get; }
        IOrderrepo orderrepo { get; }
        IProudactRepo proudactRepo { get; }
    

            int savechanges();
    }
}
