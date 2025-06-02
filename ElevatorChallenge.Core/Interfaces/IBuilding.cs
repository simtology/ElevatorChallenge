namespace ElevatorChallenge.Core.Interfaces
{
    /// <summary>
    /// Interface representing a building that contains elevators.
    /// This interface defines methods for managing floors and elevators within a building.
    /// It allows adding elevators, retrieving the list of elevators, and getting the number of floors in the building.
    /// </summary>   
    public interface IBuilding
    {
        /// <summary>
        /// Adds an elevator to the building.
        /// This method allows the addition of an elevator to the building's collection.
        /// It is used to manage the elevators available in the building.
        /// </summary>
        /// <param name="elevator"></param>
        /// <remarks>
        /// This method is used to add an elevator to the building.
        /// It is part of the IBuilding interface and is implemented by the Building class.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the elevator parameter is null.</exception>
        void AddElevator(IElevator elevator);
        /// <summary>
        /// Retrieves a read-only list of elevators in the building.
        /// This method provides access to the elevators present in the building.
        /// </summary>
        /// <returns>A read-only list of elevators.</returns>
        IReadOnlyList<IElevator> GetElevators();
        /// <summary>
        /// Gets the total number of floors in the building.
        /// This method returns the number of floors available in the building.
        /// </summary>
        /// <returns>The total number of floors in the building.</returns>
        int GetNumberOfFloors();
        /// <summary>
        /// Retrieves an elevator by its unique identifier.
        /// This method allows access to a specific elevator based on its ID.
        /// </summary>
        /// <param name="elevatorId">The unique identifier of the elevator.</param>
        /// <returns>An instance of <see cref="IElevator"/> representing the elevator with the specified ID.</returns>
        /// <remarks>
        /// This method is used to retrieve an elevator from the building's collection.
        /// It takes the elevator ID as a parameter and returns the corresponding elevator instance.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the elevator with the specified ID does not exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the elevatorId parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator with the specified ID is not found.</exception>       >
        IElevator GetElevatorById(int elevatorId);
    }
}