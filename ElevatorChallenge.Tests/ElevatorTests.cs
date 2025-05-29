using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Unit tests for the Elevator class.
    /// This class uses AutoFixture to generate test data and validate the functionality of the Elevator class.
    /// It includes tests for the constructor, moving to floors, adding/removing passengers, and getting elevator status.
    /// The tests ensure that the Elevator class behaves correctly under various conditions and handles edge cases appropriately.
    /// Each test method is designed to validate a specific aspect of the Elevator class, such as ensuring that the constructor sets properties correctly,
    /// moving to valid and invalid floors, adding and removing passengers, and retrieving the elevator's status.
    /// The tests also check for exceptions when invalid parameters are provided, such as non-positive capacity or max floors,
    /// ensuring that the Elevator class adheres to its contract and behaves as expected.
    /// This class serves as a comprehensive suite of tests for the Elevator class, ensuring its reliability and correctness.
    /// </summary>
    /// <remarks>
    /// This class is a unit test suite for the Elevator class.
    /// It uses the AutoFixture library to generate test data and validate the functionality of the Elevator class.
    /// The tests cover various scenarios, including valid and invalid parameters, moving to different floors,
    /// adding and removing passengers, and checking the elevator's status.
    /// Each test method is designed to ensure that the Elevator class behaves correctly and handles edge cases appropriately.
    /// The tests also check for exceptions when invalid parameters are provided, such as non-positive capacity or max floors,
    /// ensuring that the Elevator class adheres to its contract and behaves as expected.
    /// This class serves as a comprehensive suite of tests for the Elevator class, ensuring its reliability and correctness.
    /// </remarks>
    public class ElevatorTests
    {
        /// <summary>
        /// Fixture for generating test data.
        /// This fixture is used to create instances of the Elevator class with valid parameters for testing.
        /// It uses AutoFixture to generate random values for the elevator's ID, capacity, and maximum number of floors.
        /// This fixture can be used in other test methods to create instances of the Elevator class with the desired parameters.
        /// </summary>
        private readonly Fixture _fixture;

        /// <summary>
        /// Initializes a new instance of the ElevatorTests class.
        /// This constructor sets up the fixture for generating test data.
        /// It customizes the fixture to create an Elevator instance with valid parameters,
        /// ensuring that the ID is an integer, capacity is a positive integer, and maxFloors is a positive integer.
        /// The fixture can be used in the test methods to create instances of the Elevator class with the desired parameters.
        /// </summary>       
        public ElevatorTests()
        {
            _fixture = new Fixture();
            // Customize the fixture to create an Elevator instance with valid parameters
            _fixture.Customize<IElevator>(c => c.FromFactory(() => new Elevator(_fixture.Create<int>(), Math.Abs(_fixture.Create<int>()) + 1, Math.Abs(_fixture.Create<int>()) + 1)));
        }

        /// <summary>
        /// Tests the constructor of the Elevator class with valid parameters.
        /// This test verifies that the constructor sets the properties correctly,
        /// including the ID, elevator type, current floor, direction, moving status, and passenger count.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class can be instantiated with valid parameters,
        /// and that the properties are set correctly. It checks that the ID is assigned,
        /// the elevator type is set to "Elevator", the current floor is initialized to 1,
        /// the direction is set to "None", the moving status is false, and the passenger count is initialized to 0.
        /// This test is essential to ensure that the Elevator class behaves correctly when created with valid parameters.
        /// </remarks>
        [Fact]
        public void Constructor_ValidParameters_SetsProperties()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var maxFloors = _fixture.Create<int>() % 50 + 1; // Ensure maxFloors is positive

            // Act            
            var elevator = new Elevator(id, capacity, maxFloors);

            // Assert
            Assert.Equal(id, elevator.Id);
            Assert.Equal(nameof(Elevator), elevator.ElevatorType);

            var status = elevator.GetStatus();

            Assert.Equal(1, status.CurrentFloor);
            Assert.Equal("None", status.Direction);
            Assert.False(status.IsMoving);
            Assert.Equal(0, status.PassengerCount);
        }

        /// <summary>
        /// Tests the constructor of the Elevator class with non-positive capacity.
        /// This test verifies that an ArgumentException is thrown when the capacity is not a positive integer.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the capacity must be a positive integer.
        /// It checks that when a non-positive capacity is provided, an ArgumentException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void Constructor_NonPositiveCapacity_ThrowsArgumentException()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var maxFloors = _fixture.Create<int>() % 50 + 1; // Ensure maxFloors is positive
            var invalidCapcity = _fixture.Create<int>() % 10 * -1; // Negative or zero capacity

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Elevator(id, invalidCapcity, maxFloors));
            Assert.Equal("Capacity must be a positive integer.", exception.Message);
        }

        /// <summary>
        /// Tests the constructor of the Elevator class with non-positive maximum floors.
        /// This test verifies that an ArgumentException is thrown when the maximum number of floors is not a positive integer.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the maximum number of floors must be a positive integer.
        /// It checks that when a non-positive maximum number of floors is provided, an ArgumentException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void Constructor_NonPositiveMaxFloors_ThrowsArgumentException()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var invalidMaxFloors = _fixture.Create<int>() % 10 * -1; // Negative or zero maxFloors

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Elevator(id, capacity, invalidMaxFloors));
            Assert.Equal("Max floors must be a positive integer.", exception.Message);
        }

        /// <summary>
        /// Tests moving the elevator to a valid floor above the current floor.
        /// This test verifies that the elevator correctly updates its current floor and direction when moving to a higher floor.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class can move to a valid floor above the current floor.
        /// It checks that when a valid target floor is provided, the elevator updates its current floor to the target floor,
        /// sets the direction to "Up", and marks itself as moving.
        /// This is essential to ensure that the Elevator class behaves correctly when moving to a higher floor.
        /// </remarks>
        [Fact]
        public void MoveToFloor_ValidFloorAboveCurrent_SetsFloorAndDirectionUp()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var status = elevator.GetStatus();
            var targetFloor = status.CurrentFloor + (_fixture.Create<int>() % (status.CurrentFloor - 1)) + 2; // Ensure target floor is above current floor

            // Act
            elevator.MoveToFloor(targetFloor);

            // Assert
            status = elevator.GetStatus();
            Assert.Equal(targetFloor, status.CurrentFloor);
            Assert.Equal("Up", status.Direction);
            Assert.True(status.IsMoving); // IsMoving should be true after moving to a new floor                     
        }

        /// <summary>
        /// Tests moving the elevator to a valid floor below the current floor.
        /// This test verifies that the elevator correctly updates its current floor and direction when moving to a lower floor.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class can move to a valid floor below the current floor.
        /// It checks that when a valid target floor is provided, the elevator updates its current floor to the target floor,
        /// sets the direction to "Down", and marks itself as moving.
        /// This is essential to ensure that the Elevator class behaves correctly when moving to a lower floor.
        /// </remarks>
        [Fact]
        public void MoveToFloor_ValidFloorBelowCurrent_SetsFloorAndDirectionDown()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            elevator.MoveToFloor(5); // Move to a known floor first

            var targetFloor = _fixture.Create<int>() % 4 + 1; // Ensure target floor is below current floor (which is 5)

            // Act
            elevator.MoveToFloor(targetFloor);

            // Assert
            var status = elevator.GetStatus();
            Assert.Equal(targetFloor, status.CurrentFloor);
            Assert.Equal("Down", status.Direction);
            Assert.True(status.IsMoving); // IsMoving should be true after moving to a new floor
        }

        /// <summary>
        /// Tests moving the elevator to the same floor it is currently on.
        /// This test verifies that the elevator correctly sets its direction to "None" and does not change its current floor.
        /// This test ensures that the Elevator class behaves correctly when moving to the same floor it is already on.
        /// It checks that when the target floor is the same as the current floor, the elevator does not change its current floor,
        /// sets the direction to "None", and marks itself as not moving.
        /// This is essential to ensure that the Elevator class behaves correctly when no movement is required.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class behaves correctly when moving to the same floor it is already on.
        /// It checks that when the target floor is the same as the current floor, the elevator does not change its current floor,
        /// sets the direction to "None", and marks itself as not moving.
        /// This is essential to ensure that the Elevator class behaves correctly when no movement is required.
        /// </remarks>
        [Fact]
        public void MoveToFloor_SameFloor_SetsDirectionNone()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var status = elevator.GetStatus();
            var currentFloor = status.CurrentFloor; // Get the current floor

            // Act
            elevator.MoveToFloor(currentFloor);

            // Assert
            status = elevator.GetStatus();

            Assert.Equal(currentFloor, status.CurrentFloor);
            Assert.Equal("None", status.Direction);
            Assert.False(status.IsMoving); // IsMoving should be false when not moving
        }

        /// <summary>
        /// Tests moving the elevator to a floor below one, which is invalid.
        /// This test verifies that an ArgumentOutOfRangeException is thrown when trying to move to a floor below one.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the floor number must be at least one.
        /// It checks that when an invalid floor (below one) is provided, an ArgumentOutOfRangeException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void MoveToFloor_FloorBelowOne_ThrowsArgumentException()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var invalidFloor = 0; // Floor below one is invalid

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => elevator.MoveToFloor(invalidFloor));
            Assert.Equal("Floor must be between 1 and", exception.Message);
        }

        /// <summary>
        /// Tests moving the elevator to a floor above the maximum number of floors.
        /// This test verifies that an ArgumentException is thrown when trying to move to a floor above the maximum number of floors.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the floor number must be within the range of valid floors.
        /// It checks that when an invalid floor (above the maximum number of floors) is provided, an ArgumentException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void MoveToFloor_FloorAboveMaxFloors_ThrowsArgumentException()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var maxFloors = _fixture.Create<int>() % 50 + 1; // Ensure maxFloors is positive
            var invalidFloor = maxFloors + 1; // Floor above maxFloors is invalid

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Elevator(_fixture.Create<int>(), _fixture.Create<int>() % 100 + 1, maxFloors).MoveToFloor(invalidFloor));
            Assert.Contains($"Floor must be between 1 and {maxFloors}", exception.Message);
        }

        /// <summary>
        /// Tests adding passengers to the elevator with a valid count that does not exceed capacity.
        /// This test verifies that the passenger count increases correctly when adding a valid number of passengers.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class can add passengers without exceeding its capacity.
        /// It checks that when a valid number of passengers is added, the passenger count increases correctly.
        /// This is essential to ensure that the Elevator class behaves correctly when adding passengers and does not exceed its capacity.
        /// </remarks>
        [Fact]
        public void AddPassengers_ValidCountWithCapacity_IncreasesPassengerCount()
        {
            // Arrange            
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var elevatorWithKnownCapacity = new Elevator(_fixture.Create<int>(), capacity, _fixture.Create<int>() % 50 + 1); // Create elevator with known capacity
            var passengersToAdd = _fixture.Create<int>() % (capacity / 2) + 1; // Ensure passengers to add is less than capacity

            // Act
            elevatorWithKnownCapacity.AddPassengers(passengersToAdd);

            // Assert
            var status = elevatorWithKnownCapacity.GetStatus();
            Assert.Equal(passengersToAdd, status.PassengerCount); // Passenger count should increase by the number of passengers added
        }

        /// <summary>
        /// Tests adding passengers to the elevator exceeding its capacity.
        /// This test verifies that an InvalidOperationException is thrown when trying to add passengers that exceed the elevator's capacity.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the number of passengers must not exceed its capacity.
        /// It checks that when an attempt is made to add passengers that exceed the capacity, an InvalidOperationException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow exceeding its capacity.
        /// </remarks>
        [Fact]
        public void AddPassengers_ExceedingPassengerCapacity_ThrowsInvalidOperationException()
        {
            // Arrange
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var elevatorWithKnownCapacity = new Elevator(_fixture.Create<int>(), capacity, _fixture.Create<int>() % 50 + 1); // Create elevator with known capacity
            var passengersToAdd = capacity + 1; // Exceeding the capacity

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => elevatorWithKnownCapacity.AddPassengers(passengersToAdd));
            Assert.Equal("Cannot add passengers: exceeds capacity.", exception.Message);
        }

        /// <summary>
        /// Tests adding passengers to the elevator with a negative count.
        /// This test verifies that an ArgumentOutOfRangeException is thrown when trying to add a negative number of passengers.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the number of passengers must be a positive integer.
        /// It checks that when a negative count is provided, an ArgumentOutOfRangeException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void AddPassengers_NegativeCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var negativeCount = _fixture.Create<int>() % 10 * -1 - 1; // Negative count

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => elevator.AddPassengers(negativeCount));
            Assert.Equal("Passenger count must be positive.", exception.Message);
        }

        /// <summary>
        /// Tests removing passengers from the elevator with a valid count that does not exceed current passengers.
        /// This test verifies that the number of passengers in the elevator decreases correctly when removing passengers.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class can remove passengers without going below zero.
        /// It checks that when a valid number of passengers is removed, the passenger count decreases correctly.
        /// This is essential to ensure that the Elevator class behaves correctly when removing passengers and does not allow negative passenger counts.
        /// </remarks>
        [Fact]
        public void RemovePassengers_ValidPassengerCountWithinCurrent_DecreasesPassengerCount()
        {
            // Arrange           
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var elevatorWithKnownCapacity = new Elevator(_fixture.Create<int>(), capacity, _fixture.Create<int>() % 50 + 1); // Create elevator with known capacity
            var initialPassengers = _fixture.Create<int>() % (capacity / 2) + 1; // Ensure initial passengers is less than capacity

            elevatorWithKnownCapacity.AddPassengers(initialPassengers); // Add initial passengers

            var passengersToRemove = _fixture.Create<int>() % initialPassengers + 1; // Ensure passengers to remove is less than or equal to initial passengers

            // Act
            elevatorWithKnownCapacity.RemovePassengers(passengersToRemove);

            // Assert
            var status = elevatorWithKnownCapacity.GetStatus();
            Assert.Equal(initialPassengers - passengersToRemove, status.PassengerCount); // Passenger count should decrease by the number of passengers removed
        }

        /// <summary>
        /// Tests removing passengers from the elevator with more than current passengers.
        /// This test verifies that an InvalidOperationException is thrown when trying to remove more passengers than currently in the elevator.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the number of passengers cannot go below zero.
        /// It checks that when an attempt is made to remove more passengers than currently in the elevator, an InvalidOperationException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow negative passenger counts.
        /// </remarks>
        [Fact]
        public void RemovePassengers_MoreThanCurrentPassengers_ThrowsInvalidOperationException()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var initialPassengers = _fixture.Create<int>() % 5 + 1; // Ensure initial passengers is positive

            elevator.AddPassengers(initialPassengers); // Add initial passengers

            var passengersToRemove = initialPassengers + 1; // More than current passengers

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => elevator.RemovePassengers(passengersToRemove));
            Assert.Equal("Cannot remove passengers: not enough passengers.", exception.Message);
        }

        /// <summary>
        /// Tests removing passengers from the elevator with a negative count.
        /// This test verifies that an ArgumentOutOfRangeException is thrown when trying to remove a negative number of passengers.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class enforces the contract that the number of passengers must be a positive integer.
        /// It checks that when a negative count is provided, an ArgumentOutOfRangeException is thrown with the appropriate message.
        /// This is essential to ensure that the Elevator class behaves correctly and does not allow invalid parameters.
        /// </remarks>
        [Fact]
        public void RemovePassengers_NegativeCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
            var negativeCount = _fixture.Create<int>() % 10 * -1 - 1; // Negative count

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => elevator.RemovePassengers(negativeCount));
            Assert.Equal("Passenger count must be positive.", exception.Message);
        }

        /// <summary>
        /// Tests getting the status of the elevator after multiple operations.
        /// This test verifies that the status reflects the current floor, direction, moving status, and passenger count correctly after moving and adding passengers.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class correctly updates its status after performing multiple operations.
        /// It checks that after moving to a target floor and adding passengers,the status reflects the current floor, direction, moving status, and passenger count correctly.
        /// This is essential to ensure that the Elevator class behaves correctly and provides accurate status information.
        /// </remarks>
        [Fact]
        public void GetStatus_AfterMultipleOperations_ReturnsCorrectStatus()
        {
            // Arrange           
            var capacity = _fixture.Create<int>() % 100 + 1; // Ensure capacity is positive
            var maxFloors = _fixture.Create<int>() % 50 + 1; // Ensure maxFloors is positive
            var elevatorWithKnownParameters = new Elevator(_fixture.Create<int>(), capacity, maxFloors); // Create elevator with known parameters
            var targetFloor = _fixture.Create<int>() % (maxFloors - 1) + 2; // Ensure target floor is above current floor
            var passengersToAdd = _fixture.Create<int>() % (capacity / 2) + 1; // Ensure passengers to add is less than capacity

            elevatorWithKnownParameters.MoveToFloor(targetFloor); // Move to a known floor
            elevatorWithKnownParameters.AddPassengers(passengersToAdd); // Add passengers

            // Act
            var status = elevatorWithKnownParameters.GetStatus();

            // Assert
            Assert.Equal(targetFloor, status.CurrentFloor); // Current floor should be the target floor
            Assert.Equal("Up", status.Direction); // Direction should be "Up" after moving to a higher floor
            Assert.False(status.IsMoving); // IsMoving should be false after reaching the target floor
            Assert.Equal(passengersToAdd, status.PassengerCount); // Passenger count should match the number of passengers added
        }

        /// <summary>
        /// Tests getting the status of the elevator in its initial state.
        /// This test verifies that the status reflects the default values for current floor, direction, moving status, and passenger count.
        /// </summary>
        /// <remarks>
        /// This test ensures that the Elevator class initializes its status correctly when first created.
        /// It checks that the initial status reflects the default values: the current floor is 1, direction is "None", moving status is false, and passenger count is 0.
        /// This is essential to ensure that the Elevator class behaves correctly when first instantiated.
        /// </remarks>
        [Fact]
        public void GetStatus_InitialState_ReturnsDefaultStatus()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();

            // Act
            var status = elevator.GetStatus();

            // Assert
            Assert.Equal(1, status.CurrentFloor); // Default current floor should be 1
            Assert.Equal("None", status.Direction); // Default direction should be "None"
            Assert.False(status.IsMoving); // Default IsMoving should be false
            Assert.Equal(0, status.PassengerCount); // Default passenger count should be 0
        }
    }
}