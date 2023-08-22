using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests.Tests
{
    public class ExpenseServiceTest
    {

        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the ExpenseService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with CategoryServiceTest

        private readonly string _className;
        public ExpenseServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);

            //Act
            //3
            //3;
            var expected = ExpenseTrackerTestData.ExpenseData().ToList();

            var expenses = service.GetAll();

            //Assert
            //4 Assert that there should be expenses retrieved 
            expenses.Should().NotBeNull();
            expenses.Should().HaveCount(expected.Count);
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);

            //Act
            //3
            //3
            var expected = ExpenseTrackerTestData.ExpenseData().OrderBy(o => o.ItemAmount).ToList();

            var expenses = service.GetAllOrderedByAmount();


            //Assert
            //4 Assert that expenses should be in ascending order
            expenses.Should().NotBeNull();
            expenses.Should().HaveCount(expected.Count);

            foreach (var item in expenses.Select((value, i) => new { i, value }))
            {
                item.value.Item.Should().BeEquivalentTo(expected[item.i].Item);
                item.value.ItemAmount.Should().Be(expected[item.i].ItemAmount);
            }
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);


            //Act
            //3
            //3
            var expected = ExpenseTrackerTestData.ExpenseData().FirstOrDefault();
            var expenseId = 1;

            var expense = service.GetSingle(expenseId);

            //Assert
            //4 Assert that expense returned is the one requested
            expense.Should().NotBeNull();
            expense.ExpenseId.Should().Be(expenseId);
            expense.Item.Should().Be(expected.Item);
            expense.ItemAmount.Should().Be(expected.ItemAmount);

        }

        [Fact]
        public void AddExpense_ShouldSuccessfullyAddExpense()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);

            //Act
            //3
            //3
            Expense expected = new Expense
            {
                Item = "Item2",
                DatePurchased = DateTime.Now,
                ItemAmount = 200,
                Category = new Category
                {
                    Name = "Category5",
                    Description = "Category5"
                }
            };
            var expense = service.Add(expected);

            //Assert
            //4 Assert that expense was added
            expense.Should().NotBeNull();
            expense.Item.Should().Be(expected.Item);
            expense.DatePurchased.Should().Be(expected.DatePurchased);
            expense.ItemAmount.Should().Be(expected.ItemAmount);
            expense.Category.Should().Be(expected.Category);
        }

        [Fact]
        public void DeleteExpense_ShouldSuccessfullyDeleteExpense()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);

            //Act
            //3
            //3
            var expenseId = 1;
            var expense = service.GetSingle(expenseId);

            service.Delete(expense);

            var result = service.GetSingle(expenseId);

            //Assert
            //4 Assert that expense was deleted
            result.Should().BeNull();

        }
    }
}
