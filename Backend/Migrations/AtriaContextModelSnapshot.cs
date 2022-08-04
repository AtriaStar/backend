﻿// <auto-generated />
using System;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AtriaContext))]
    partial class AtriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.Property<decimal>("Snowflake")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("QuestionSnowflake")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Snowflake");

                    b.HasIndex("CreatorEmail");

                    b.HasIndex("QuestionSnowflake");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Models.Question", b =>
                {
                    b.Property<decimal>("Snowflake")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebserviceEntryName")
                        .HasColumnType("text");

                    b.HasKey("Snowflake");

                    b.HasIndex("CreatorEmail");

                    b.HasIndex("WebserviceEntryName");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Models.Review", b =>
                {
                    b.Property<decimal>("Snowflake")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StarCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebserviceEntryName")
                        .HasColumnType("text");

                    b.HasKey("Snowflake");

                    b.HasIndex("CreatorEmail");

                    b.HasIndex("WebserviceEntryName");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UseCount")
                        .HasColumnType("bigint");

                    b.Property<string>("WebserviceEntryName")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("WebserviceEntryName");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.WebserviceEntry", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Changelog")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPersonEmail")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreationDate")
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

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("ContactPersonEmail");

                    b.ToTable("WebserviceEntries");
                });

            modelBuilder.Entity("Models.WSEDraft", b =>
                {
                    b.Property<decimal>("Snowflake")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Changelog")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreationDate")
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

                    b.HasKey("Snowflake");

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionSnowflake");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Question", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Questions")
                        .HasForeignKey("WebserviceEntryName");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Review", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Reviews")
                        .HasForeignKey("WebserviceEntryName");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.HasOne("Models.WebserviceEntry", null)
                        .WithMany("Tags")
                        .HasForeignKey("WebserviceEntryName");
                });

            modelBuilder.Entity("Models.WebserviceEntry", b =>
                {
                    b.HasOne("Models.User", "ContactPerson")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ContactPersonEmail");

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
                    b.Navigation("Questions");

                    b.Navigation("Reviews");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
