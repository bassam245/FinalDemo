using FinalDemo.Data;
using FinalDemo.Migrations;
using FinalDemo.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalDemo.Repos.Implemention
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContextt appDbContextt;
        public GenericRepo()
        {
        }

        public GenericRepo(AppDbContextt appDbContextt)
        {
            this.appDbContextt = appDbContextt;
        }

        public  async Task Add(T entity)
        {
            await appDbContextt.Set<T>().AddAsync(entity);
        }

        public  void Delete(T entity)
        {
             appDbContextt.Set<T>().Remove(entity);
        }

        public async  Task<List<T>> GetAll()
        {
           return  await appDbContextt.Set<T>().ToListAsync();
        }

        public async  Task<T> GetbyId(int id)
        {
            return await  appDbContextt.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            appDbContextt.Set<T>().Update(entity);
        }
    }
}
