using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinalExercise.Data;
using FinalExercise.Domain.Interfaces;
using FinalExercise.DTOs;
using FinalExercise.Repositories;
using FinalExercise.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinalExercise.UnitTesting
{
    public class CommissionServiceTest
    {
        ICommissionService _commissionService;

        public CommissionServiceTest()
        {
            var options = new DbContextOptionsBuilder<FinalExerciseContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            var context = new FinalExerciseContext(options);

            DataDBInitializer dataDBInitializer = new DataDBInitializer();
            dataDBInitializer.Seed(context);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            IUnitOfWork unitOfWork = new UnitOfWork(context, new ClientRepository(context), new ProductRepository(context), new TravelPackageRepository(context), new CommissionRepository(context));

            _commissionService = new CommissionService(unitOfWork, mapper);
        }

        [Fact]
        public async Task AddCommissionTest_WithUnexistingClient_ReturnsNotFound()
        {

            //Arrange            
            var commissionRequest = new CommissionRequestDTO()
            {
                ClientTypeId = 16,      // Unexisting client
                PassengersAmmount = 4,
                TripDuration = 4,
                TravelPackages = new List<int> { 1, 2, 3 }
            };

            //Act
            var notFoundResponse = await _commissionService.AddCommission(commissionRequest);

            //Assert
            Assert.IsType<ServiceResponse>(notFoundResponse);

            Assert.Equal("NotFound", notFoundResponse.Message);
            Assert.False(notFoundResponse.Success);
        }

        [Fact]
        public async Task AddCommissionTest_ValidObjectPassed_ReturnsCreatedResponse()
        {

            //Arrange
            var commissionRequest = new CommissionRequestDTO()
            {
                ClientTypeId = 1,
                PassengersAmmount = 4,
                TripDuration = 4,
                TravelPackages = new List<int> { 1, 2, 3 }
            };

            //Act
            var validResponse = await _commissionService.AddCommission(commissionRequest);

            //Assert
            Assert.IsType<ServiceResponse>(validResponse);

            Assert.Equal("Ok", validResponse.Message);
            Assert.True(validResponse.Success);
        }

        [Fact]
        public async Task AddCommissionTest_PassengerAmmountOutOfRange_ReturnsBadRequest()
        {

            //Arrange
            var commissionRequest = new CommissionRequestDTO()
            {
                ClientTypeId = 1,
                PassengersAmmount = 20,
                TripDuration = 4,
                TravelPackages = new List<int> { 1, 2, 3 }
            };

            //Act
            var badResponse = await _commissionService.AddCommission(commissionRequest);

            //Assert
            Assert.IsType<ServiceResponse>(badResponse);

            Assert.Equal("BadRequest", badResponse.Message);
            Assert.False(badResponse.Success);
        }

        [Fact]
        public async Task AddCommissionTest_TripDurationOutOfRange_ReturnsBadRequest()
        {

            //Arrange
            var commissionRequest = new CommissionRequestDTO()
            {
                ClientTypeId = 1,
                PassengersAmmount = 5,
                TripDuration = 100,
                TravelPackages = new List<int> { 1, 2, 3 }
            };

            //Act
            var badResponse = await _commissionService.AddCommission(commissionRequest);

            //Assert
            Assert.IsType<ServiceResponse>(badResponse);

            Assert.Equal("BadRequest", badResponse.Message);
            Assert.False(badResponse.Success);
        }
    }
}

