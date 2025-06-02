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

        /// <summary>
        /// Tests that the AddElevator method adds an elevator to the building.
        /// This test verifies that when an elevator is added to the building, it is included in the list of elevators.
        /// </summary>
        /// <remarks>
        /// This test is essential to ensure that the building can manage its elevators correctly.
        /// It checks that the AddElevator method works as expected and that the elevator is successfully added to the building's collection.
        /// </remarks>
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

        /// <summary>
        /// Tests that the constructor throws an exception when a non-positive number of floors is provided.
        /// This test verifies that the Building class correctly validates the number of floors during initialization.
        /// </summary>
        /// <remarks>
        /// This test is essential to ensure that the Building class enforces its constraints on the number of floors.
        /// It checks that an exception is thrown when the number of floors is zero or negative, preventing the creation of an invalid building instance.
        /// </remarks>
        [Fact]
        public void Constructor_NonPositiveNumberOfFloors_ThrowsException()
        {
            // Arrange & Act & Assert            
            Assert.Throws<ArgumentException>(() => new Building(0));
        }

        /// <summary>
        /// Tests that the GetNumberOfFloors method returns a correct number of floors.
        /// This test verifies that the number of floors set in the constructor is correctly returned by the GetNumberOfFloors method.
        /// </summary>
        /// <remarks>
        /// This test is essential to ensure that the building's structure is correctly initialized and that the GetNumberOfFloors method behaves as expected.
        /// It checks that the number of floors returned matches the value provided during the building's construction.
        /// </remarks>
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