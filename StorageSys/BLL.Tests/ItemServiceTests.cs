using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using User = CCL.Security.Identity.User;

namespace BLL.Tests
{
    public class ItemServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ItemService(nullUnitOfWork));
        }

        [Fact]
        public void GetStreets_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IItemService itemService = new ItemService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => itemService.GetItems(0));
        }

        [Fact]
        public void GetItems_ItemFromDAL_CorrectMappingToItemDTO()
        {
            // Arrange
            User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var itemService = GetItemService();

            // Act
            var actualItemDto = itemService.GetItems(0).First();

            // Assert
            Assert.True(
                actualItemDto.ItemID == 1
                && actualItemDto.OwnerID == 1
                && actualItemDto.SpaceTaken == 23.5f
                );
        }

        IItemService GetItemService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedItem = new Item() { ItemID = 1, OwnerID = 1, SpaceTaken = 23.5f, StorageID = 2};
            var mockDbSet = new Mock<IItemRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Item,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Item>() { expectedItem }
                    );
            mockContext
                .Setup(context =>
                    context.Items)
                .Returns(mockDbSet.Object);

            IItemService itemService = new ItemService(mockContext.Object);

            return itemService;
        }
    }
}
