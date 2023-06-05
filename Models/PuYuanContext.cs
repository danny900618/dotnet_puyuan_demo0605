using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PuYuan_net7.Models
{
    public partial class PuYuanContext : DbContext
    {
        //這邊用來新增表
        public DbSet<User> User { get; set; }
        public DbSet<UserSet> UserSet { get; set; }
        public DbSet<BloodPressure> BloodPressure { get; set; }
        public DbSet<BloodSugar> BloodSugar { get; set; }
        public DbSet<Weight_M> Weight { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Medical> Medical { get; set; }
        public DbSet<Diary> Diary { get; set; }
        public DbSet<A1c> A1c { get; set; }
        public PuYuanContext()
        {
        }

        public PuYuanContext(DbContextOptions<PuYuanContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
