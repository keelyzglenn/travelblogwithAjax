using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelBlog.Models;

namespace TravelBlog.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    [Migration("20170502160902_AddSuggestion")]
    partial class AddSuggestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelBlog.Models.Suggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Destination");

                    b.Property<int>("Upvote");

                    b.HasKey("SuggestionId");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("PlaceId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelBlog.Models.ExperiencePeople", b =>
                {
                    b.Property<int>("ExperienceId");

                    b.Property<int>("PeopleId");

                    b.HasKey("ExperienceId", "PeopleId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("PeopleId");

                    b.ToTable("ExperiencesPeoples");
                });

            modelBuilder.Entity("TravelBlog.Models.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PeopleId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("TravelBlog.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.HasOne("TravelBlog.Models.Place", "Place")
                        .WithMany("Experiences")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBlog.Models.ExperiencePeople", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience", "Experience")
                        .WithMany("ExperiencesPeoples")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBlog.Models.People", "People")
                        .WithMany("ExperiencesPeoples")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
