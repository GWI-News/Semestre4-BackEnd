//using GwiNews.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace GwiNews.Infra.Data.EntityConfiguration
//{
//    public class FormationConfiguration : IEntityTypeConfiguration<Formation>
//    {
//        public void Configure(EntityTypeBuilder<Formation> builder)
//        {
//            // Chave primária
//            builder.HasKey(f => f.Id);

//            // Propriedade Id gerada automaticamente
//            builder.Property(f => f.Id)
//                   .IsRequired()
//                   .ValueGeneratedOnAdd();

//            // Propriedade Name (nome da formação)
//            builder.Property(f => f.Name)
//                   .IsRequired()
//                   .HasMaxLength(255);

//            // Propriedade Institution (nome da instituição)
//            builder.Property(f => f.Institution)
//                   .IsRequired()
//                   .HasMaxLength(255);

//            // Propriedade StartDate (data de início)
//            builder.Property(f => f.StartDate)
//                   .IsRequired();

//            // Propriedade EndDate (data de término)
//            builder.Property(f => f.EndDate)
//                   .IsRequired();

//            // Propriedade Activity1 (atividade 1)
//            builder.Property(f => f.Activity1)
//                   .HasMaxLength(255);

//            // Propriedade Activity2 (atividade 2)
//            builder.Property(f => f.Activity2)
//                   .HasMaxLength(255);

//            // Propriedade Activity3 (atividade 3)
//            builder.Property(f => f.Activity3)
//                   .HasMaxLength(255);
//        }
//    }
//}
