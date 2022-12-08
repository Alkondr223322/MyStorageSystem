using Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public float PaymentValue { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }

    }
}
