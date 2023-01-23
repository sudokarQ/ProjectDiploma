using DiplomaProject.Backend.Common.Models.Dto.Shop;
using DiplomaProject.Backend.Common.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopService
    {
        Task<Shop> GetAsync();
        void CreateAsync(ShopPostDto shop);
    }
}
