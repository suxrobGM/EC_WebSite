﻿// <auto-generated />
using System;
using EC_WebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EC_WebSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190304043441_fix_authorId")]
    partial class fix_authorId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EC_WebSite.Models.Article", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("CoverPhotoId");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Summary")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique()
                        .HasFilter("[AuthorId] IS NOT NULL");

                    b.HasIndex("CoverPhotoId")
                        .IsUnique()
                        .HasFilter("[CoverPhotoId] IS NOT NULL");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Board", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ForumId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.FavoriteThread", b =>
                {
                    b.Property<string>("ThreadId");

                    b.Property<string>("UserId");

                    b.HasKey("ThreadId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteThreads");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.ForumHead", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ForumHeads");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Text");

                    b.Property<string>("ThreadId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ThreadId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Thread", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("BoardId");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsPinned");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BoardId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("EC_WebSite.Models.Media", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType");

                    b.Property<DateTime?>("CreatedTime");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.Skill", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("BanPeriod");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsBanned");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePhotoId");

                    b.Property<DateTime?>("RegistrationDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfilePhotoId")
                        .IsUnique()
                        .HasFilter("[ProfilePhotoId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.UserSkill", b =>
                {
                    b.Property<string>("SkillId");

                    b.Property<string>("UserId");

                    b.HasKey("SkillId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("EC_WebSite.Models.Article", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User", "Author")
                        .WithOne()
                        .HasForeignKey("EC_WebSite.Models.Article", "AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EC_WebSite.Models.Media", "CoverPhoto")
                        .WithOne()
                        .HasForeignKey("EC_WebSite.Models.Article", "CoverPhotoId");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Board", b =>
                {
                    b.HasOne("EC_WebSite.Models.ForumModel.ForumHead", "Forum")
                        .WithMany("Boards")
                        .HasForeignKey("ForumId");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.FavoriteThread", b =>
                {
                    b.HasOne("EC_WebSite.Models.ForumModel.Thread", "Thread")
                        .WithMany("FavoriteThreads")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EC_WebSite.Models.UserModel.User", "User")
                        .WithMany("FavoriteThreads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Post", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("EC_WebSite.Models.ForumModel.Thread", "Thread")
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId");
                });

            modelBuilder.Entity("EC_WebSite.Models.ForumModel.Thread", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User", "Author")
                        .WithMany("Threads")
                        .HasForeignKey("AuthorId");

                    b.HasOne("EC_WebSite.Models.ForumModel.Board", "Board")
                        .WithMany("Threads")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.User", b =>
                {
                    b.HasOne("EC_WebSite.Models.Media", "ProfilePhoto")
                        .WithOne()
                        .HasForeignKey("EC_WebSite.Models.UserModel.User", "ProfilePhotoId");
                });

            modelBuilder.Entity("EC_WebSite.Models.UserModel.UserSkill", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EC_WebSite.Models.UserModel.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EC_WebSite.Models.UserModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EC_WebSite.Models.UserModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
