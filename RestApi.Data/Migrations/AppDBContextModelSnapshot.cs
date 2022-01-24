﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi.Data.Entities;

namespace RestApi.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RestApi.Data.Entities.BroadcastProgram", b =>
                {
                    b.Property<int>("BroadcastProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BroadcastProgramName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BroadcastProgramId");

                    b.ToTable("BroadcastProgram");
                });

            modelBuilder.Entity("RestApi.Data.Entities.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CardCode")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CardName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CardRecipient")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CardSendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardSender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("RestApi.Data.Entities.Ingest", b =>
                {
                    b.Property<int>("IngestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BroadcastProgramId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Genre")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("IngestGenreId")
                        .HasColumnType("int");

                    b.Property<string>("ProcessingHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Production")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Reporter")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SavaData")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subscriber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("film")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IngestId");

                    b.HasIndex("BroadcastProgramId");

                    b.HasIndex("CardId");

                    b.HasIndex("IngestGenreId");

                    b.ToTable("Ingest");
                });

            modelBuilder.Entity("RestApi.Data.Entities.IngestGenre", b =>
                {
                    b.Property<int>("IngestGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IngestGenreName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IngestGenreId");

                    b.ToTable("IngestGenre");
                });

            modelBuilder.Entity("RestApi.Data.Entities.Ingest", b =>
                {
                    b.HasOne("RestApi.Data.Entities.BroadcastProgram", null)
                        .WithMany("Ingests")
                        .HasForeignKey("BroadcastProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestApi.Data.Entities.Card", null)
                        .WithMany("Ingests")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestApi.Data.Entities.IngestGenre", null)
                        .WithMany("Ingests")
                        .HasForeignKey("IngestGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestApi.Data.Entities.BroadcastProgram", b =>
                {
                    b.Navigation("Ingests");
                });

            modelBuilder.Entity("RestApi.Data.Entities.Card", b =>
                {
                    b.Navigation("Ingests");
                });

            modelBuilder.Entity("RestApi.Data.Entities.IngestGenre", b =>
                {
                    b.Navigation("Ingests");
                });
#pragma warning restore 612, 618
        }
    }
}
