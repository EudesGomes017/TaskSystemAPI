using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<ModelUser>
    {
        public void Configure(EntityTypeBuilder<ModelUser> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id); //CHAVE PRIMARIA
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255); //PROPRIEADE
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UpdateAt).IsRequired().HasMaxLength(255);
            //   builder.Property(x => x.TaskId).IsRequired(); //PROPRIEADE

            // Configuração do relacionamento com ModelTasks
            builder.HasMany(u => u.ModelTasks) // Nome da propriedade de coleção em ModelUser
                .WithOne(mt => mt.User) // Nome da propriedade de navegação em ModelTask
                .HasForeignKey(mt => mt.UserId); // Chave estrangeira em ModelTask
                //.OnDelete(DeleteBehavior.Cascade); // Defina o comportamento de exclusão, se necessário


        }
    }
}
