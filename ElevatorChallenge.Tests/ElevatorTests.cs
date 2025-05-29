using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using System;
using Xunit;

namespace ElevatorChallenge.Tests
{
    public class ElevatorTests
    {
        private readonly Fixture _fixture;

        public ElevatorTests()
        {
            _fixture = new Fixture();
            // Customize the fixture to create an Elevator instance with valid parameters
            _fixture.Customize<IElevator>(c => c.FromFactory(() => new Elevator(_fixture.Create<int>(), Math.Abs(_fixture.Create<int>()) + 1, Math.Abs(_fixture.Create<int>()) + 1)));
        }

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

        [Fact]
        public void GetStatus_AfterMultipleOperations_ReturnsCorrectStatus()
        {
            // Arrange
            var elevator = _fixture.Create<Elevator>();
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