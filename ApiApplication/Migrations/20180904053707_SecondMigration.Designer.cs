﻿// <auto-generated />
using System;
using ApiApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiApplication.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20180904053707_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("ApiApplication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("InsertedDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiApplication.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("InsertedDate");

                    b.Property<int?>("UserId");

                    b.Property<int>("WorkoutType");

                    b.HasKey("WorkoutId");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("ApiApplication.Models.WorkoutType", b =>
                {
                    b.Property<int>("WorkoutTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("WorkoutTypeId");

                    b.ToTable("WorkoutTypes");
                });

            modelBuilder.Entity("ApiApplication.Models.Workout", b =>
                {
                    b.HasOne("ApiApplication.Models.User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
