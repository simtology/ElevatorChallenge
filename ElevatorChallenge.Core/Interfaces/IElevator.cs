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
    }
}