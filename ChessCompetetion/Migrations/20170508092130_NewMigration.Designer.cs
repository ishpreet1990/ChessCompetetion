using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChessCompetetion.Model;

namespace ChessCompetetion.Migrations
{
    [DbContext(typeof(ChessContext))]
    [Migration("20170508092130_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChessCompetetion.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ResultId");

                    b.Property<long>("Score");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("ChessCompetetion.Model.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("ChessCompetetion.Model.Player", b =>
                {
                    b.HasOne("ChessCompetetion.Model.Result")
                        .WithMany("Players")
                        .HasForeignKey("ResultId");
                });
        }
    }
}
