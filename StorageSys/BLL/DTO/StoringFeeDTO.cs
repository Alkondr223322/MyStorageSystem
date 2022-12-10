using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class StoringFeeDTO
    {
        public int FeeID { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public float FeeValue { get; set; }
    }
}
