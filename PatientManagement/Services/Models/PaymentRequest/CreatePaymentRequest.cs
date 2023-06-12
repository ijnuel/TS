using Core.Entities;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.PaymentRequest
{
    public class CreatePaymentRequest : IMapFrom<Payment>, IPaymentRequest
    {
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid PatientId { get; set; }
    }
}
