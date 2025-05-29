using ElevatorChallenge.Core.Interfaces;
using System;

namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Represents an elevator in a building.
    /// This class implements the IElevator interface and provides methods to manage the elevator's state and operations.
    /// It allows moving to a specific floor, opening and closing doors, and checking if the elevator is idle.
    /// </summary>
    public class Elevator : IElevator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// This constructor sets the ID, capacity, and maximum number of floors for the elevator.
        /// </summary>       
        /// <param name="id">The unique identifier for the elevator.</param>
        /// <param name="capacity">The maximum number of passengers the elevator can carry.</param>
        /// <param name="maxFloors">The maximum number of floors the elevator can service.</param>
        /// <remarks>
        /// This constructor initializes the elevator with a specified ID, capacity, and maximum number of floors.
        /// It is used to create an elevator instance with the given parameters.
        /// The ID is used to uniquely identify the elevator, while the capacity and maxFloors define its operational limits.
        /// </remarks>
        public Elevator(int id, int capacity, int maxFloors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the unique identifier for the elevator.
        /// </summary>
        /// <remarks>
        /// This property represents the unique ID of the elevator.
        /// It is used to identify the elevator in the system.
        /// </remarks>
        public int Id { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets the type of the elevator.
        /// </summary>
        /// <remarks>
        /// This property represents the type of the elevator, such as "Passenger", "Freight", etc.
        /// It is used to differentiate between different elevator types in the system.
        /// </remarks>
        /// <returns>The type of the elevator as a string.</returns>
        public string ElevatorType { get { throw new NotImplementedException(); } }                

        /// <summary>
        /// Moves the elevator to a specified floor.
        /// This method is used to change the elevator's current floor to the specified floor.
        /// </summary>
        /// <param name="floor">The floor to move the elevator to.</param>
        /// <remarks>
        /// This method is used to move the elevator to a specific floor.
        /// It takes the floor number as a parameter and updates the elevator's current position.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the floor number is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is not operational.</exception>
        public void MoveToFloor(int floor)
        {
            // Logic to move the elevator to the specified floor
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds passengers to the elevator.
        /// This method is used to increase the number of passengers in the elevator.
        /// </summary>
        /// <param name="count">The number of passengers to add.</param>
        /// <remarks>
        /// This method is used to add passengers to the elevator.
        /// It takes the count of passengers as a parameter and updates the elevator's passenger count.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is full.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is full.</exception>
        public void AddPassengers(int count)
        {
            // Logic to add passengers to the elevator
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes passengers from the elevator.
        /// This method is used to decrease the number of passengers in the elevator.
        /// </summary>
        /// param name="count">The number of passengers to remove.</param>
        /// <remarks>
        /// This method is used to remove passengers from the elevator.
        /// It takes the count of passengers to remove as a parameter and updates the elevator's passenger count.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when there are not enough passengers to remove.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is negative.</exception>
        public void RemovePassengers(int count)
        {
            // Logic to remove passengers from the elevator
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the current status of the elevator.
        /// This method retrieves the current status of the elevator, including its current floor, direction, and operational state.
        /// </summary>
        /// <returns>An <see cref="ElevatorStatus"/> object representing the current status of the elevator.</returns>
        /// <remarks>
        /// This method is used to get the status of the elevator.
        /// It returns an ElevatorStatus object containing information about the elevator's current floor, movement state, and direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is not operational.</exception>       
        public ElevatorStatus GetStatus()
        {
            // Logic to get the current status of the elevator
            throw new NotImplementedException();
        }               
    }
}