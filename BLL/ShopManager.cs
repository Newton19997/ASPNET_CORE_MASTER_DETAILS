using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class ShopManager:Manager<Shop>, IShopManager
    {
        private IShopRepository _shoprepository;
        public ShopManager(IShopRepository shoprepository) :base(shoprepository)
        {
            _shoprepository = shoprepository;
        }
    }
}
