using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ApplicationDTO
    {
        public int AppID { get; set; }
        public String AppStatus { get; set; }
        public float SpaceTaken { get; set; }
        public int OwnerID { get; set; }
        public UserDTO Owner { get; set; }
    }
}
