﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using devBlog.Data;

#nullable disable

namespace devBlog.Migrations
{
    [DbContext(typeof(devBlogContext))]
    [Migration("20240801065156_SeedTags")]
    partial class SeedTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("TopicID")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasData(
                        new
                        {
                            TagID = new Guid("e6eafb78-2d3d-488c-8ff6-41512fcf3b4b"),
                            Name = "Development"
                        },
                        new
                        {
                            TagID = new Guid("7ad686fb-6326-4891-a2a4-6b4cc6243960"),
                            Name = "Web Development"
                        },
                        new
                        {
                            TagID = new Guid("1794de33-50c8-4a14-b4bb-a758e2ac2528"),
                            Name = "CSS"
                        },
                        new
                        {
                            TagID = new Guid("72d4c9e8-bc49-4f4f-b393-f78a734bdbad"),
                            Name = "JavaScript"
                        },
                        new
                        {
                            TagID = new Guid("91713744-ee9b-4887-8160-6bee49446863"),
                            Name = "Angular"
                        },
                        new
                        {
                            TagID = new Guid("d2c40fae-ac15-4945-8762-d5c3e8bcd632"),
                            Name = "PHP"
                        },
                        new
                        {
                            TagID = new Guid("ddb5da94-1d04-4de3-81b0-25ce759b364d"),
                            Name = "HTML"
                        },
                        new
                        {
                            TagID = new Guid("aea4ae6a-823c-4517-a2ca-3b7a1dca6d73"),
                            Name = "React"
                        },
                        new
                        {
                            TagID = new Guid("ec24b02f-98b6-42a5-aa58-9bbebf53f143"),
                            Name = "Data Science"
                        },
                        new
                        {
                            TagID = new Guid("11243338-a9ed-46f8-9a7a-bd8e889491db"),
                            Name = "Mobile Development"
                        },
                        new
                        {
                            TagID = new Guid("b9cffb4d-52e7-4a74-ab8e-d34fa3d6a380"),
                            Name = "Programming Language"
                        },
                        new
                        {
                            TagID = new Guid("d7036da9-1e71-4a80-9580-d57ab6e56c8b"),
                            Name = "Software Testing"
                        },
                        new
                        {
                            TagID = new Guid("7a3473bd-1ae1-4e95-ab81-fc6e3361ce4b"),
                            Name = "Software Engineering"
                        },
                        new
                        {
                            TagID = new Guid("8f7c4933-418d-4822-bab5-13a69703b66d"),
                            Name = "Software Development Tools"
                        },
                        new
                        {
                            TagID = new Guid("98b20f22-1948-4102-bd3b-06af09b2926e"),
                            Name = "Cybersecurity"
                        },
                        new
                        {
                            TagID = new Guid("bd8c477f-de79-40d7-9813-fcb02c50a901"),
                            Name = "Network Security"
                        },
                        new
                        {
                            TagID = new Guid("5f4ec4a1-fedc-474d-b7cf-1697286e8154"),
                            Name = "Application Security"
                        },
                        new
                        {
                            TagID = new Guid("23d770ef-eb4b-41e3-a7e8-53963d2ce31b"),
                            Name = "Data Privacy"
                        },
                        new
                        {
                            TagID = new Guid("b8baaf97-e783-4d35-936d-20ed9fdbd1e0"),
                            Name = "Incident Response"
                        },
                        new
                        {
                            TagID = new Guid("3487b5fd-230b-47c9-b3e4-0275f3afc74b"),
                            Name = "Security Tools"
                        },
                        new
                        {
                            TagID = new Guid("ed218458-b1da-45e1-a2c6-2c13ea272d9d"),
                            Name = "AI / ML"
                        },
                        new
                        {
                            TagID = new Guid("bb29cca1-558e-413c-b49f-f13dcbddf8c7"),
                            Name = "Machine Learning Algorithms"
                        },
                        new
                        {
                            TagID = new Guid("9034ea1f-bf09-4aa3-a406-ffe7ed6c7b57"),
                            Name = "Deep Learning"
                        },
                        new
                        {
                            TagID = new Guid("0e4b41d6-1f18-42c0-be97-a36978d07cb7"),
                            Name = "AI Applications"
                        },
                        new
                        {
                            TagID = new Guid("4d582a53-68c2-4697-b7b1-13883ee332ee"),
                            Name = "Ethics in AI"
                        },
                        new
                        {
                            TagID = new Guid("cfbdc79c-5b18-4ead-8e0f-601d833adb30"),
                            Name = "Cloud Computing"
                        },
                        new
                        {
                            TagID = new Guid("87488ca6-8e26-4ffa-ae02-89c13f3c6a18"),
                            Name = "Tech Industry News"
                        });
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
