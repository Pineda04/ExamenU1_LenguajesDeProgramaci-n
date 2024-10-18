using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Database
{
    public class ExamenContext : DbContext
    {
        private readonly IAuthService _authService;

        public ExamenContext(
            DbContextOptions options,
            IAuthService authService
        ) : base(options)
        {
            this._authService = authService;
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

            foreach (var entry in entries){
                var entity = entry.Entity as BaseEntity;

                if(entity != null){
                    if(entry.State == EntityState.Added){
                        entity.CreatedBy = _authService.GetUserId();
                        entity.CreatedDate = DateTime.Now;
                    }
                    else {
                        entity.UpdatedBy = _authService.GetUserId();
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