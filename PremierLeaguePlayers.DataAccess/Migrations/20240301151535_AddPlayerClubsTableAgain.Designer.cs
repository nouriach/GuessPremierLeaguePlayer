﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PremierLeaguePlayers.DataAccess;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240301151535_AddPlayerClubsTableAgain")]
    partial class AddPlayerClubsTableAgain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbbreviatedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.PlayerClub", b =>
                {
                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerClubs");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.Player", b =>
                {
                    b.HasOne("PremierLeaguePlayers.Domain.Entities.Club", null)
                        .WithMany("PlayerClubs")
                        .HasForeignKey("ClubId");

                    b.HasOne("PremierLeaguePlayers.Domain.Entities.Player", null)
                        .WithMany("PlayerClubs")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.PlayerClub", b =>
                {
                    b.HasOne("PremierLeaguePlayers.Domain.Entities.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PremierLeaguePlayers.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.Club", b =>
                {
                    b.Navigation("PlayerClubs");
                });

            modelBuilder.Entity("PremierLeaguePlayers.Domain.Entities.Player", b =>
                {
                    b.Navigation("PlayerClubs");
                });
#pragma warning restore 612, 618
        }
    }
}
