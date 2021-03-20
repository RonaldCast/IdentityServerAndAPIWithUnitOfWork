using System.Threading.Tasks;
using APITreiber.DomainModel.Models;
using APITreiber.DTOs;
using APITreiber.DTOs.PersonDTOs;
using APITreiber.Services.PersonService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITreiber.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ResponseMessage<bool>>> Post(PersonDTO model)
        {
            
            var moderMapper = _mapper.Map<PersonDTO, Person>(model);
            var resp = await _personService.InsertPersonAsync(moderMapper);

            if (!resp.Response)
                return BadRequest(resp);
            
            return Ok(resp);
        }
    }
}