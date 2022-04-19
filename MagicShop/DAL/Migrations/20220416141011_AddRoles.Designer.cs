﻿// <auto-generated />
using System;
using DLL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ArmoryDbContext))]
    [Migration("20220416141011_AddRoles")]
    partial class AddRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entites.Base.BaseFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DAL.Entites.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("DAL.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@mail.ua",
                            Password = "123456",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("DLL.Entites.Accessories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessoriesType")
                        .HasColumnType("int");

                    b.Property<string>("ActiveEffect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Agility")
                        .HasColumnType("bigint");

                    b.Property<long>("CriticalDamage")
                        .HasColumnType("bigint");

                    b.Property<long>("Endurance")
                        .HasColumnType("bigint");

                    b.Property<long>("Intelligence")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.Property<long>("Strength")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("DLL.Entites.Base.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Agility")
                        .HasColumnType("bigint");

                    b.Property<int>("ArmorMaterialType")
                        .HasColumnType("int");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<long>("CriticalDamage")
                        .HasColumnType("bigint");

                    b.Property<long>("Endurance")
                        .HasColumnType("bigint");

                    b.Property<int>("FireRezist")
                        .HasColumnType("int");

                    b.Property<int>("IceRezist")
                        .HasColumnType("int");

                    b.Property<long>("Intelligence")
                        .HasColumnType("bigint");

                    b.Property<int>("MagicRezist")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhysicalRezist")
                        .HasColumnType("int");

                    b.Property<int>("PoisonRezist")
                        .HasColumnType("int");

                    b.Property<int>("Protection")
                        .HasColumnType("int");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.Property<long>("Strength")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Armor");
                });

            modelBuilder.Entity("DLL.Entites.MagicWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Agility")
                        .HasColumnType("bigint");

                    b.Property<long>("CriticalDamage")
                        .HasColumnType("bigint");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<long>("Endurance")
                        .HasColumnType("bigint");

                    b.Property<int>("HandWeaponType")
                        .HasColumnType("int");

                    b.Property<long>("Intelligence")
                        .HasColumnType("bigint");

                    b.Property<int>("MagicWeaponType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.Property<long>("Strength")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MagicWeapon");
                });

            modelBuilder.Entity("DLL.Entites.MeleeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Agility")
                        .HasColumnType("bigint");

                    b.Property<long>("CriticalDamage")
                        .HasColumnType("bigint");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<long>("Endurance")
                        .HasColumnType("bigint");

                    b.Property<int>("HandWeaponType")
                        .HasColumnType("int");

                    b.Property<long>("Intelligence")
                        .HasColumnType("bigint");

                    b.Property<int>("MeleeWeaponType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.Property<long>("Strength")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MeleeWeapon");
                });

            modelBuilder.Entity("DLL.Entites.RangeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Agility")
                        .HasColumnType("bigint");

                    b.Property<long>("CriticalDamage")
                        .HasColumnType("bigint");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<long>("Endurance")
                        .HasColumnType("bigint");

                    b.Property<int>("HandWeaponType")
                        .HasColumnType("int");

                    b.Property<long>("Intelligence")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeWeaponType")
                        .HasColumnType("int");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.Property<long>("Strength")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RangeWeapon");
                });

            modelBuilder.Entity("DAL.Entites.User", b =>
                {
                    b.HasOne("DAL.Entites.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DAL.Entites.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
