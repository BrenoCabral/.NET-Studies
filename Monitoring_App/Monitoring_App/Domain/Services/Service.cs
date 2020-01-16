using Monitoring_App.Domain.BaseArchitecture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public class Service : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeDescription { get; set; }
        public string VersionEndpoint { get; set; }
        public string CommunicationEndpoint { get; set; }
        public string Enviromment { get; set; }
        public string CompanyCell { get; set; }
        public string Cloud { get; set; }
    }
}
