using System.Threading.Tasks;
using APITreiber.DomainModel.Models;
using APITreiber.DTOs;

namespace APITreiber.Services.PersonService
{
    public interface IPersonService
    {
        Task<ResponseMessage<bool>>  InsertPersonAsync(Person model);
    }
}