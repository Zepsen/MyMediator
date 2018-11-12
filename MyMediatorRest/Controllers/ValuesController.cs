using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Users.Commands;
using Application.Users.Queries;
using DAL.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyMediatorRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ValuesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await Mediator.Send(new UserQuery());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return "asd";
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] UserCreateCommand userCreateCommand)
        {
            await Mediator.Send(userCreateCommand);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
