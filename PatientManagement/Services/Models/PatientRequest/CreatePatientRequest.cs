using Core.Entities;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.PatientRequest
{
    public class CreatePatientRequest : IMapFrom<Patient>, IPatientRequest
    {
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
