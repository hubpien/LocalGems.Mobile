using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LocalGems.API.Models;
using System.Reflection.Metadata;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserLocation> UserLocation { get; set; } = default!;

public DbSet<LocalGems.API.Models.Post> Post { get; set; } = default!;

public DbSet<LocalGems.API.Models.SavePost> SavePost { get; set; } = default!;

public DbSet<LocalGems.API.Models.Like> Like { get; set; } = default!;

public DbSet<LocalGems.API.Models.JobOffer> JobOffer { get; set; } = default!;

public DbSet<LocalGems.API.Models.ProductOffer> ProductOffer { get; set; } = default!;

public DbSet<LocalGems.API.Models.ApplicationUser> ApplicationUser { get; set; } = default!;

}