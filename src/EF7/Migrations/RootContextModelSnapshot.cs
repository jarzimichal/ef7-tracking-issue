using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EF7.Data;

namespace EF7.Migrations
{
    [DbContext(typeof(RootContext))]
    partial class RootContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF7.Domain.Child", b =>
                {
                    b.Property<int>("IdRow")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentIdRow");

                    b.HasKey("IdRow");

                    b.HasIndex("ParentIdRow");

                    b.ToTable("Childs");
                });

            modelBuilder.Entity("EF7.Domain.Parent", b =>
                {
                    b.Property<int>("IdRow")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("IdRow");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("EF7.Domain.Toy", b =>
                {
                    b.Property<int>("IdRow")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("IdRow");

                    b.HasIndex("IdRow");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("EF7.Domain.Child", b =>
                {
                    b.HasOne("EF7.Domain.Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentIdRow");
                });

            modelBuilder.Entity("EF7.Domain.Toy", b =>
                {
                    b.HasOne("EF7.Domain.Child")
                        .WithMany("Toys")
                        .HasForeignKey("IdRow");
                });
        }
    }
}
