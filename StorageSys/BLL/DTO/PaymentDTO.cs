using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public float PaymentValue { get; set; }
        public int ItemID { get; set; }
        public ItemDTO Item { get; set; }
    }
}
