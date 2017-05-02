using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TravelBlog.Models;

namespace TravelBlog.Models
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext()
        {

        }

        public DbSet<Place> Places { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<People> Peoples { get; set; }

        public DbSet<ExperiencePeople> ExperiencesPeoples { get; set; }

        public DbSet<Suggestion> Suggestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options)
            :base(options)
            {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperiencePeople>()
                .HasKey(t => new { t.ExperienceId, t.PeopleId });

            modelBuilder.Entity<ExperiencePeople>()
                .HasOne(pt => pt.Experience)
                .WithMany(p => p.ExperiencesPeoples)
                .HasForeignKey(pt => pt.ExperienceId);

            modelBuilder.Entity<ExperiencePeople>()
               .HasOne(pt => pt.People)
               .WithMany(p => p.ExperiencesPeoples)
               .HasForeignKey(pt => pt.PeopleId);


            
            //base.OnModelCreating(modelbuilder);
            //modelbuilder.Entity<ExperiencePeople>().HasKey(x => new
            //{ x.ExperienceId, x.PeopleId });
        }
    }
}
