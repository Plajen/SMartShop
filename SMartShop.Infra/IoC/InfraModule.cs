using SMartShop.Infra.CrossCutting.Infrastructure;
using SMartShop.Infra.CrossCutting.Infrastructure.Interfaces;
using SMartShop.Infra.Interfaces;
using SMartShop.Infra.Repositories;
using System;
using System.Collections.Generic;

namespace SMartShop.Infra.IoC
{
    public static class InfraModule
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                { typeof(IAddressRepository), typeof(AddressRepository) },
                { typeof(ICustomerRepository), typeof(CustomerRepository) },
                { typeof(IProductRepository), typeof(ProductRepository) },
                { typeof(IShoppingCartRepository), typeof(ShoppingCartRepository) },
                { typeof(IUserRepository), typeof(UserRepository) },
                { typeof(ICrypto), typeof(Crypto) },
            };

            return result;
        }
    }
}
