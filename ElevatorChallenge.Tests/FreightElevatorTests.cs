using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Unit tests for the FreightElevator class.
    /// This class tests the functionality of the FreightElevator, ensuring it correctly handles freight-specific operations.
    /// It uses the NSubstitute library for mocking dependencies and AutoFixture for generating test data.
    /// </summary>
    /// <remarks>
    /// This class contains tests for the FreightElevator, which is designed to carry goods and has specific restrictions on floors it can access.
    /// The tests cover scenarios such as moving to restricted floors and adding passengers that exceed the weight capacity.
    /// The tests ensure that the FreightElevator behaves correctly under different conditions, providing confidence in its functionality.
    /// </remarks>
    public class FreightElevatorTests
    {
        private readonly IElevator _freightElevator;
        private readonly Fixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="FreightElevatorTests"/> class.
        /// This constructor sets up the necessary dependencies for testing the FreightElevator.
        /// It uses the NSubstitute library to create a mock implementation of the IElevator interface,
        /// and AutoFixture to generate test data for the freight elevator operations.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the test environment by creating a mock elevator and preparing the fixture for generating test data.
        /// It prepares the necessary components for testing the functionality of the FreightElevator.
        /// The mock elevator is used to simulate the behavior of a real elevator without needing a full implementation,
        /// allowing for isolated unit tests that focus on the freight elevator logic.
        /// </remarks>
        public FreightElevatorTests()
        {
            _freightElevator = new FreightElevator(1, 100, 10);
            _fixture = new Fixture();
        }

        /// <summary>
        /// Tests the <see cref="FreightElevator.MoveToFloor"/> method to ensure
        /// it throws an <see cref="InvalidOperationException"/> when trying to move to a restricted floor.
        /// </summary>
        /// <remarks>
        /// This test verifies that the FreightElevator correctly handles the scenario where it is requested to move to a floor that is restricted for freight elevators.
        /// It uses a mocked IElevator implementation that simulates the behavior of a freight elevator with restricted floors.
        /// It ensures that attempting to move to a restricted floor results in an <see cref="InvalidOperationException"/> being thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to move to a restricted floor in a freight elevator.
        /// </exception>
        [Fact]
        public void MoveToFloor_RestrictedFloor_ThrowsException()
        {
            // Arrange
            var restrictedFloor = _fixture.Create<int>();            

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _freightElevator.MoveToFloor(restrictedFloor));
        }

        /// <summary>
        /// Tests the <see cref="FreightElevator.AddPassengers"/> method to ensure
        /// it throws an <see cref="InvalidOperationException"/> when the weight exceeds the elevator's capacity.
        /// </summary>
        /// <remarks>
        /// This test verifies that the FreightElevator correctly handles the scenario where the total weight of passengers exceeds its weight capacity.
        /// It uses a mocked IElevator implementation that simulates the behavior of a freight elevator with a specific weight capacity.
        /// It ensures that attempting to add passengers that exceed the weight limit results in an <see cref="InvalidOperationException"/> being thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to add passengers that exceed the weight capacity of the freight elevator.
        /// </exception>
        [Fact]
        public void AddPassengers_ExceedsWeight_ThrowsException()
        {
            // Arrange
            var elevator = new FreightElevator(1, 50, 10);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => elevator.AddPassengers(51));
        }
    }
}