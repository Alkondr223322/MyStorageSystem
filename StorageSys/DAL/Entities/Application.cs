using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Application
    {
        [Key]
        public int AppID { get; set; }
        public String AppStatus { get; set; }
        public float SpaceTaken { get; set; }
        public int OwnerID { get; set; }
        public User Owner { get; set; }

    }
}
