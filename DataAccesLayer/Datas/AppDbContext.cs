using DataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<AdsElon> AdsElons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubRegion> SubRegions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCategory(modelBuilder);
            ConfigureAdsElon(modelBuilder);
            ConfigureImage(modelBuilder);
            ConfigureMessage(modelBuilder);
            ConfigureChat(modelBuilder);
        }

        private void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(s => s.SubCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureAdsElon(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdsElon>()
                .HasOne(a => a.User)
                .WithMany(u => u.AdsElons)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<AdsElon>()
                .HasOne(a => a.SubRegionNavigation)
                .WithMany(sr => sr.AdsElons)
                .HasForeignKey(a => a.SubRegionId);
        }

        private void ConfigureImage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(i => i.AdsElons)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.AdsElonId);
        }

        private void ConfigureMessage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);
        }
        
        private void ConfigureChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User1)
                .WithMany(u => u.ChatUser1s)
                .HasForeignKey(c => c.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User2)
                .WithMany(u => u.ChatUser2s)
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
