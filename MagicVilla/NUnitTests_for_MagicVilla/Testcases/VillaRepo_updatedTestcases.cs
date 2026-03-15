using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace NUnitTests_for_MagicVilla.Testcases
{
    [TestFixture]
    public  class VillaRepo_updatedTestcases
    {
        private ApplicationDbContext _context;
        private Repository<Villa> _repository;
        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            _context = new ApplicationDbContext(options);
            _repository=new Repository<Villa>(_context);
            _context.Villas.AddRange(new List<Villa>
            {
                new Villa { Id = 1, Name = "Villa1", Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = "" },
                new Villa { Id = 2, Name = "Villa2",
                 Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = ""}
            });
            _context.SaveChanges();

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task CreateAsync_AddsEntityToDatabase()
        {
            var entity = new Villa
            {
                Id = 2000,
                Name = "test",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = "",
            };
            await _repository.CreateAsync(entity);
            var result = await _repository.GetAsync(v => v.Id == entity.Id);
            Assert.That(result.Name, Is.EqualTo("test"));


        }
        [Test]
        public async Task GetAsync_WithValidFilter_ReturnsEntity()
        {
            // Act
            var result = await _repository.GetAsync(v => v.Id == 1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That("Villa1",Is.EqualTo(result.Name));

        }

    }
}
