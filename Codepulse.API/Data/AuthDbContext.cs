using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRollId = "4fc58355 - 2cff - 463b - 963a - bff3aa86a67a";
            var writerRollId = "2f2f6c9e - 1c20 - 4392 - a7b8 - a2bc0b792734";

            // create reader and writer role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRollId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper(),
                    ConcurrencyStamp = readerRollId

                },
                new IdentityRole()
                {
                    Id=writerRollId,
                    Name = "Writer",
                    NormalizedName= "Writer".ToUpper(),
                    ConcurrencyStamp=writerRollId
                }
            };
            // seed the values
            builder.Entity<IdentityRole>().HasData(roles);

            // create an admin user
            var adminUserId = "b62481ba-dbc1-499b-a938-5204c3322986";

            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepulse.com",
                Email = "admin@codepulse.com",
                NormalizedEmail = "admin@codepulse.com".ToUpper(),
                NormalizedUserName = "admin@codepulse.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);
            // Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                   UserId = adminUserId,
                   RoleId = readerRollId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRollId
                }


            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
