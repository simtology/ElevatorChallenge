namespace ElevatorChallenge.Core.Interfaces
{
    /// <summary>
    /// Interface for an elevator.
    /// This interface defines the properties and methods that an elevator must implement.
    /// It includes properties for the elevator's ID and type.  
    /// This interface can be extended in the future to include more functionality.
    /// </summary>
    /// <remarks>
    /// This interface is a placeholder for the elevator logic.
    /// It will be expanded in future tasks to include the elevator's properties and methods.
    /// </remarks>
    public interface IElevator
    {
        /// <summary>
        /// Gets the unique identifier for the elevator.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Gets the type of the elevator.
        /// </summary>
        string ElevatorType { get; }
        /// <summary>
        /// Moves the elevator to the specified floor.
        /// </summary>
        /// <param name="floor">The floor to move the elevator to.</param>
        /// <remarks>
        /// This method is used to move the elevator to a specific floor.
        /// It takes the floor number as a parameter and updates the elevator's current position.
        /// /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the floor number is invalid.</exception>
        void MoveToFloor(int floor);
        /// <summary>
        /// Adds passengers to the elevator.
        /// </summary>
        /// <param name="count">The number of passengers to add.</param>
        /// <remarks>
        /// This method is used to add passengers to the elevator.
        /// It takes the count of passengers as a parameter and updates the elevator's passenger count.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is full.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator is full.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is negative.</exception>
        void AddPassengers(int count);
        /// <summary>
        /// Removes passengers from the elevator.
        /// </summary>
        /// <param name="count">The number of passengers to remove.</param>
        /// <remarks>
        /// This method is used to remove passengers from the elevator.
        /// It takes the count of passengers to remove as a parameter and updates the elevator's passenger count.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when there are not enough passengers to remove.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is negative.</exception>        
        void RemovePassengers(int count);
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
        ElevatorStatus GetStatus();  
    }
}