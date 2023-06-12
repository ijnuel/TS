using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public interface IBaseId
    {
        public Guid Id { get; set; }
    }
}
