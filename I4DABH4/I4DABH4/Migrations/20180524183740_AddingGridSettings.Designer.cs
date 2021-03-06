﻿// <auto-generated />
using I4DABH4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace I4DABH4.Migrations
{
    [DbContext(typeof(ProsumerContext))]
    [Migration("20180524183740_AddingGridSettings")]
    partial class AddingGridSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("I4DABH4.Models.GridSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("UseDyppekogebuffer");

                    b.HasKey("Id");

                    b.ToTable("GridSettings");
                });

            modelBuilder.Entity("I4DABH4.Models.Prosumer", b =>
                {
                    b.Property<long>("ProsumerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("NetValue");

                    b.Property<string>("Type");

                    b.HasKey("ProsumerId");

                    b.ToTable("Prosumers");
                });
#pragma warning restore 612, 618
        }
    }
}
