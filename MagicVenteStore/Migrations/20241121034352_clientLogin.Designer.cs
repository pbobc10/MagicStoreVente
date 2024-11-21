﻿// <auto-generated />
using MagicVenteStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVenteStore.Migrations
{
    [DbContext(typeof(MagicVenteStoreContext))]
    [Migration("20241121034352_clientLogin")]
    partial class clientLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("MagicVenteStore.Metier.Models.Client", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Numero");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MagicVenteStore.Metier.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstDuJour")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Prix")
                        .HasColumnType("REAL");

                    b.Property<int>("QuantiteEnStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
