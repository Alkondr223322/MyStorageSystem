using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestItemRepository
        : BaseRepository<Item>
    {
        public TestItemRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputItemInstance_CalledAddMethodOfDBSetWithItemInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Item>>();
            mockContext
                .Setup(context => 
                    context.Set<Item>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestItemRepository(mockContext.Object);

            Item expectedItem = new Mock<Item>().Object;

            //Act
            repository.Create(expectedItem);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedItem
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Item>>();
            mockContext
                .Setup(context =>
                    context.Set<Item>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IItemRepository repository = uow.Items;
            var repository = new TestItemRepository(mockContext.Object);

            Item expectedItem = new Item() { ItemID = 1};
            mockDbSet.Setup(mock => mock.Find(expectedItem.ItemID)).Returns(expectedItem);

            //Act
            repository.Delete(expectedItem.ItemID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedItem.ItemID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedItem
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Item>>();
            mockContext
                .Setup(context =>
                    context.Set<Item>(
                        ))
                .Returns(mockDbSet.Object);

            Item expectedItem = new Item() { ItemID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedItem.ItemID))
                    .Returns(expectedItem);
            var repository = new TestItemRepository(mockContext.Object);

            //Act
            var actualItem = repository.Get(expectedItem.ItemID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedItem.ItemID
                    ), Times.Once());
            Assert.Equal(expectedItem, actualItem);
        }

      
    }
}
