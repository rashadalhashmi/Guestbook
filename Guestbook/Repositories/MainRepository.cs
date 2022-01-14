using Guestbook.Data;
using Guestbook.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Guestbook.Repositories
{

    public class MainRepository<T> : IMainRepository<T> where T : BaseModel
    {
        Context Context;
        DbSet<T> Table;
        public MainRepository(Context context)
        {
            Context = context;
            Table = Context.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return Table;
        }
        public async Task<T> Get(int id)
        {
            return await Table.Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entity)
        {
            await Table.AddRangeAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> Update(IEnumerable<T> entity)
        {
            Table.UpdateRange(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            T entity = await Get(id);
            Table.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> Delete(IEnumerable<T> entity)
        {
            Table.RemoveRange(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task <IEnumerable<T>> FindMany(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().FirstOrDefault(expression);
        }
    }
}
