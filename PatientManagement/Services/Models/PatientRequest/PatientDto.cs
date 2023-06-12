using Core.Entities;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.PatientRequest
{
    public class PatientDto : IMapFrom<Patient>, IPatientRequest, IBaseId
    {
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
