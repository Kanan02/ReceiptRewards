using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptRewards.Domain.Entities
{
    public class AdditionalProperty : BaseEntity<int>
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
