using ElevatorChallenge.Core.Interfaces;

namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Placeholder implementation of the IElevator interface.
    /// This class serves as a basic implementation of an elevator.
    /// It can be extended in future tasks to include more functionality.
    /// </summary>
    /// <remarks>
    /// This class is a placeholder for the elevator logic.
    /// It will be expanded in future tasks to include the elevator's properties and methods.
    /// </remarks>
    public class PlaceholderElevator : IElevator
    {
        /// <summary>
        /// Gets the unique identifier for the elevator.
        /// summary>
        public int Id { get; }
        /// <summary>
        /// Gets the type of the elevator.
        /// </summary>
        /// <remarks>
        /// This property represents the type of the elevator, such as "Passenger", "Freight", etc.
        /// It is used to differentiate between different elevator types in the system.
        /// <remarks>
        public string ElevatorType { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceholderElevator"/> class.
        /// This constructor is a placeholder and can be extended in future tasks.
        /// It sets the ID and type of the elevator.        
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <remarks>
        /// This constructor initializes the elevator with a specified ID and type.
        /// It is used to create an elevator instance with the given parameters.
        /// </remarks>
        public PlaceholderElevator(int id, string type)
        {
            Id = id;
            ElevatorType = type;
        }

        // Additional properties and methods can be added here as needed.
        public void MoveToFloor(int floor)
        {
            // Placeholder implementation for moving to a specific floor.
            // This method can be expanded in future tasks to include actual logic.
            throw new NotImplementedException();
        }

        public void AddPassengers(int count)
        {
            // Placeholder implementation for adding passengers.
            // This method can be expanded in future tasks to include actual logic.
            throw new NotImplementedException();
        }

        public void RemovePassengers(int count)
        {
            // Placeholder implementation for removing passengers.
            // This method can be expanded in future tasks to include actual logic.
            throw new NotImplementedException();
        }

        public ElevatorStatus GetStatus()
        {
            // Placeholder implementation for getting the elevator status.
            // This method can be expanded in future tasks to include actual logic.
            throw new NotImplementedException();
        }
    }
}