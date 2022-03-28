using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SMartShop.API.IoC
{
    public static class ApiModule
    {
        public static List<Type> GetSingleTypes()
        {
            var result = new List<Type>();

            // TO DO: add validators to each model class
            //result.Add(typeof(UserValidator));

            return result;
        }

        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                { typeof(IHttpContextAccessor), typeof(HttpContextAccessor) },
            };

            return result;
        }
    }
}
