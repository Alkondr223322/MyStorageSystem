using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Accountant
        : User
    {
        public Accountant(int UID1, string Email1, int StorageID1)
            : base(UID1, Email1, nameof(Accountant), StorageID1)
        {
        }
    }
}
