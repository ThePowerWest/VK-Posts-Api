﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VK_Posts_Api.DAL;

#nullable disable

namespace VKPostsApi.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20221124155933_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VK_Posts_Api.Models.Letter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("LetterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ResultId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("VK_Posts_Api.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ResultId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("VK_Posts_Api.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("VK_Posts_Api.Models.Letter", b =>
                {
                    b.HasOne("VK_Posts_Api.Models.Result", null)
                        .WithMany("Counts")
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("VK_Posts_Api.Models.Post", b =>
                {
                    b.HasOne("VK_Posts_Api.Models.Result", null)
                        .WithMany("Posts")
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("VK_Posts_Api.Models.Result", b =>
                {
                    b.Navigation("Counts");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
