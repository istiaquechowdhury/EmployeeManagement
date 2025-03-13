using EmployeeManagement.Web.Entities;
using EmployeeManagement.Web.Identity;
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




    }



    public DbSet<Employee> employees { get; set; }

    public DbSet<Leave> Leaves { get; set; }
}
