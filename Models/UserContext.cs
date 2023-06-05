using Microsoft.EntityFrameworkCore;


namespace PuYuan_net7.Models
{
    public partial class PuYuanContext : DbContext
    {
        //在User.cs裡面沒辦法透過屬性解決的會用這個方式寫在這邊，因為他有partial(關鍵字:fluent api
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Phone).IsUnique();
                entity.Property<bool>("Enabled").HasDefaultValue(false);
                entity.Property<bool>("Emailck").HasDefaultValue(false);
            });
        }
    }
}
