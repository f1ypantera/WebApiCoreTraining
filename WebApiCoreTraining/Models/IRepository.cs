using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreTraining.Models;
using WebApiCoreTraining.Services;

namespace WebApiCoreTraining.Models
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        Task RemoveAsync(int id);       
    }
}
