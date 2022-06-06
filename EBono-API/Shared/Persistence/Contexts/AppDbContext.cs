using EBono_API.Accounts.Domain.Models;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Results.Domain.Models;
using EBono_API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EBono_API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        //public DbSet<Bond> Bonds { get; set; }
        //public DbSet<Result> Results { get; set; }
        private readonly IConfiguration _configuration;

        // TODO: implementar creacion de entidades, datos y relaciones de las clases
        public AppDbContext(DbContextOptions options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Accounts
            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(p => p.Id);
            builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Account>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Account>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            builder.Entity<Account>().Property(p => p.CreatedAt).IsRequired();

            builder.Entity<Account>()
                .HasMany(p => p.Bonds)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId);

            builder.Entity<Account>().HasData(
                new Account {Id = 1, Name = "Marcelo", Email = "marc.203@gmail.com", Password = "Pld201", CreatedAt = "12-10-2018"},
                new Account {Id = 2, Name = "Diana", Email = "dian_nn4@outlook.com", Password = "133qw", CreatedAt = "12-09-2014"},
                new Account {Id = 3, Name = "Juan", Email = "jn.30@gmail.com", Password = "1a2b3c", CreatedAt = "24-01-2020"}
            );
            
            // Bonds
            /*
            builder.Entity<Bond>().ToTable("Bonds");
            builder.Entity<Bond>().HasKey(p => p.Id);
            builder.Entity<Bond>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bond>().Property(p => p.BondName).IsRequired().HasMaxLength(30);
            builder.Entity<Bond>().Property(p => p.CurrencyType).IsRequired();
            builder.Entity<Bond>().Property(p => p.NominalValue).IsRequired();
            builder.Entity<Bond>().Property(p => p.Rate).IsRequired();
            builder.Entity<Bond>().Property(p => p.RateType).IsRequired();
            builder.Entity<Bond>().Property(p => p.ExpirationType).IsRequired();
            builder.Entity<Bond>().Property(p => p.CreatedAt).IsRequired();
            */
            
            

            // Results


            builder.UseSnakeCaseNamingConvention();
        }
    }
}