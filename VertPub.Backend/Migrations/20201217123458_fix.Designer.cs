﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VertPub.Backend.Context;

namespace VertPub.Backend.Migrations
{
    [DbContext(typeof(VirtpubContext))]
    [Migration("20201217123458_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VertPub.Backend.Models.GameLinksModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("GameLinks");
                });

            modelBuilder.Entity("VertPub.Backend.Models.ScoreBoardModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("gameid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("player")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("gameid");

                    b.ToTable("ScoreBoards");
                });

            modelBuilder.Entity("VertPub.Backend.Models.TableModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isPrivate")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("VertPub.Backend.Models.ScoreBoardModel", b =>
                {
                    b.HasOne("VertPub.Backend.Models.GameLinksModel", "game")
                        .WithMany()
                        .HasForeignKey("gameid");

                    b.Navigation("game");
                });
#pragma warning restore 612, 618
        }
    }
}
