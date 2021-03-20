using APITreiber.DomainModel;
using APITreiber.DomainModel.Models;
using APITreiber.Persistence.Repository.Contracts;

namespace APITreiber.Persistence.Repository
{
    public class PersonRepository : Repository<Person> ,IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
        
    }
}