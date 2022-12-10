using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Remotion.Linq;

namespace DAL.Tests
{
    public class ItemRepositoryInMemoryDBTests
    {
        public StorageContext Context => SqlLiteInMemoryContext();

        private StorageContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<StorageContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new StorageContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputItemWithId0_SetItemId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IItemRepository repository = uow.Items;

            Item item = new Item()
            {
                ItemID = 5,
                StorageID = 1,
                SpaceTaken = 3.5f,
                ItemRow = 3,
                ItemCol = 8,
                OwnerID = 23,
                StoringFeeID = 2,
                BalanceValue = 200.28f,
                StoringFee = new StoringFee(),
                Payments = new List<Payment>(),
                Owner = new User() { UID = 0 },
                Storage = new Storage() { StorageID = 5, DirectorID = 0, Director = new User() { UID = 0} }
    };

            //Act
            repository.Create(item);
            uow.Save();
            var factListCount = context.Items.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistItemId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IItemRepository repository = uow.Items;
            Item item = new Item()
            {
                //ItemID = 5,
                StorageID = 1,
                SpaceTaken = 3.5f,
                ItemRow = 3,
                ItemCol = 8,
                OwnerID = 23,
                StoringFeeID = 2,
                BalanceValue = 200.28f,
                StoringFee = new StoringFee(),
                Payments = new List<Payment>(),
                Owner = new User() { UID = 0 },
                Storage = new Storage() { StorageID = 5, DirectorID = 0, Director = new User() { UID = 0 } }
            };
            context.Items.Add(item);
            context.SaveChanges();

            //Act
            repository.Delete(item.ItemID);
            uow.Save();
            var factStreetCount = context.Items.Count();

            // Assert
            Assert.Equal(expectedListCount, factStreetCount);
        }

        [Fact]
        public void Get_InputExistItemId_ReturnItem()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IItemRepository repository = uow.Items;
            Item expectedItem = new Item()
            {
                //ItemID = 5,
                StorageID = 1,
                SpaceTaken = 3.5f,
                ItemRow = 3,
                ItemCol = 8,
                OwnerID = 23,
                StoringFeeID = 2,
                BalanceValue = 200.28f,
                StoringFee = new StoringFee(),
                Payments = new List<Payment>(),
                Owner = new User() { UID = 0 },
                Storage = new Storage() { StorageID = 5, DirectorID = 0, Director = new User() { UID = 0 } }
            };
            context.Items.Add(expectedItem);
            context.SaveChanges();

            //Act
            var factItem = repository.Get(expectedItem.ItemID);

            // Assert
            Assert.Equal(expectedItem, factItem);
        }
    }
}
