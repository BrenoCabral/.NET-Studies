using SalManager2.Domain.Models;
using SalManager2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.ViewModels
{
    public class PGViewModel
    {
        public int Id { get; set; }
        public List<Membro> Membros { get; set; }
    }
}
