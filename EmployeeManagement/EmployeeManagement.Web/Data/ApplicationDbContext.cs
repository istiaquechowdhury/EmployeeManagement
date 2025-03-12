using EmployeeManagement.Web.Areas.Employee.Entities;
using MeetingRoomBooking.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        // Seed roles for Admin, User, and Author
        builder.Entity<ApplicationRole>().HasData(
             new ApplicationRole
             {
                 Id = Guid.Parse("d0b85c3e-4f68-4a8c-9c92-7aabc1234567"), // Static GUID for Admin role
                 Name = "Admin",
                 NormalizedName = "ADMIN",
                 ConcurrencyStamp = Guid.NewGuid().ToString()
             }
            
        );

        builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = Guid.Parse("a0f85c3e-4f68-4a8c-9c92-7aabc1234567"), // Static GUID for the user
                    UserName = "admin", // UserName
                    NormalizedUserName = "ADMIN", // NormalizedUserName
                    Email = "admin@gmail.com", // Email
                    NormalizedEmail = "ADMIN@GMAIL.COM", // NormalizedEmail
                    EmailConfirmed = true, // EmailConfirmed
                    PhoneNumberConfirmed = false, // PhoneNumberConfirmed (set to false)
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123"), // PasswordHash
                    SecurityStamp = Guid.NewGuid().ToString(), // SecurityStamp
                    ConcurrencyStamp = Guid.NewGuid().ToString(), // ConcurrencyStamp
                    LockoutEnabled = false, // LockoutEnabled (optional, depending on your requirements)
                    TwoFactorEnabled = false // TwoFactorEnabled (optional, depending on your requirements)
                }
        );

        // builder.Entity<IdentityUserRole<Guid>>()
        //.HasKey(ur => new { ur.UserId, ur.RoleId });


        // builder.Entity<IdentityUserRole<Guid>>().HasData(
        //       new IdentityUserRole<Guid>
        //       {
        //           UserId = Guid.Parse("a0f85c3e-4f68-4a8c-9c92-7aabc1234567"), // Static GUID for the user
        //           RoleId = Guid.Parse("d0b85c3e-4f68-4a8c-9c92-7aabc1234567")  // Static GUID for Admin role
        //       }
        // );

        // builder.Entity<IdentityUserRole<Guid>>()
        //.HasOne<ApplicationUser>()
        //.WithMany()
        //.HasForeignKey(ur => ur.UserId)
        //.OnDelete(DeleteBehavior.Cascade);


    }



    public DbSet<Employee> employees { get; set; }  
}
