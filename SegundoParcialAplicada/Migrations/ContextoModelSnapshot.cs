﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundoParcialAplicada.Data;

namespace SegundoParcialAplicada.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("SegundoParcialAplicada.Models.Calls", b =>
                {
                    b.Property<int>("CallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CallId");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("SegundoParcialAplicada.Models.CallsDetail", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CallId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Problema")
                        .HasColumnType("TEXT");

                    b.Property<string>("Solucion")
                        .HasColumnType("TEXT");

                    b.HasKey("DetalleId");

                    b.HasIndex("CallId");

                    b.ToTable("CallsDetail");
                });

            modelBuilder.Entity("SegundoParcialAplicada.Models.CallsDetail", b =>
                {
                    b.HasOne("SegundoParcialAplicada.Models.Calls", null)
                        .WithMany("Detalles")
                        .HasForeignKey("CallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
