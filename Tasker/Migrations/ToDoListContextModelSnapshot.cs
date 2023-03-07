﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasker;

#nullable disable

namespace Tasker.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    partial class ToDoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Tasker.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TaskComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToDoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskId");

                    b.HasIndex("ToDoListId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Tasker.ToDoList", b =>
                {
                    b.Property<int>("ToDoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ListName")
                        .HasColumnType("TEXT");

                    b.HasKey("ToDoListId");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("Tasker.Task", b =>
                {
                    b.HasOne("Tasker.ToDoList", "ToDoList")
                        .WithMany("Tasks")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoList");
                });

            modelBuilder.Entity("Tasker.ToDoList", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}