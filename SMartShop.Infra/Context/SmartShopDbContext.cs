using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;
using SMartShop.Infra.Mappings;
using SMartShop.Infra.Seeding;

namespace SMartShop.Infra.Context
{
    public class SmartShopDbContext : DbContext
    {
        public SmartShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMap());
            builder.ApplyConfiguration(new CityMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new EmailAddressMap());
            builder.ApplyConfiguration(new ItemMap());
            builder.ApplyConfiguration(new PhoneNumberMap());
            builder.ApplyConfiguration(new PhotoMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new RefreshTokenMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new ShoppingCartMap());
            builder.ApplyConfiguration(new StateMap());
            builder.ApplyConfiguration(new UserMap());

            builder.SeedState();
            builder.SeedCity();
            builder.SeedProduct();
            builder.SeedRole();
            builder.SeedAdminUser();
        }
    }
}
