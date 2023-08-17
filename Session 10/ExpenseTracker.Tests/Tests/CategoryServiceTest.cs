using ExpenseTracker.API.Controllers;
using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest
    {
        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the CategoryService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with ExpenseServiceTest

        private readonly string _className;
        public CategoryServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new CategoryService(context);

            //Act
            //3
            var expected = ExpenseTrackerTestData.ExpenseData().Select(s => s.Category).ToList();

            var categories = service.GetAll();

            //Assert
            //4 Assert that there should be categories retrieved
            categories.Should().NotBeNull();
            categories.Should().HaveCount(expected.Count);
        }


        [Fact]
        public void GetSingleCategory_ShouldReturnRequested()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new CategoryService(context);


            //Act
            //3
            var categoryId = 1;
            var expected = ExpenseTrackerTestData.ExpenseData().Select(e => e.Category).FirstOrDefault();

            var category = service.GetSingle(categoryId);

            //Assert
            //4 Assert that category returned is the one requested
            category.Should().NotBeNull();
            category.CategoryId.Should().Be(categoryId);
            category.Name.Should().Be(expected.Name);
            category.Description.Should().Be(expected.Description);
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);

            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new CategoryService(context);

            //Act
            //3
            Category expected = new Category
            {
                Name = "Category3",
                Description = "Category3"
            };

            var category = service.Add(expected);

            //Assert
            //4 Assert that category was added
            category.Should().NotBeNull();
            category.Name.Should().Be(expected.Name);
            category.Description.Should().Be(expected.Description);
        }

        [Fact]
        public void DeleteCategory_ShouldSuccessfullyDeleteCategory()
        {
            //Arrange
            //1
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);

            //2
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new CategoryService(context);


            //Act
            //3
            var categoryId = 1;
            var category = service.GetSingle(categoryId);

            service.Delete(category);

            var result = service.GetSingle(categoryId);

            //Assert
            //4 Assert that category was deleted
            result.Should().BeNull();
        }
    }
}
