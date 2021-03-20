using System;

namespace APITreiber.DomainModel.Models
{
    public class Person : Entity
    {
        public string IdentityCard  { get; set; }
        public DateTime BirthDate { get; set; }
    }
}