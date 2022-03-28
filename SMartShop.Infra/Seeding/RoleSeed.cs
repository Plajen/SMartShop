using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Seeding
{
	public static class RoleSeed
	{
		public static void SeedRole(this ModelBuilder builder)
		{
			builder.Entity<Role>().HasData(
				new Role(1, "Admin", "ADMIN"),
				new Role(2, "Customer", "CUSTOMER"));
		}
	}
}
