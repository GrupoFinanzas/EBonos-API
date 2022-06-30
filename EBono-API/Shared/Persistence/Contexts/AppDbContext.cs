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
        public DbSet<Bond> Bonds { get; set; }
        public DbSet<Result> Results { get; set; }
        private readonly IConfiguration _configuration;
        
        public AppDbContext(DbContextOptions options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("EbonosDB"));
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
            builder.Entity<Account>().Property(p => p.CreatedAt);

            builder.Entity<Account>()
                .HasMany(p => p.Bonds)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId);

            builder.Entity<Account>().HasData(
                new Account {Id = 1, Name = "Marcelo", Email = "marc.203@gmail.com", Password = "Pld201", CreatedAt = "12/10/2021"},
                new Account {Id = 2, Name = "Diana", Email = "dian_nn4@outlook.com", Password = "133qw", CreatedAt = "12/09/2021"},
                new Account {Id = 3, Name = "Juan", Email = "jn.30@gmail.com", Password = "1a2b3c", CreatedAt = "24/01/2021"}
            );
            
            // Bonds
            builder.Entity<Bond>().ToTable("Bonds");
            builder.Entity<Bond>().HasKey(p => p.Id);
            builder.Entity<Bond>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bond>().Property(p => p.BondName).IsRequired().HasMaxLength(50);
            builder.Entity<Bond>().Property(p => p.CurrencyType);
            builder.Entity<Bond>().Property(p => p.NominalValue).IsRequired();
            builder.Entity<Bond>().Property(p => p.Rate).IsRequired();
            builder.Entity<Bond>().Property(p => p.RateType).IsRequired();
            builder.Entity<Bond>().Property(p => p.ExpireDate).IsRequired();
            builder.Entity<Bond>().Property(p => p.ExpirationType).IsRequired();
            builder.Entity<Bond>().Property(p => p.CreatedAt).IsRequired();

            builder.Entity<Bond>().HasData(
                new Bond { Id = 1, BondName = "Bond FoxHound", CurrencyType = ECurrencyType.Dollar, 
                    NominalValue = 2300, Rate = 10, RateType = ERateType.Monthly, ExpireDate = 2,
                    ExpirationType = EExpirationType.Years, CreatedAt = "02/01/2022", AccountId = 1 },
                new Bond { Id = 2, BondName = "Bond Maverick", CurrencyType = ECurrencyType.Sol, 
                    NominalValue = 400, Rate = 2, RateType = ERateType.FourMonthly, ExpireDate = 4,
                    ExpirationType = EExpirationType.Quarters, CreatedAt = "23/02/2022", AccountId = 1 },
                new Bond { Id = 3, BondName = "Bond AnyColor", CurrencyType = ECurrencyType.Dollar, 
                    NominalValue = 560, Rate = 12, RateType = ERateType.Annual, ExpireDate = 2,
                    ExpirationType = EExpirationType.Years, CreatedAt = "31/10/2021", AccountId = 2 },
                new Bond { Id = 4, BondName = "Bond Cover Corporation", CurrencyType = ECurrencyType.Dollar, 
                    NominalValue = 1250, Rate = 5, RateType = ERateType.Fortnightly, ExpireDate = 21,
                    ExpirationType = EExpirationType.Trimesters, CreatedAt = "08/05/2022", AccountId = 3 },
                new Bond { Id = 5, BondName = "Bond Coffin Company", CurrencyType = ECurrencyType.Sol, 
                    NominalValue = 3090, Rate = 2, RateType = ERateType.Semiannual, ExpireDate = 10,
                    ExpirationType = EExpirationType.Months, CreatedAt = "30/12/2022", AccountId = 3 },
                new Bond { Id = 6, BondName = "Bond Wangsheng Funeral Parlor", CurrencyType = ECurrencyType.Sol, 
                    NominalValue = 470, Rate = 5, RateType = ERateType.Monthly, ExpireDate = 5,
                    ExpirationType = EExpirationType.Months, CreatedAt = "11/11/2021", AccountId = 3 }
            );


            // Results
            builder.Entity<Result>().ToTable("Results");
            builder.Entity<Result>().HasKey(p => p.Id);
            builder.Entity<Result>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Result>().Property(p => p.Tir).IsRequired();
            builder.Entity<Result>().Property(p => p.TirType).IsRequired();
            builder.Entity<Result>().Property(p => p.BondValue).IsRequired();
            builder.Entity<Result>().Property(p => p.Van).IsRequired();
            builder.Entity<Result>().Property(p => p.Time).IsRequired();
            builder.Entity<Result>().Property(p => p.TimeType).IsRequired();
            builder.Entity<Result>().Property(p => p.Duration).IsRequired();
            builder.Entity<Result>().Property(p => p.ModDuration).IsRequired();
            builder.Entity<Result>().Property(p => p.Convexity).IsRequired();
            builder.Entity<Result>().Property(p => p.BondId);

            builder.Entity<Result>().HasData(
                new Result { Id = 1, Tir = 12.2323, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 1},
                new Result { Id = 2, Tir = 12.3425, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 2},
                new Result { Id = 3, Tir = 12.8392, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 3},
                new Result { Id = 4, Tir = 12.2938, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 4},
                new Result { Id = 5, Tir = 12.3812, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 5},
                new Result { Id = 6, Tir = 12.3918, TirType = ETirType.Annual, BondValue = 2390, Van = 12, Time = 3, 
                    TimeType = ETimeType.Months, Duration = 1, ModDuration = 1, Convexity = 1, BondId = 6}
            );

            builder.UseSnakeCaseNamingConvention();
        }
    }
}