using ReceiptRewards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptRewards.Domain.Requests
{
    public class UpdatePresentRequest
    {
        public int PresentId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
