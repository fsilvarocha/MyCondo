﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCondo.Infra.Data;

#nullable disable

namespace MyCondo.API.Migrations
{
    [DbContext(typeof(MyCondoContext))]
    [Migration("20241127173805_CrudApartamento")]
    partial class CrudApartamento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MyCondo.Domain.Entities.Apartamento.Apartamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Andar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("BlocosId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataAtualizado")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValue(new DateTime(2024, 11, 27, 14, 38, 4, 681, DateTimeKind.Local).AddTicks(1751));

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("Tenante")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoApartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("BlocosId");

                    b.ToTable("Apartamentos", (string)null);
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Bloco.Blocos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CondominiosId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataAtualizado")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValue(new DateTime(2024, 11, 27, 14, 38, 4, 686, DateTimeKind.Local).AddTicks(9060));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("QuantidadeAndar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("Tenante")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CondominiosId");

                    b.ToTable("Blocos", (string)null);
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Condominio.Condominios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AreaTotal")
                        .HasColumnType("double(18,5)");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAtualizado")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValue(new DateTime(2024, 11, 27, 14, 38, 4, 688, DateTimeKind.Local).AddTicks(9554));

                    b.Property<string>("Logo")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("Tenante")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoCondominio")
                        .HasColumnType("int");

                    b.Property<string>("Uf")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Condominios", (string)null);
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Apartamento.Apartamentos", b =>
                {
                    b.HasOne("MyCondo.Domain.Entities.Bloco.Blocos", "Blocos")
                        .WithMany("Apartamentos")
                        .HasForeignKey("BlocosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blocos");
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Bloco.Blocos", b =>
                {
                    b.HasOne("MyCondo.Domain.Entities.Condominio.Condominios", "Condominios")
                        .WithMany("Blocos")
                        .HasForeignKey("CondominiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominios");
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Bloco.Blocos", b =>
                {
                    b.Navigation("Apartamentos");
                });

            modelBuilder.Entity("MyCondo.Domain.Entities.Condominio.Condominios", b =>
                {
                    b.Navigation("Blocos");
                });
#pragma warning restore 612, 618
        }
    }
}
