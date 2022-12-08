using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStorageRepository Storages { get; }
        IItemRepository Items { get; }
        IUsersRepository Users { get; }
        IStoringFeeRepository StoringFees { get; }
        IApplicationRepository Applications { get; }
        IPaymentRepository Payments { get; }
        void Save();
    }
}

