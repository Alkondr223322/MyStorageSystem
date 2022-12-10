using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;

namespace BLL.Services.Impl
{
    public class ItemService
        : IItemService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public ItemService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<ItemDTO> GetItems(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            var storageId = user.StorageID;
            var itemsEntities = 
                _database
                    .Items
                    .Find(z => z.StorageID == storageId, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Item, ItemDTO>()
                    ).CreateMapper();
            var itemsDto = 
                mapper
                    .Map<IEnumerable<Item>, List<ItemDTO>>(
                        itemsEntities);
            return itemsDto;
        }

        public void AddItem(ItemDTO item)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                || userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            validate(item);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, Item>()).CreateMapper();
            var itemEntity = mapper.Map<ItemDTO, Item>(item);
            _database.Items.Create(itemEntity);
        }

        private void validate(ItemDTO item)
        {
            if (item.OwnerID == -1)
            {
                throw new ArgumentException("Item must have an owner");
            }
        }
    }
}
