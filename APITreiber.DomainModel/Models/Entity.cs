using System;
using System.ComponentModel.DataAnnotations;

namespace APITreiber.DomainModel.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}