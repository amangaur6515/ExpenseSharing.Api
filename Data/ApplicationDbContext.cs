using ExpenseSharing.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSharing.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        //add models 
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpenseSplits> ExpenseSplits { get; set; }
    }
}
