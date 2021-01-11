﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VertPub.Backend.Context;

namespace VertPub.Backend.Migrations
{
    [DbContext(typeof(VirtpubContext))]
    [Migration("20210111123630_gamePK")]
    partial class gamePK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("VertPub.Backend.Models.GameLinksModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<int>("maxPlayers")
                        .HasColumnType("integer");

                    b.Property<int>("minPlayers")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("GameLinks");
                });

            modelBuilder.Entity("VertPub.Backend.Models.ScoreBoardModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("gameID")
                        .HasColumnType("uuid");

                    b.Property<string>("player")
                        .HasColumnType("text");

                    b.Property<int>("points")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("ScoreBoards");
                });

            modelBuilder.Entity("VertPub.Backend.Models.TableModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("gameID")
                        .HasColumnType("uuid");

                    b.Property<bool>("isPrivate")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
