﻿// <auto-generated />
using Grand_Strand_Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Grand_Strand_Systems.Migrations
{
    [DbContext(typeof(ContactsContext))]
    [Migration("20210601112923_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Grand_Strand_Systems.ContactModel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Grand_Strand_Systems.TaskModel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactModelID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ContactModelID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Grand_Strand_Systems.TaskModel", b =>
                {
                    b.HasOne("Grand_Strand_Systems.ContactModel", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ContactModelID");
                });

            modelBuilder.Entity("Grand_Strand_Systems.ContactModel", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
