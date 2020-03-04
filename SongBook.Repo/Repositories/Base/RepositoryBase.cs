﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Interfaces.Base;
using SongBook.Domain.Models.Base;

namespace SongBook.Repo.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : ModelBase
    {
        protected readonly DbContext DataContext;

        public RepositoryBase(DbContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public virtual T GetById(long id)
        {
            return DataContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await GetByIdAsync(id, null);
        }

        public virtual async Task<T> GetByIdAsync(long id, string[] includes)
        {
            var query = DataContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }

        public virtual T Add(T model)
        {
            DataContext.Set<T>().Add(model);

            return model;
        }

        public virtual T Update(T model)
        {
            DataContext.Set<T>().Update(model);

            return model;
        }

        public virtual void Remove(long id)
        {
            var model = GetById(id);

            if (model != null)
            {
                DataContext.Set<T>().Remove(model);
            }
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}
