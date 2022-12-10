using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Logistician : User
    {
        public Logistician(int UID1, string Email1, int StorageID1)
           : base(UID1, Email1, nameof(Logistician), StorageID1)
        {
        }
    }
}



