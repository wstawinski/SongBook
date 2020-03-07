using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces.Base;
using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Linq;
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
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var results = await Manager.GetAllAsync();

            return results.ToList();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> Get(long id)
        {
            return await Manager.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Add([FromBody]T model)
        {
            return await Manager.Add(model);
        }

        [HttpPut]
        public virtual async Task<ActionResult<T>> Update([FromBody]T model)
        {
            return await Manager.Update(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task Remove(long id)
        {
            await Manager.Remove(id);
        }
    }
}