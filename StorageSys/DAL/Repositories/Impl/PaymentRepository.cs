using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Repositories.Impl
{
    internal class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        internal PaymentRepository(StorageContext context) : base(context)
        {
        }
    }
}