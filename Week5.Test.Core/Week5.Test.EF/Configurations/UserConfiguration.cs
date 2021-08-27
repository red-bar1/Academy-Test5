using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Core.Models;

namespace Week5.Test.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id);
            builder.Property("Id").HasColumnType("int");
            builder.Property("Username").IsRequired();
            builder.Property("Password").IsRequired();
            builder.Property("Ruolo").IsRequired();


            builder.HasData(
                new User { Id = 1, Username = "giulia.tuttobene@abc.it", Password = "1234", Ruolo = Ruolo.Cliente },
                new User { Id = 2, Username = "m.rossi@abc.it", Password = "4321", Ruolo = Ruolo.Ristoratore }
                );
        }
    }
}
