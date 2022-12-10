using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class User
    {
        public User(int UID1, string Email1, string UserType1, int StorageID1 = -1)
        {
            UID = UID1;
            StorageID = StorageID1;
            Email = Email1;
            UserType = UserType1;
        }
        public int UID { get; }
        public string Email { get; }
        public int StorageID { get; }
        protected string UserType { get; }
    }
}
