using FinalDemo.Data;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;

namespace FinalDemo.Repos.Implemention
{
    public class UnitOffwork : IUnitOffWork
    {
       public  IGenericRepo<User> users { get; }
       public  IGenericRepo<Category> Catogryrepo { get; }
       public  IProudactRepo proudactRepo { get; }
        public IOrderrepo orderrepo { get; }
        private readonly AppDbContextt appDbContextt;

        public UnitOffwork(IGenericRepo<User> users, AppDbContextt appDbContextt, IGenericRepo<Category> catogryrepo, IProudactRepo proudactRepo, IOrderrepo orderrepo)
        {
            this.users = users;
            this.appDbContextt = appDbContextt;
            Catogryrepo = catogryrepo;
            this.proudactRepo = proudactRepo;
            this.orderrepo = orderrepo;
        }

        public int savechanges()
        {
            return appDbContextt.SaveChanges();
        }
    }
}
