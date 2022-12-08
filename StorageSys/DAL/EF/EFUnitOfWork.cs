using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StorageContext db;
        private StorageRepository storageRepository;
        private ItemRepository itemRepository;
        private UserRepository userRepository;
        private StoringFeeRepository storingFeeRepository;
        private ApplicationRepository applicationRepository;
        private PaymentRepository paymentRepository;

        public EFUnitOfWork(StorageContext context)
        {
            db = context;
        }
        public IStorageRepository Storages
        {
            get
            {
                if (storageRepository == null)
                    storageRepository = new StorageRepository(db);
                return storageRepository;
            }
        }
        public IUsersRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IItemRepository Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }
        public IStoringFeeRepository StoringFees
        {
            get
            {
                if (storingFeeRepository == null)
                    storingFeeRepository = new StoringFeeRepository(db);
                return storingFeeRepository;
            }
        }
        public IApplicationRepository Applications
        {
            get
            {
                if (applicationRepository == null)
                    applicationRepository = new ApplicationRepository(db);
                return applicationRepository;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(db);
                return paymentRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
