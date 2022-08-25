﻿// <auto-generated />
using System;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AtriaContext))]
    [Migration("20220824232523_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Models.Collaborator", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Rights")
                        .HasColumnType("integer");

                    b.Property<long?>("WebserviceEntryId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.HasIndex("WebserviceEntryId");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("Models.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("WebserviceEntryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("WebserviceEntryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StarCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("WebserviceEntryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("WebserviceEntryId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UseCount")
                        .HasColumnType("bigint");

                    b.Property<long?>("WebserviceEntryId")
                        .HasColumnType("bigint");

                    b.HasKey("Name");

                    b.HasIndex("WebserviceEntryId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<int>("Rights")
                        .HasColumnType("integer");

                    b.Property<string>("SignUpIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.WebserviceEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ChangeLog")
                        .HasColumnType("text");

                    b.Property<long>("ContactPersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Documentation")
                        .HasColumnType("text");

                    b.Property<string>("DocumentationLink")
                        .HasColumnType("text");

                    b.Property<string>("FullDescription")
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContactPersonId");

                    b.ToTable("WebserviceEntries");
                });

            modelBuilder.Entity("Models.WSEDraft", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Changelog")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DocumentationLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Collaborator", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Collaborators")
                        .HasForeignKey("WebserviceEntryId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Question", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Questions")
                        .HasForeignKey("WebserviceEntryId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Review", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Reviews")
                        .HasForeignKey("WebserviceEntryId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Tags")
                        .HasForeignKey("WebserviceEntryId");
                });

            modelBuilder.Entity("Models.WebserviceEntry", b =>
                {
                    b.HasOne("Models.User", "ContactPerson")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ContactPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactPerson");
                });

            modelBuilder.Entity("Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Bookmarks");
                });

            modelBuilder.Entity("Models.WebserviceEntry", b =>
                {
                    b.Navigation("Collaborators");

                    b.Navigation("Questions");

                    b.Navigation("Reviews");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
