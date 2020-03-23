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

            return Ok(results.ToList());
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> Get(long id)
        {
            var result = await Manager.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Add([FromBody]T model)
        {
            var result = await Manager.Add(model);

            return Ok(result);
        }

        [HttpPut]
        public virtual async Task<ActionResult<T>> Update([FromBody]T model)
        {
            var result = await Manager.Update(model);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Remove(long id)
        {
            await Manager.Remove(id);

            return Ok();
        }
    }
}