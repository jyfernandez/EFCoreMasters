using ExpenseTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests
{
    public static class TestDatabaseSetup
    {
        public static void SeedData(this ExpenseTrackerDBContext dbContext)
        {
            dbContext.Expenses.AddRange(ExpenseTrackerTestData.ExpenseData());
            dbContext.SaveChanges();
        }

        public static void InitializeDBWithData(this ExpenseTrackerDBContext dbContext)
        {
            //TODO: delete and create a new database
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            //TODO: seed data
            dbContext.SeedData();

            //TODO: Reset change tracker 
            dbContext.ChangeTracker.Clear();
        }
    }
}
