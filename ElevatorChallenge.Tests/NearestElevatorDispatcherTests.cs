using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using ElevatorChallenge.Application;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Unit tests for the NearestElevatorDispatcher class.
    /// This class tests the functionality of the NearestElevatorDispatcher, ensuring it correctly dispatches elevators based on floor requests.
    /// It uses the NSubstitute library for mocking dependencies and AutoFixture for generating test data.
    /// </summary>
    /// <remarks>
    /// This class contains tests for the NearestElevatorDispatcher, which is responsible for finding the nearest elevator to handle a floor request.
    /// The tests cover scenarios such as dispatching an elevator with a heavy load preference for freight elevators and handling cases where no elevators are available.
    /// The tests ensure that the dispatcher behaves correctly under different conditions, providing confidence in its functionality.
    /// </remarks>
    public class NearestElevatorDispatcherTests
    {
        private readonly IFixture _fixture;
        private readonly IBuilding _building;
        private readonly IElevator _standardElevator;
        private readonly IElevator _freightElevator;
        private readonly NearestElevatorDispatcher _dispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="NearestElevatorDispatcherTests"/> class.
        /// This constructor sets up the necessary dependencies for testing the NearestElevatorDispatcher.
        /// It uses the NSubstitute library to create a mock implementation of the IBuilding interface,
        /// and AutoFixture to generate test data for the floor requests.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the test environment by creating a mock building and a dispatcher instance.
        /// It prepares the necessary components for testing the functionality of the NearestElevatorDispatcher.
        /// The mock building is used to simulate the behavior of a real building without needing a full implementation,
        /// allowing for isolated unit tests that focus on the dispatcher logic.
        /// </remarks>
        public NearestElevatorDispatcherTests()
        {
            _fixture = new Fixture();
            _building = Substitute.For<IBuilding>();
            _dispatcher = new NearestElevatorDispatcher(_building);
            _standardElevator= Substitute.For<IElevator>();
            _freightElevator = Substitute.For<IElevator>();
        }

        /// <summary>
        /// Tests the <see cref="NearestElevatorDispatcher.DispatchElevator"/> method to ensure
        /// it throws an <see cref="InvalidOperationException"/> when there are no elevators available.
        /// </summary>
        /// <remarks>
        /// This test verifies that the dispatcher correctly handles the scenario where the building
        /// has no elevators by throwing an appropriate exception. It uses a mocked <see cref="IBuilding"/>
        /// implementation that returns an empty list of elevators.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to dispatch an elevator in a building with no elevators.
        /// </exception>        
        [Fact]
        public void DispatchElevator_NoElevators_ThrowsException()
        {
            // Arrange
            _building.GetElevators().Returns(new List<IElevator>());
            var request = _fixture.Create<FloorRequest>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _dispatcher.DispatchElevator(request));
        }

        /// <summary>
        /// Tests the <see cref="NearestElevatorDispatcher.DispatchElevator"/> method to ensure
        /// it returns the nearest elevator based on the current floor and requested floor.
        /// </summary>
        /// <remarks>
        /// This test verifies that the dispatcher correctly identifies the nearest elevator to the requested floor.
        /// It uses mocked elevators with predefined current floors to simulate the scenario.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no suitable elevator is found or no elevators are available.
        /// </exception>
        [Fact]
        public void DispatchElevator_HeavyLoad_PrefersFreight()
        {
            // Arrange            
            _standardElevator.ElevatorType.Returns(nameof(Elevator));
            _freightElevator.ElevatorType.Returns(nameof(FreightElevator));

            _standardElevator.GetStatus().Returns(new ElevatorStatus { CurrentFloor = 3 });
            _freightElevator.GetStatus().Returns(new ElevatorStatus { CurrentFloor = 5 });

            _building.GetElevators().Returns(new List<IElevator> { _standardElevator, _freightElevator });

            var dispatcher = new NearestElevatorDispatcher(_building);
            var request = new FloorRequest { Floor = 4, PassengerCount = 150 };

            // Act
            var result = dispatcher.DispatchElevator(request);

            // Assert
            Assert.Equal(_freightElevator, result);
        }
    }
}