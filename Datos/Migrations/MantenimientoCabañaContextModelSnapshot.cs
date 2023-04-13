﻿// <auto-generated />
using System;
using Datos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(MantenimientoCabañaContext))]
    partial class MantenimientoCabañaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.EntidadesNegocio.Cabaña", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<bool>("Jacuzzi")
                        .HasColumnType("bit");

                    b.Property<int>("Mantenimiento")
                        .HasColumnType("int");

                    b.Property<int>("PersonasMax")
                        .HasColumnType("int");

                    b.Property<int>("Tipoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Tipoid");

                    b.ToTable("Cabañas");
                });

            modelBuilder.Entity("Dominio.EntidadesNegocio.Funcionario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Dominio.EntidadesNegocio.Mantenimiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Cabaniaid")
                        .HasColumnType("int");

                    b.Property<double>("CostoMant")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Funcionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Cabaniaid");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("Dominio.EntidadesNegocio.Tipo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("Dominio.EntidadesNegocio.Cabaña", b =>
                {
                    b.HasOne("Dominio.EntidadesNegocio.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("Tipoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Dominio.EntidadesNegocio.Mantenimiento", b =>
                {
                    b.HasOne("Dominio.EntidadesNegocio.Cabaña", "Cabania")
                        .WithMany()
                        .HasForeignKey("Cabaniaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabania");
                });
#pragma warning restore 612, 618
        }
    }
}
