using Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int UID { get; set; }
        public int StorageID { get; set; }
        public String Email { get; set; }
        public String UserType { get; set; }

        public List<Item> Items { get; set; }
        public List<Application> Applications { get; set; }

        public Storage Storage { get; set; }
    }
}
