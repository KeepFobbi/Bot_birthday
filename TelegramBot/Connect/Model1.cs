namespace TelegramBot.Connect
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Birthday> Birthday { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birthday>()
                .Property(e => e.Uname)
                .IsUnicode(false);

            modelBuilder.Entity<Birthday>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Uname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Upassword)
                .IsUnicode(false);
        }
    }
}
