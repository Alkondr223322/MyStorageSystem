using DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class Storage
    {
        [Key]
        public int StorageID { get; set; }
        public int DirectorID { get; set; }
        public string Address { get; set; }
        public float FreeSpace { get; set; }

        public User Director { get; set; }
        public List<Item> Items { get; set; }
    }
}
