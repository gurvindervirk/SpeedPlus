using System.Data.Entity;
using VegaModel;
namespace DataContext
{
    public class VegaContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyBook>()
            .HasRequired(c => c.CompanyModel)
            .WithMany(p => p.CompanyBooks)
            .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<CrateModel>()
            .HasRequired(c => c.CompanyModel)
            .WithMany(p => p.CrateModels)
            .HasForeignKey(c => c.CompanyId);

           modelBuilder.Entity<SecurityLoginsLogModel>()
          .HasRequired(c => c.SecurityLogin)
          .WithMany(p => p.SecurityLoginsLogs)
          .HasForeignKey(c => c.Login);

         modelBuilder.Entity<SecurityLoginsRoleModel>()
          .HasRequired(c => c.SecurityLogin)
         .WithMany(p => p.SecurityLoginsRoles)
        .HasForeignKey(c => c.Login);

         modelBuilder.Entity<SecurityLoginsRoleModel>()
         .HasRequired(c => c.SecurityRole)
         .WithMany(p => p.SecurityLoginsRoles)
          .HasForeignKey(c => c.Role);

            modelBuilder.Entity<AccountModel>()
                   .HasRequired(c => c.CityModel)
                   .WithMany(p => p.AccountModels)
                   .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<AccountModel>()
                      .HasRequired(c => c.StateModel)
                      .WithMany(p => p.AccountModels)
                      .HasForeignKey(c => c.StateId);

            modelBuilder.Entity<AccountModel>()
                  .HasRequired(c => c.CountryModel)
                  .WithMany(p => p.AccountModels)
                  .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<AccountModel>()
               .HasRequired(c => c.AreaModel)
               .WithMany(p => p.AccountModels)
               .HasForeignKey(c => c.AreaId);

            modelBuilder.Entity<AccountModel>()
              .HasRequired(c => c.CompanyModel)
              .WithMany(p => p.AccountModels)
              .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<AccountModel>()
            .HasRequired(c => c.AccountDescription)
            .WithMany(p => p.AccountModels)
            .HasForeignKey(c => c.AccountDescId);

            modelBuilder.Entity<AccountModel>()
           .HasRequired(c => c.SessionModel)
           .WithMany(p => p.AccountModels)
           .HasForeignKey(c => c.SessionId);

            modelBuilder.Entity<StateModel>()
              .HasRequired(c => c.CountryModel)
              .WithMany(p => p.StateModels)
              .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<CityModel>()
             .HasRequired(c => c.StateModel)
             .WithMany(p => p.CityModels)
             .HasForeignKey(c => c.StateId);

            modelBuilder.Entity<TransactionModel>()
            .HasRequired(c => c.AccountModel)
            .WithMany(p => p.TransactionModels)
            .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<TransactionModel>()
            .HasRequired(c => c.VoucherTypeModel)
            .WithMany(p => p.TransactionModels)
            .HasForeignKey(c => c.VoucherTypeId);

            modelBuilder.Entity<LedgerModel>()
           .HasRequired(c => c.TransactionModel)
           .WithMany(p => p.LedgerModels)
           .HasForeignKey(c => c.TransId);

            modelBuilder.Entity<CompanyModel>()
                  .HasRequired(c => c.CityModel)
                  .WithMany(p => p.CompanyModels)
                  .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<CompanyModel>()
                      .HasRequired(c => c.StateModel)
                      .WithMany(p => p.CompanyModels)
                      .HasForeignKey(c => c.StateId);

            modelBuilder.Entity<CompanyModel>()
                  .HasRequired(c => c.CountryModel)
                  .WithMany(p => p.CompanyModels)
                  .HasForeignKey(c => c.CountryId);
        }
        public DbSet<VegetableModel> VegetableModels { get; set; }
        public DbSet<CompanyModel> CompanyModels { get; set; }
        public DbSet<AccountDescription> AccountDescriptions { get; set; }
        public DbSet<CompanyBook> CompanyBooks { get; set; }
        public DbSet<CrateModel> CrateModels { get; set; }
        public DbSet<SecurityLoginModel> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogModel> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRoleModel> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRoleModel> SecurityRoles { get; set; }
         public DbSet<CountryModel> CountryModels { get; set; }
        public DbSet<StateModel> StateModels { get; set; }
        public DbSet<CityModel> CityModels { get; set; }
        public DbSet<AreaModel> AreaModels { get; set; }
        public DbSet<AccountModel> AccountModels { get; set; }
        public DbSet<SessionModel> SessionModels { get; set; }
        public DbSet<TransactionModel> TransactionModels { get; set; }
        public DbSet<LedgerModel> LedgerModels { get; set; }
        public DbSet<VoucherTypeModel> VoucherTypeModels { get; set; }

    }
}
