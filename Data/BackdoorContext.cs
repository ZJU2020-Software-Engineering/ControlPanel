using Microsoft.EntityFrameworkCore;
using ControlPanel.Models;

namespace ControlPanel.Data
{
    public class BackdoorContext: DbContext
    {
        public BackdoorContext(DbContextOptions<BackdoorContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Person> PersonalUserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                // entity.HasKey(e => e.Uid);
                // entity.Property(e => e.Title).IsRequired();
            });
        }
    }
}
