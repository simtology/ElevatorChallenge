using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace ElevatorChallenge.Tests
{
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
    }
}