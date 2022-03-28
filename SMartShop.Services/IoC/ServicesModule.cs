using SMartShop.Services.Interfaces;
using SMartShop.Services.Services;
using System;
using System.Collections.Generic;

namespace SMartShop.Services.IoC
{
    public static class ServicesModule
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                { typeof(IAddressService), typeof(AddressService) },
                { typeof(IAuthService), typeof(AuthService) },
                { typeof(ICustomerService), typeof(CustomerService) },
                { typeof(IProductService), typeof(ProductService) },
                { typeof(IShoppingCartService), typeof(ShoppingCartService) },
                { typeof(IUserService), typeof(UserService) },
            };

            return result;
        }
    }
}
