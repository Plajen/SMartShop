using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;
using System;

namespace SMartShop.Infra.Seeding
{
	public static class AdminUserSeed
	{
		public static void SeedAdminUser(this ModelBuilder builder)
		{
            builder.Entity<User>().HasData(
                new User(1, "4dm1n", "xgjkJ0nYbmUFCyyp5DzKEQ==", Guid.NewGuid().ToString(), 1));

            builder.Entity<Address>().HasData(
                new Address(1, "Rua Floriano Peixoto", "123", "Casa", "Centro", "01016050", 5267, 0));

            builder.Entity<EmailAddress>().HasData(
                new EmailAddress(1, "email@email.com", 0));

            builder.Entity<Customer>().HasData(
                new Customer(1, "Super", "Admin", DateTime.Now, 1, 1, 1, 0));
        }
	}
}
