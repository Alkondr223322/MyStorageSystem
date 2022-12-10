using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class StorageDTO
    {
        public int StorageID { get; set; }
        public int DirectorID { get; set; }
        public string Address { get; set; }
        public float FreeSpace { get; set; }

        public UserDTO Director { get; set; }
        public IEnumerable<ItemDTO> Items { get; set; }
        //public IEnumerable<StreetDTO> Streets { get; set; }
    }
}


