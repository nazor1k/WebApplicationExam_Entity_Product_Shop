using Microsoft.EntityFrameworkCore;

namespace WebApplicationEXAM_N1.Context
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder mB)
        {
            base.OnModelCreating(mB);
            mB.Entity<Models.User>()
                .HasOne(x => x.UserData)
                .WithOne(x => x.User)
                .HasForeignKey<Models.User>(x=>x.UserDataId);

            

            mB.Entity<Models.UserToProduct>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserToProducts)
                .HasForeignKey(x => x.UserId)
                ;
            mB.Entity<Models.UserToProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.UserToProducts)
                .HasForeignKey(x => x.ProductId);

            mB.Entity<Models.User>()
                .Property(x => x.Role)
                .HasConversion<string>();

        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.UserData> UsersData { get; set; }
        public DbSet<Models.UserToProduct> UserToProducts { get; set; }

    }
   
}
