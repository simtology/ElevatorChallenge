using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Unit tests for the Building class.
    /// This class tests the functionality of the Building class, including adding elevators and validating the number of floors.
    /// It uses the NSubstitute library for mocking dependencies and AutoFixture for generating test data.
    /// </summary>   
    public class BuildingTests
    {
        private readonly IElevator _elevator;
        private readonly Fixture _fixture;

        public BuildingTests()
        {
            _elevator = Substitute.For<IElevator>();
            _fixture = new Fixture();
        }

        [Fact]
        public void AddElevator_ValidElevator_AddsElevatorToBuilding()
        {
            // Arrange
            var numberOfFloors = _fixture.Create<int>();
            var building = new Building(numberOfFloors);

            // Act
            building.AddElevator(_elevator);

            // Assert
            Assert.Contains(_elevator, building.GetElevators());
        }

        [Fact]
        public void Constructor_NonPositiveNumberOfFloors_ThrowsException()
        {
            // Arrange & Act & Assert            
            Assert.Throws<ArgumentException>(() => new Building(0));
        }

        [Fact]
        public void GetNumberOfFloors_ReturnsCorrectNumberOfFloors()
        {
            // Arrange
            var numberOfFloors = _fixture.Create<int>();
            var building = new Building(numberOfFloors);

            // Act
            var result = building.GetNumberOfFloors();

            // Assert
            Assert.Equal(numberOfFloors, result);
        }
    }
}