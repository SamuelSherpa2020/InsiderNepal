using InsiderNepalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InsiderNepalApp.Data
{
    public class InsiderNepalDbContext:DbContext
    {
        public InsiderNepalDbContext(DbContextOptions<InsiderNepalDbContext> opts):base(opts)
        {

        }

        public DbSet<NationalNews> NationalNews { get; set; }
        public DbSet<AdsModel> AdsModel { get; set; }
    }
}
