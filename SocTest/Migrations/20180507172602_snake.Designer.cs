﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SocTest.Models;
using System;

namespace SocTest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180507172602_snake")]
    partial class snake
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("SocTest.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnName("answer1");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnName("answer2");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_questions");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("SocTest.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SocTest.Models.UserResults", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnName("result");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_results");

                    b.HasIndex("UserId")
                        .HasName("ix_user_results_user_id");

                    b.ToTable("user_results");
                });

            modelBuilder.Entity("SocTest.Models.UserResults", b =>
                {
                    b.HasOne("SocTest.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_results_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
