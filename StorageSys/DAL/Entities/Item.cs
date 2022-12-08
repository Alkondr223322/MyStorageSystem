using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Catalog.DAL.Entities;
using DAL.Entities;

namespace Catalog.DAL.Entities
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public int StorageID { get; set; }
        public float SpaceTaken { get; set; }
        public int ItemRow { get; set; }
        public int ItemCol { get; set; }
        public int OwnerID { get; set; }
        public int StoringFeeID { get; set; }
        public float BalanceValue { get; set; }
        public StoringFee StoringFee { get; set; }
        public List<Payment> Payments { get; set; }
        public Storage Storage { get; set; }
        public User Owner { get; set; }
    }
}
