using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MagicVilla_VillaAPI.Controllers;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace NUnitTests_for_MagicVilla.Repository_testcases
{
    [TestFixture]
    public class VillaAPIControllerTests
    {
        private Mock<IVillaRespository> _mockrepo;
        private Mock<IMapper> _mockmapper;
        private VillaAPIController _controller;
        [SetUp]
        public void SetUp()
        {
            _mockrepo = new Mock<IVillaRespository>();
            _mockmapper = new Mock<IMapper>();
            _controller = new VillaAPIController(_mockrepo.Object, _mockmapper.Object);
        }
        [Test]
        public async Task GetVillas_ReturnsOKResult()
        {
           var  villas = new List<Villa> { new Villa
            {
                Id = 1,
                 Name = "pavithra villa",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                Sqft = 700,
                Amenity = "",
            },new Villa {
                Id=2,
                 Name = "sreeja  villa",
                Details = "foop  bio ajokbhOZOP vihilknknkl dofinsion",
                ImageUrl = "",
                Occupancy = 5,
                Rate = 1200,
                Sqft = 700,
                Amenity = "",
                      } };
            var villaDTos = new List<VillaDTO> { new VillaDTO
            {
                Id = 1,
                 Name = "pavithra villa1",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                sqft = 700,
                Amenity = "",
            },new VillaDTO{
                Id=2,
                 Name = "sreeja  villa1",
                Details = "foop  bio ajokbhOZOP vihilknknkl dofinsion",
                ImageUrl = "",
                Occupancy = 5,
                Rate = 1200,
                sqft = 700,
                Amenity = "",
                      } };
    _mockrepo.Setup(   x=>x.GetAllAsync(null)).ReturnsAsync(villas);
     _mockmapper.Setup(mapper=>mapper.Map<List<VillaDTO>>(villas)).Returns(villaDTos);

            var result = await _controller.GetVillas();
            var okresult=result.Result  as OkObjectResult;
            
            Assert.That(StatusCodes.Status200OK,
                Is.EqualTo(okresult.StatusCode));
            Assert.That(villaDTos, Is.Not.Null);
            
        }

        [Test]
        public async Task GetVillabyId_ReturnsOKResult()
        {
            var villa = new Villa
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
            var villaDTos =  new VillaDTO
            {
                Id = 1,
                 Name = "pavithra villa1",
                Details = "foop  bio ajokp smopkpk dofinsion",
                ImageUrl = "",
                Occupancy = 4,
                Rate = 1200,
                sqft = 700,
                Amenity = "",
             };
          //  _mockrepo.Setup(x => x.GetAsyncnull)).ReturnsAsync(villa);
            _mockrepo.Setup(x => x.GetAsync(v => v.Id == 1,true)).ReturnsAsync(villa);
            _mockmapper.Setup(mapper => mapper.Map<VillaDTO>(villa)).Returns(villaDTos);

            var result = await _controller.GetVilla(1);
            var okresult = result.Result as OkObjectResult;

            Assert.That(StatusCodes.Status200OK,
                Is.EqualTo(okresult.StatusCode));
            Assert.That(villaDTos, Is.Not.Null);

        }
        [Test]
        public async Task CreateVilla_withValidData_returnssCreatedResult()
        {
            var createDTO = new VillaCreateDTO { Name = "Villa1" };
            var villa = new Villa { Id = 1, Name = "Villa1" };
            var villaDTO = new VillaDTO { Id = 1, Name = "Villa1" };
            _mockrepo.Setup(repo => repo.GetAsync(v => v.Name.ToLower() == createDTO.Name.ToLower(),true)).ReturnsAsync((Villa)null);
            _mockrepo.Setup(repo=>repo.CreateAsync(It.IsAny<Villa>())).Returns(Task.CompletedTask);
            _mockmapper.Setup(mapper => mapper.Map<Villa>(createDTO)).Returns(villa);
            _mockmapper.Setup(mapper => mapper.Map<VillaDTO>(villa)).Returns(villaDTO);
            var result=await _controller.CreateVilla(createDTO);
            var createdResult = result.Result as CreatedAtRouteResult;
            Assert.That(StatusCodes.Status201Created,
                           Is.EqualTo(createdResult.StatusCode));
            Assert.That(villaDTO, Is.EqualTo(((APIResponse)createdResult.Value).Result));

        }
        [Test]
        public async Task DeleteVilla_WithValid_ReturnsNOContent()
        {
            var villa = new Villa { Id = 1, Name = "Villa1" };
            _mockrepo.Setup(repo => repo.GetAsync(v => v.Id==1,true)).ReturnsAsync((villa));
            _mockrepo.Setup(repo=>repo.RemoveAsync(villa)).Returns(Task.CompletedTask);
            var result = await _controller.DeleteVilla(1);
            var okResult=result.Result as OkObjectResult;
            Assert.That(StatusCodes.Status200OK,Is.EqualTo(okResult.StatusCode));
        }
        [Test]
        public async  Task DeleteVillawithInvalidId_ReturnNotFound()
        {
            _mockrepo.Setup(repo => repo.GetAsync(v => v.Id == 1,true)).ReturnsAsync((Villa)null);
            var result=await _controller.DeleteVilla(1);
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
          
           
        }
    }
    
}
