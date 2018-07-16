namespace EntityFramework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBSchedule : DbContext
    {
        public DBSchedule()
            : base("name=DBSchedule")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Notes)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.NoteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notes>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}
