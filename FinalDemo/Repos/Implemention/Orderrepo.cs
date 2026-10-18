using FinalDemo.Data;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalDemo.Repos.Implemention
{
    public class Orderrepo : GenericRepo<Order>, IOrderrepo
    {
        private readonly AppDbContextt appDbContextt1;

        public Orderrepo(AppDbContextt appDbContextt) : base(appDbContextt)
        {
            this.appDbContextt1 = appDbContextt;
        }


        public async Task<Order> GetwithItemsTotallAmount(int id)
        {
            var order = await appDbContextt1.orders
         .Include(o => o.items)
         .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
                return null;

            order.TotallAmount = order.items.Sum(s => s.unitprice * s.quantity);

            return order;

        }

         public async Task<decimal> TottallRenue()
        {
            var  order = await  appDbContextt1.orders.Where(s => s.Status == "Completed").SumAsync(s=>s.TotallAmount);
            return order;
        }
    }
}
