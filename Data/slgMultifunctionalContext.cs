using Microsoft.EntityFrameworkCore;
using slgMultifunctional.Models;

namespace slgMultifunctional.Data
{
    public class slgMultifunctionalContext : DbContext
    {
        public slgMultifunctionalContext (DbContextOptions<slgMultifunctionalContext> options)
            : base(options)
        {
        }

        public DbSet<slgApprovedMovies> slgApprovedMovies { get; set; }
    }
}