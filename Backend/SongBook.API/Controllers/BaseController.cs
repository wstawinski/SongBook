using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongBook.API.Controllers
{
    [ApiController]
    public abstract class BaseController<T,M> : ControllerBase where T : BaseModel where M : IBaseManager<T>
    {
        protected readonly M Manager;

        public BaseController(M manager)
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
        public virtual async Task<ActionResult<T>> Remove(long id)
        {
            return await Manager.Remove(id);
        }
    }
}