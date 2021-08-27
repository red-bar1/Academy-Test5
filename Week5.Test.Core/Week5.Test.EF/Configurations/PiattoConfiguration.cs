using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Core.Models;

namespace Week5.Test.EF.Configurations
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto").HasKey(p => p.Id);
            builder.Property("Id").HasColumnType("int");
            builder.Property("Nome").IsRequired();
            builder.Property("Descrizione").IsRequired();
            builder.Property("Tipologia").IsRequired();
            builder.Property("Prezzo").HasColumnType("decimal").IsRequired();

            builder.HasData(
                new Piatto { Id = 1, Nome = "Lasagne", Descrizione = "Tradizionale piatto italiano", Tipologia = Tipologia.Primo, Prezzo = 12 },
                new Piatto { Id = 2, Nome = "Bistecca", Descrizione = "Bistecca da allevamenti italiani", Tipologia = Tipologia.Secondo, Prezzo = 20 },
                new Piatto { Id = 3, Nome = "Insalata", Descrizione = "Insalata con foglie italiane", Tipologia = Tipologia.Contorno, Prezzo = 4 },
                new Piatto { Id = 4, Nome = "Tiramisù", Descrizione = "Dolce italiano fatto da italiani", Tipologia = Tipologia.Dolce, Prezzo = 6 }
                );

        }
    }
}
