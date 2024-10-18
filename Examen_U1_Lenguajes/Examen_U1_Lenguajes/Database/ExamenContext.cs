using Examen_U1_Lenguajes.Database.Configuration;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Database
{
    public class ExamenContext : DbContext
    {
        private readonly IAuditService _auditService;

        public ExamenContext(
            DbContextOptions options,
            IAuditService auditService
            ) : base(options)
        {
            this._auditService = auditService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
            
            modelBuilder.HasDefaultSchema("security");

            modelBuilder.Entity<IdentityUser>().ToTable("users");
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());

            // Set FKs OnRestrict
            var eTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var type in eTypes)
            {
                var foreignKeys = type.GetForeignKeys();
                foreach (var foreignKey in foreignKeys)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified
                ));

            foreach (var entry in entries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = _auditService.GetUserId();
                        entity.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        entity.UpdatedBy = _auditService.GetUserId();
                        entity.UpdatedDate = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<JobTitleEntity> JobTitles { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<PermissionTypeEntity> Permissions { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
    }
}