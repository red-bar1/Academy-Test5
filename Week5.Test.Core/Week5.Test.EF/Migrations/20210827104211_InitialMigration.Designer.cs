﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week5.Test.EF;

namespace Week5.Test.EF.Migrations
{
    [DbContext(typeof(RistoranteContext))]
    [Migration("20210827104211_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week5.Test.Core.Models.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal");

                    b.Property<int>("Tipologia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Piatto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "Tradizionale piatto italiano",
                            Nome = "Lasagne",
                            Prezzo = 12m,
                            Tipologia = 0
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "Bistecca da allevamenti italiani",
                            Nome = "Bistecca",
                            Prezzo = 20m,
                            Tipologia = 1
                        },
                        new
                        {
                            Id = 3,
                            Descrizione = "Insalata con foglie italiane",
                            Nome = "Insalata",
                            Prezzo = 4m,
                            Tipologia = 2
                        },
                        new
                        {
                            Id = 4,
                            Descrizione = "Dolce italiano fatto da italiani",
                            Nome = "Tiramisù",
                            Prezzo = 6m,
                            Tipologia = 2
                        });
                });

            modelBuilder.Entity("Week5.Test.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1234",
                            Ruolo = 1,
                            Username = "giulia.tuttobene@abc.it"
                        },
                        new
                        {
                            Id = 2,
                            Password = "4321",
                            Ruolo = 0,
                            Username = "m.rossi@abc.it"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}