using Microsoft.EntityFrameworkCore;
using VotingApp.Models;

namespace VotingApp.Data
{
    public class VotingContext : DbContext
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
    }
}
