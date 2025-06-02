using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace ElevatorChallenge.Tests
{
    /// <summary>
    /// Unit tests for the FreightElevator class.
    /// This class tests the functionality of the FreightElevator, ensuring it correctly handles freight-specific operations.
    /// It uses the NSubstitute library for mocking dependencies and AutoFixture for generating test data.
    /// </summary>
    public class FreightElevatorTests
    {
        private readonly IElevator _freightElevator;
        private readonly Fixture _fixture;

        public FreightElevatorTests()
        {
            _freightElevator = Substitute.For<IElevator>();
            _fixture = new Fixture();
        }

        [Fact]
        public void FreightElevator_RestrictedFloor_ThrowsException()
        {
            // Arrange
            var restrictedFloor = _fixture.Create<int>();
            var elevator = new FreightElevator(1, 100, restrictedFloor);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => elevator.MoveToFloor(restrictedFloor));
        }

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