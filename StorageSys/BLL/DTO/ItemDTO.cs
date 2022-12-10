using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ItemDTO
    {
        public int ItemID { get; set; }
        public int StorageID { get; set; }
        public float SpaceTaken { get; set; }
        public int ItemRow { get; set; }
        public int ItemCol { get; set; }
        public int OwnerID { get; set; }
        public int StoringFeeID { get; set; }
        public float BalanceValue { get; set; }
        //public StoringFeeDTO StoringFee { get; set; }
        //public IEnumerable<PaymentDTO> Payments { get; set; }
        //public StorageDTO Storage { get; set; }
        //public UserDTO Owner { get; set; }
    }
}
