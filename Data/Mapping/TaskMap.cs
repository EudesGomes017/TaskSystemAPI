using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<ModelTask>
    {
        public void Configure(EntityTypeBuilder<ModelTask> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id); //CHAVE PRIMARIA
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255); //PROPRIEADE
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired(); //PROPRIEADE
            builder.Property(x => x.CreatedAt).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UpdateAt).IsRequired().HasMaxLength(255);

            builder.HasOne(mt => mt.User) // Use a propriedade de navegação correta (User)
               .WithMany(u => u.ModelTasks)     // Use a propriedade de coleção de tarefas no User
               .HasForeignKey(mt => mt.UserId); // Chave estrangeira na classe ModelTask


        }
    }
}
