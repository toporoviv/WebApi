﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data.DataContexts;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Data.DataEntities.MailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FailedMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("MailLogs");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.MailMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MailMessages");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.MailRecipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("RecipientId");

                    b.ToTable("MailRecipients");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.MailLog", b =>
                {
                    b.HasOne("WebApi.Data.DataEntities.MailMessage", "MailMessage")
                        .WithOne("MailLog")
                        .HasForeignKey("WebApi.Data.DataEntities.MailLog", "MessageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("MailMessage");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.MailRecipient", b =>
                {
                    b.HasOne("WebApi.Data.DataEntities.MailMessage", "MailMessage")
                        .WithMany("MailRecipients")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("WebApi.Data.DataEntities.Recipient", "Recipient")
                        .WithMany("MailRecipients")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("MailMessage");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.MailMessage", b =>
                {
                    b.Navigation("MailLog")
                        .IsRequired();

                    b.Navigation("MailRecipients");
                });

            modelBuilder.Entity("WebApi.Data.DataEntities.Recipient", b =>
                {
                    b.Navigation("MailRecipients");
                });
#pragma warning restore 612, 618
        }
    }
}
