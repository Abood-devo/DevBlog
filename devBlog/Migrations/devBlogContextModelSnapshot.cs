﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using devBlog.Data;

#nullable disable

namespace devBlog.Migrations
{
    [DbContext(typeof(devBlogContext))]
    partial class devBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("devBlog.Models.BlogPost", b =>
                {
                    b.Property<Guid>("BlogPostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPhotoUrl")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("BlogPostID");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("devBlog.Models.BlogPostTag", b =>
                {
                    b.Property<Guid>("BlogPostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogPostID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("BlogPostTag");
                });

            modelBuilder.Entity("devBlog.Models.Tag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("TagID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("devBlog.Models.BlogPostTag", b =>
                {
                    b.HasOne("devBlog.Models.BlogPost", "BlogPost")
                        .WithMany("BlogPostTags")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devBlog.Models.Tag", "Tag")
                        .WithMany("BlogPostTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogPost");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("devBlog.Models.BlogPost", b =>
                {
                    b.Navigation("BlogPostTags");
                });

            modelBuilder.Entity("devBlog.Models.Tag", b =>
                {
                    b.Navigation("BlogPostTags");
                });
#pragma warning restore 612, 618
        }
    }
}
