using ExpenseSharing.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSharing.Api.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Expenses> Expenses { get; set; }
        DbSet<ExpenseSplits> ExpenseSplits { get; set; }
        DbSet<GroupMember> GroupMember { get; set; }
        DbSet<Groups> Groups { get; set; }

        int SaveChanges();
    }
}