using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int UID { get; set; }
        public int StorageID { get; set; }
        public String Email { get; set; }
        public String UserType { get; set; }

        public IEnumerable<ItemDTO> Items { get; set; }
        public IEnumerable<ApplicationDTO> Applications { get; set; }

        public StorageDTO Storage { get; set; }
    }
}
