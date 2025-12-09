using Microsoft.EntityFrameworkCore;
// Ensure the following using directive matches the actual namespace of your Users entity.
// If the namespace is different, update it accordingly.

using Domain.Entity;
namespace Infrastrucure
{
    public class TenderContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Tender> tenders { get; set; }
        public DbSet<TenderType> tenderTypes { get; set; }
        public DbSet<TenderCategory> tenderCategories { get; set; }
        public DbSet<TenderDocument> tenderDocuments { get; set; }

        public TenderContext(DbContextOptions<TenderContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NRLBL9O\\SQLEXPRESS01;database=ProjectTwoSkyDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(u => u.userId)
                .IsUnique();
            modelBuilder.Entity<Tender>()
                .HasOne(t => t.tenderType)
                .WithOne(tt => tt.tender)
                .HasForeignKey<Tender>(t => t.tenderTypeId);

            modelBuilder.Entity<Tender>()
                .HasOne(t => t.tenderCategory)
                .WithOne(tc => tc.tender)
                .HasForeignKey<Tender>(t => t.tenderCategoryId);

            modelBuilder.Entity<TenderDocument>()
                .HasOne(td => td.tender)
                .WithMany(t => t.tenderDocuments)
                .HasForeignKey(td => td.tenderId);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.tenders)
                .WithOne(t => t.user)
                .HasForeignKey(t => t.userId);

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.userId, ur.roleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.user)
                .WithMany(u => u.userRoles)
                .HasForeignKey(ur => ur.userId);
            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.role)
                .WithMany(r => r.userRoles)
                .HasForeignKey(ur => ur.roleId);


        }
    }
}
