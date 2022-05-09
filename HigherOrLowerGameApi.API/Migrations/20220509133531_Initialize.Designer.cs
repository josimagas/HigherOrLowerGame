﻿// <auto-generated />
using System;
using HigherOrLowerGameApi.API.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HigherOrLowerGameApi.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220509133531_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HigherOrLowerGameApi.API.Model.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentCardValue")
                        .HasColumnType("integer");

                    b.Property<string>("CurrentPlayer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<int>("FirstPlayerScore")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfCardOnDeck")
                        .HasColumnType("integer");

                    b.Property<int>("SecondPlayerScore")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Game", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
