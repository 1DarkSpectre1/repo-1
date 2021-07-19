using ASPdotNETcoreAPI.Response;
using businesslogic.Interface;
using datalayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETcoreAPI.Controllers
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly ILogger<PersonsController> _logger;

        private readonly IPersonsService _personsService;
        public PersonsController(ILogger<PersonsController> logger, IPersonsService personsService)
        {
            _logger = logger;
            _personsService = personsService;
        }
        [HttpGet()]
        public ResponsePersons Get()
        {
           
            return new ResponsePersons() { Id = 12, FirstName = "asd" };
        }

        [HttpGet("persons")]
        public async Task<IEnumerable<ResponsePersons>>  GetPersonById([FromRoute]int id)
        {
            var result = await _personsService.GetPersonById(id);
            return result.Select(r => new ResponsePersons() { Id = r.Id, FirstName = r.FirstName }).ToArray();
        }
        
        [HttpGet("persons/search")]
        public async Task<IEnumerable<ResponsePersons>> GetPersonByName([FromRoute] string name)
        {
            var result = await _personsService.GetPersonByName(name);
            return result.Select(r => new ResponsePersons() { Id = r.Id, FirstName = r.FirstName }).ToArray(); ;
        }
        [HttpPost("persons")]
        public IActionResult PostPerson([FromBody]Person person)
        {
            _personsService.PostPerson(person);
            return  Ok();
        }
        [HttpPut("persons")]
        public IActionResult PutPerson([FromBody] Person person)
        {
            _personsService.PutPerson(person);
            return Ok();
        }
        [HttpDelete("persons")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            _personsService.DeletePerson(id);
            return Ok();
        }
    }
}
