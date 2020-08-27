using SalManager2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.ViewModels
{
    public class MembroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Email { get; set; }
        public List<PG> PGs { get; set; }
    }
}
