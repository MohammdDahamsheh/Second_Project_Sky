using Microsoft.EntityFrameworkCore;

namespace Infrastrucure
{
    internal class TenderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NRLBL9O\\SQLEXPRESS01;database=ProjectTwoSkyDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
