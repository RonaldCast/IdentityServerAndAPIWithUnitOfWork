using System.Threading.Tasks;
using APITreiber.DomainModel.Models;
using APITreiber.DTOs;
using APITreiber.Persistence.UnitOfWork.Contracts;
using Microsoft.Extensions.Logging;

namespace APITreiber.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly  ILogger<PersonService> _logger;
        private readonly IUnitOfWork _uow;

        public PersonService(IUnitOfWork uow, ILogger<PersonService> logger)
        {
            _logger = logger;
            _uow = uow;
        }

        public async  Task<ResponseMessage<bool>> InsertPersonAsync(Person model)
        { 
            await _uow.Persons.AddAsync(model);

            var save = await _uow.SaveAsync();
            
            return save == 1 ? new ResponseMessage<bool>(){Message = "Se ha registrado correctamente", Response = true} 
                : new ResponseMessage<bool>(){Message = "Error al momento re registrar", Response = false};

            ;
        }
    }
}