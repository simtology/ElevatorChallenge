using ElevatorChallenge.Application;
using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Tests for the ElevatorController class.
    /// This class contains unit tests for the ElevatorController methods, ensuring that the controller behaves as expected
    /// when handling elevator requests and statuses.
    /// It uses the Xunit testing framework and NSubstitute for mocking dependencies.
    /// The tests cover various scenarios, including valid requests, invalid floor requests, and elevator status retrieval.
    /// </summary>
    /// <remarks>
    /// The ElevatorControllerTests class is designed to validate the functionality of the ElevatorController class.
    /// It includes tests for the RequestElevator method, which checks if the controller correctly dispatches elevators based on valid requests,
    /// and handles exceptions for invalid requests such as out-of-range floors or negative passenger counts.
    /// Additionally, it tests the GetElevatorStatus method to ensure that it retrieves the correct status for valid elevator IDs and throws exceptions for invalid IDs.
    /// The tests are structured to ensure that the ElevatorController behaves correctly under various conditions,
    /// making use of the NSubstitute library to mock dependencies like IElevatorDispatcher and IBuilding.
    /// </remarks>
    /// <example>
    /// For example, the RequestElevator_ValidRequest_DispatchesElevator test verifies that when a valid request is made to the controller,
    /// the appropriate methods on the mocked IElevatorDispatcher and IBuilding are called, ensuring that the elevator is dispatched correctly 
    /// to the requested floor with the specified number of passengers.
    /// Similarly, the GetElevatorStatus_ValidId_ReturnsStatus test checks that when a valid elevator ID is requested,
    /// the controller returns the expected ElevatorStatus object, confirming that the controller accurately reflects the state of the elevator.
    /// </example>
    public class ElevatorControllerTests
    {
        private readonly IElevatorController _controller;
        private readonly IElevatorDispatcher _dispatcher;
        private readonly IBuilding _building;
        private readonly IElevator _elevator;
        private readonly Fixture _fixture;

        /// <summary>
        /// Constructor for ElevatorControllerTests.
        /// Initializes the ElevatorController with mocked dependencies using NSubstitute.
        /// This constructor sets up the necessary components for testing the ElevatorController class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create an instance of the ElevatorControllerTests class.
        /// It initializes the IElevatorDispatcher and IBuilding interfaces using NSubstitute,
        /// allowing for the simulation of elevator dispatching and building management without requiring actual implementations.
        /// The ElevatorController instance is created with these mocked dependencies, enabling the testing of its methods in isolation.
        /// The IElevator instance is also mocked to simulate elevator behavior during tests.
        /// </remarks>
        public ElevatorControllerTests()
        {
            _dispatcher = Substitute.For<IElevatorDispatcher>();
            _building = Substitute.For<IBuilding>();
            _controller = new ElevatorController(_dispatcher, _building);
            _elevator = Substitute.For<IElevator>();
            _fixture = new Fixture();
        }

        /// <summary>
        /// Tests that the RequestElevator method correctly dispatches an elevator when a valid request is made. 
        /// This test verifies that the elevator moves to the requested floor and adds the specified number of passengers.         
        /// It uses NSubstitute to mock the IElevatorDispatcher and IBuilding interfaces,
        /// ensuring that the elevator's MoveToFloor and AddPassengers methods are called with the correct parameters.
        /// The test is designed to ensure that the elevator controller behaves as expected when handling a valid elevator request.         
        /// </summary>
        /// <remarks>
        /// This test is part of the ElevatorChallenge.Tests project and uses the Xunit testing framework.
        /// It is designed to validate the functionality of the ElevatorController class, specifically the RequestElevator method.         
        /// The test checks that when a request is made to the controller, the appropriate methods on the mocked IElevatorDispatcher and IBuilding are called, 
        /// ensuring that the elevator is dispatched correctly to the requested floor with the specified number of passengers.
        /// </remarks>
        [Fact]
        public void RequestElevator_ValidRequest_DispatchesElevator()
        {
            // Arrange          
            _building.GetNumberOfFloors().Returns(10);
            _dispatcher.DispatchElevator(Arg.Any<FloorRequest>()).Returns(_elevator);

            // Act
            _controller.RequestElevator(3, 2, "Up");

            // Assert
            _elevator.Received().MoveToFloor(3);
            _elevator.Received().AddPassengers(2);
        }

        /// <summary>
        /// Tests that the RequestElevator method throws an exception when an invalid floor is requested.
        /// This test verifies that the controller correctly handles requests for floors that are out of range,
        /// ensuring that an ArgumentOutOfRangeException is thrown when the requested floor exceeds the number of floors in the building.
        /// </summary>
        /// <remarks>
        /// This test is part of the ElevatorChallenge.Tests project and uses the Xunit testing framework.
        /// It is designed to validate the error handling of the ElevatorController class, specifically the RequestElevator method.
        /// The test checks that when a request is made to the controller for a floor that exceeds the building's number of floors,
        /// the appropriate exception is thrown, ensuring that the controller enforces valid floor requests.
        /// </remarks>
        /// <example>
        /// For example, if the building has 10 floors and a request is made for floor 11,
        /// the test will verify that an ArgumentOutOfRangeException is thrown, indicating that the requested floor is invalid.
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the requested floor is outside the valid range of floors in the building.
        /// </exception>
        [Fact]
        public void RequestElevator_InvalidFloor_ThrowsException()
        {
            // Arrange          
            _building.GetNumberOfFloors().Returns(10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _controller.RequestElevator(11, 2, "Up"));
        }

        /// <summary>
        /// Tests that the GetElevatorStatus method throws an exception when an invalid elevator ID is provided.
        /// This test verifies that the controller correctly handles requests for elevator statuses with IDs that are out of range,
        /// ensuring that an ArgumentOutOfRangeException is thrown when the elevator ID is invalid.
        /// </summary>
        /// <remarks>
        /// This test is part of the ElevatorChallenge.Tests project and uses the Xunit testing framework.
        /// It is designed to validate the error handling of the ElevatorController class, specifically the GetElevatorStatus method.
        /// The test checks that when a request is made to the controller for an elevator status with an invalid ID,
        /// the appropriate exception is thrown, ensuring that the controller enforces valid elevator IDs.
        /// </remarks>
        /// <example>
        /// For example, if an elevator ID of -1 is provided, the test will verify that an ArgumentOutOfRangeException is thrown,
        /// indicating that the elevator ID is invalid.
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the elevator ID is outside the valid range of elevator IDs in the building.
        /// </exception>
        [Fact]
        public void GetElevatorStatus_InvalidId_ThrowsException()
        {
            // Arrange
            int invalidId = -Math.Abs(_fixture.Create<int>()); // Using a negative ID to simulate an invalid elevator ID

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _controller.GetElevatorStatus(invalidId));
        }

        /// <summary>
        /// Tests that the GetElevatorStatus method returns the correct status for a valid elevator ID.
        /// This test verifies that the controller retrieves the status of an elevator when a valid ID is provided,
        /// ensuring that the status returned matches the expected ElevatorStatus object.
        /// </summary>
        /// <remarks>
        /// This test is part of the ElevatorChallenge.Tests project and uses the Xunit testing framework.
        /// It is designed to validate the functionality of the ElevatorController class, specifically the GetElevatorStatus method.
        /// The test checks that when a request is made to the controller for an elevator status with a valid ID,
        /// the correct ElevatorStatus object is returned, ensuring that the controller accurately reflects the state of the elevator.
        /// </remarks>
        /// <example>
        /// For example, if an elevator with ID 1 is requested,
        /// the test will verify that the status returned matches the expected ElevatorStatus object for that elevator,
        /// indicating that the controller correctly retrieves and returns elevator statuses.
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the elevator ID is outside the valid range of elevator IDs in the building.
        /// </exception>
        [Fact]
        public void GetElevatorStatus_ValidId_ReturnsStatus()
        {
            // Arrange           
            var elevatorId = _fixture.Create<int>();

            _elevator.Id.Returns(elevatorId);

            var expectedStatus = _fixture.Create<ElevatorStatus>();

            _elevator.GetStatus().Returns(expectedStatus);
            _building.AddElevator(_elevator);

            // Act
            var status = _controller.GetElevatorStatus(elevatorId);

            // Assert
            Assert.Equal(expectedStatus, status);
        }

        /// <summary>
        /// Tests that the RequestElevator method throws an exception when a negative number of passengers is requested.
        /// This test verifies that the controller correctly handles requests for elevators with a negative passenger count,
        /// ensuring that an ArgumentException is thrown when the passenger count is invalid.
        /// </summary>
        /// <remarks>
        /// This test is part of the ElevatorChallenge.Tests project and uses the Xunit testing framework.
        /// It is designed to validate the error handling of the ElevatorController class, specifically the RequestElevator method.
        /// The test checks that when a request is made to the controller for an elevator with a negative passenger count,
        /// the appropriate exception is thrown, ensuring that the controller enforces valid passenger counts.
        /// </remarks>
        /// <example>
        /// For example, if a request is made for -1 passengers,
        /// the test will verify that an ArgumentException is thrown, indicating that the passenger count is invalid.
        /// </example>
        /// <exception cref="ArgumentException">
        /// Thrown when the passenger count is negative or invalid.
        /// </exception>
        [Fact]
        public void RequestElevator_NegativePassengers_ThrowsException()
        {
            // Arrange
            _building.GetNumberOfFloors().Returns(10);
            _dispatcher.DispatchElevator(Arg.Any<FloorRequest>()).Returns(_elevator);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _controller.RequestElevator(3, -1, "Up"));
        }
    }
}