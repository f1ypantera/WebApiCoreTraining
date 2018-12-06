﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApiCoreTraining.Models;

namespace WebApiCoreTraining.Migrations
{
    [DbContext(typeof(PeopleContext))]
    partial class PeopleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiCoreTraining.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimeRegister");

                    b.Property<string>("Name");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebApiCoreTraining.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int>("ClientId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("WebApiCoreTraining.Models.Property", b =>
                {
                    b.HasOne("WebApiCoreTraining.Models.Client", "Client")
                        .WithMany("Properties")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("ForeignKey_Properties_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
