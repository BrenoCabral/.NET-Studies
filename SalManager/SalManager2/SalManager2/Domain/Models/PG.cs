using SalManager2.Domain.BaseArchitecture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalManager2.Domain.Models
{
    public class PG : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DiaDaSemana { get; set; }
        public int? AnfitriaoId { get; set; }
        public virtual Membro Anfitriao { get; set; }
        public virtual List<Membro> Membros { get; set; }
    }
}
