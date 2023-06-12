using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Payments")]
    public class Payment : BaseEntity
    {
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid PatientId { get; set; }
    }
}