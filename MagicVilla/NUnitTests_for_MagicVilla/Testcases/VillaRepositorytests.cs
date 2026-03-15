using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;

namespace NUnitTests_for_MagicVilla.Repository_testcases
{
    public  class VillaRepositorytest
    {
        private Mock<ApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Villa>> _mockDbSet;
        private VillaRepository _villaRepository;

        [SetUp]
        public void SetUp()
        {
            _mockDbContext = new Mock<ApplicationDbContext>();
            _mockDbSet = new Mock<DbSet<Villa>>();

            // Mock the DbSet property of the ApplicationDbContext to return the mock DbSet
            
        }
        [Test]
        public async Task CreateAsync_Should_Add_Villa_And_Save()
        {
            // Arrange
            var villa = new Villa
            {
                Name = "pavithra villa",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = "",
            };
            _mockDbContext.Setup(db => db.Set<Villa>()).Returns(_mockDbSet.Object);

            _villaRepository = new VillaRepository(_mockDbContext.Object);

            // Act
            await _villaRepository.CreateAsync(villa);

            // Assert
            // Verify that AddAsync was called once with the villa entity
            _mockDbSet.Verify(dbSet => dbSet.AddAsync(It.IsAny<Villa>(), default), Times.Once);

            // Verify that SaveChangesAsync was called once to persist the changes
            _mockDbContext.Verify(dbContext => dbContext.SaveChangesAsync(default), Times.Once);
        }
        [Test]
        public async Task GetAsync_should_return_villa_If_found()
        {
            var data = new Villa
            {
                Id = 1,
                Name = "pavithra villa",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = "",
            };
            var villalist = new List<Villa> { data };
            _mockDbContext.Setup(db => db.Set<Villa>()).Returns(_mockDbSet.Object);

            _villaRepository = new VillaRepository(_mockDbContext.Object);




            //var result = await _villaRepository.GetAsync(x => x.Id == 1);
            //Assert.That(result, Is.Not.Null);

        }
        private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockDbSet;
        }

    }
}
