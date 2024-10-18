using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen_U1_Lenguajes.Database.Configuration
{
    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitleEntity>
    {
        public void Configure(EntityTypeBuilder<JobTitleEntity> builder)
        {
            builder.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .HasPrincipalKey(e => e.Id);

            builder.HasOne(e => e.UpdatedByUser)
                .WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .HasPrincipalKey(e => e.Id);
        }
    }
}