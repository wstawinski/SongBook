using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces.Base;
using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.API.Controllers.Base
{
    [ApiController]
    public abstract class AppControllerBase<T> : ControllerBase where T : ModelBase
    {
        protected readonly IManager<T> Manager;

        public AppControllerBase(IManager<T> manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await Manager.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<T> Get(long id)
        {
            return await Manager.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual T Add([FromBody]T model)
        {
            return Manager.Add(model);
        }

        [HttpPut]
        public virtual T Update([FromBody]T model)
        {
            return Manager.Update(model);
        }

        [HttpDelete("{id}")]
        public virtual void Remove(long id)
        {
            Manager.Remove(id);
        }
    }
}