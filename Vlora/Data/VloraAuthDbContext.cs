using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vlora.Data
{
    public class VloraAuthDbContext : IdentityDbContext
    {
        public VloraAuthDbContext(
            DbContextOptions<VloraAuthDbContext> options
        ) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var UserRoleId = "b74ddd14-6340-4840-95c2-db12554843e5";
            var AdminRoleId = "caa2132b-c013-4520-892d-dccb2b3446a7";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = AdminRoleId,
                    ConcurrencyStamp = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    ConcurrencyStamp = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
}
}