﻿namespace BeerApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BeerApp.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Joke> Jokes { get; set; }

        public IDbSet<JokeCategory> JokesCategories { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Place>()
        //                .HasMany<Beer>(p => p.Beers)
        //                .WithMany(b => b.Places)
        //                .Map(bp =>
        //                {
        //                    bp.MapLeftKey("PlaceRefId");
        //                    bp.MapRightKey("BeerRefId");
        //                    bp.ToTable("BeerPlaces");
        //                });
        //    base.OnModelCreating(modelBuilder);
        //}

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
