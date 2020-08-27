using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalManager2.Domain.BaseArchitecture;
using SalManager2.Domain.Models;

namespace SalManager2.Domain.Models
{
    public class Membro : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Email { get; set; }
        public bool? isLiderPG { get; set; }
        public int? PGId { get; set; }
        public virtual PG PG { get; set; }
    }
}
