﻿using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(long id, string[] includes);
        void Add(T model);
        void Update(T model);
        void Remove(long id);
        Task<int> SaveChangesAsync();
    }
}
