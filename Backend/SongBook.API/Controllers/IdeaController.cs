using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Collections.Generic;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Idea")]
    public class IdeaController : BaseController<Idea, IIdeaManager>
    {
        public IdeaController(IIdeaManager manager) : base(manager)
        {
        }

        [HttpGet("GetEmpty")]
        public Idea GetEmpty()
        {
            return new Idea
            {
                IdeaTeamMembers = new List<IdeaTeamMember> 
                { 
                    new IdeaTeamMember()
                },
                Questions = new List<Question>
                {
                    new Question()
                }
            };
        }
    }
}
