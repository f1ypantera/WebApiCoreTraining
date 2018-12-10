using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreTraining.Models;


namespace WebApiCoreTraining.Models
{
    public class Repository<T>: IRepository<T> where T:class
    {
        private readonly DbSet<T> dbSet;
        private readonly PeopleContext peopleContext;

        public Repository(PeopleContext peopleContext)
        {
            dbSet = peopleContext.Set<T>();
            this.peopleContext = peopleContext;
        }       
        public async Task<T> GetAsync(int id)
        {
            var  result =  await dbSet.FindAsync(id);
            return result;           
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public async Task AddAsync(T entity)
        {
            
            await dbSet.AddAsync(entity);
            await peopleContext.SaveChangesAsync() ;
        }
        public async Task RemoveAsync(int id)
        {
            var result = await dbSet.FindAsync(id);
            if (result != null)
            {
                 dbSet.Remove(result);
                 await peopleContext.SaveChangesAsync();
            }          
        }
    }
}
