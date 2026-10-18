using FinalDemo.Data;
using FinalDemo.Migrations;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalDemo.Repos.Implemention
{
    public class ProudactRepo: GenericRepo<Product>, IProudactRepo
    {

        private readonly AppDbContextt appDbContextt1;
        public ProudactRepo(AppDbContextt appDbContextt) : base(appDbContextt)
        {
            appDbContextt1 = appDbContextt;
        }

        public  async Task<List<Product>> pignation(int? Id, int page, int pagesize, string Sortby)
        {
            if(Sortby=="Name")
            return await appDbContextt1.products.Where(s => s.Id == Id).OrderBy(s=>s.Name).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            else  if (Sortby == "Price")
                return await appDbContextt1.products.Where(s => s.Id == Id ).OrderBy(s => s.price).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
         
            return await appDbContextt1.products.Where(s => s.Id == Id).OrderBy(s => s.Id).Skip((page - 1) * pagesize).Take(page).ToListAsync();
        }

         public async Task<List<Product>> SerachByName(string name)
        {
            return await  appDbContextt1.products.Where(s => s.Name.Contains(name)).ToListAsync();
        }

        public async Task<Product> SocendMostexpensivproudact(int? id)
        {
            return await appDbContextt1.products.Where(s => s.categoryId != id).OrderByDescending(s => s.price).Skip(1).FirstOrDefaultAsync();
        }
    }
}
