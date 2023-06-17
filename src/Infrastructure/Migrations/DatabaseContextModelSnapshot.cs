﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.OverwatchCombatMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Screenshot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OverwatchMaps");
                });

            modelBuilder.Entity("Domain.OverwatchDeployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CombatMapId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeployedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeployedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GameModeId")
                        .HasColumnType("integer");

                    b.Property<int>("SuperHeroId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OverwatchDeployments");
                });

            modelBuilder.Entity("Domain.OverwatchMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OverwatchMedia");
                });

            modelBuilder.Entity("Domain.OverwatchMode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OverwatchCombatMapId")
                        .HasColumnType("integer");

                    b.Property<string>("Screenshot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OverwatchCombatMapId");

                    b.ToTable("OverwatchMode");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DetailId")
                        .HasColumnType("integer");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Portrait")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.ToTable("OverwatchSuperHeroes");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OverwatchSuperHeroDetailId")
                        .HasColumnType("integer");

                    b.Property<int>("VideoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OverwatchSuperHeroDetailId");

                    b.HasIndex("VideoId");

                    b.ToTable("OverwatchSuperHeroAbility");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroChapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OverwatchSuperHeroStoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OverwatchSuperHeroStoryId");

                    b.ToTable("OverwatchSuperHeroChapter");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HitpointsId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Portrait")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("StoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HitpointsId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StoryId");

                    b.ToTable("OverwatchSuperHeroDetail");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroHitpoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Armor")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int>("Shields")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OverwatchSuperHeroHitpoint");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Mp4")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Webm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OverwatchSuperHeroLink");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OverwatchSuperHeroRole");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaId")
                        .HasColumnType("integer");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("OverwatchSuperHeroStory");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("OverwatchSuperHeroVideo");
                });

            modelBuilder.Entity("Domain.OverwatchMode", b =>
                {
                    b.HasOne("Domain.OverwatchCombatMap", null)
                        .WithMany("Gamemodes")
                        .HasForeignKey("OverwatchCombatMapId");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHero", b =>
                {
                    b.HasOne("Domain.OverwatchSuperHeroDetail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroAbility", b =>
                {
                    b.HasOne("Domain.OverwatchSuperHeroDetail", null)
                        .WithMany("Abilities")
                        .HasForeignKey("OverwatchSuperHeroDetailId");

                    b.HasOne("Domain.OverwatchSuperHeroVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroChapter", b =>
                {
                    b.HasOne("Domain.OverwatchSuperHeroStory", null)
                        .WithMany("Chapters")
                        .HasForeignKey("OverwatchSuperHeroStoryId");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroDetail", b =>
                {
                    b.HasOne("Domain.OverwatchSuperHeroHitpoint", "Hitpoints")
                        .WithMany()
                        .HasForeignKey("HitpointsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.OverwatchSuperHeroRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.OverwatchSuperHeroStory", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hitpoints");

                    b.Navigation("Role");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroStory", b =>
                {
                    b.HasOne("Domain.OverwatchMedia", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroVideo", b =>
                {
                    b.HasOne("Domain.OverwatchSuperHeroLink", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");
                });

            modelBuilder.Entity("Domain.OverwatchCombatMap", b =>
                {
                    b.Navigation("Gamemodes");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroDetail", b =>
                {
                    b.Navigation("Abilities");
                });

            modelBuilder.Entity("Domain.OverwatchSuperHeroStory", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
