﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission08_4_6.Models;

namespace Mission08_4_6.Migrations
{
    [DbContext(typeof(TaskFormContext))]
    partial class TaskFormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission08_4_6.Models.FormResponse", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuadrantID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskID");

                    b.HasIndex("QuadrantID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            Category = "School",
                            Completed = false,
                            DueDate = "1/1/2023",
                            QuadrantID = 1,
                            TaskName = "Homework"
                        });
                });

            modelBuilder.Entity("Mission08_4_6.Models.Quadrant", b =>
                {
                    b.Property<int>("QuadrantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuadrantName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuadrantID");

                    b.ToTable("Quadrants");

                    b.HasData(
                        new
                        {
                            QuadrantID = 1,
                            QuadrantName = "Quadrant I: Important / Urgent"
                        },
                        new
                        {
                            QuadrantID = 2,
                            QuadrantName = "Quadrant II: Important / Not Urgent"
                        },
                        new
                        {
                            QuadrantID = 3,
                            QuadrantName = "Quadrant III: Not Important / Urgent"
                        },
                        new
                        {
                            QuadrantID = 4,
                            QuadrantName = "Quadrant IV: Not Important / Not Urgent"
                        });
                });

            modelBuilder.Entity("Mission08_4_6.Models.FormResponse", b =>
                {
                    b.HasOne("Mission08_4_6.Models.Quadrant", "Quadrant")
                        .WithMany()
                        .HasForeignKey("QuadrantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
