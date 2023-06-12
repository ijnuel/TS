using Core.Entities;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.PaymentRequest
{
    public class UpdatePaymentRequest : IMapFrom<Payment>, IPaymentRequest, IBaseId
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid PatientId { get; set; }
    }
}
