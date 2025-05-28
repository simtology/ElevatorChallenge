namespace ElevatorChallenge.Core.Interfaces
{
    public interface IElevatorFactory
    {
        /// <summary>
        /// Creates an elevator instance based on the specified type.
        /// This is a placeholder implementation that creates a basic elevator.
        /// It can be extended to create different types of elevators in the future.
        /// </summary>
        /// <param name="type">The type of the elevator.</param>
        /// <param name="id">The unique identifier for the elevator.</param>
        /// <param name="capacity">The maximum capacity of the elevator.</param>
        /// <param name="maxFloors">The maximum number of floors the elevator can service.</param>
        /// <returns>An instance of IElevator.</returns>
        /// <remarks>
        /// This method currently creates a PlaceholderElevator instance.
        /// It can be modified to create different types of elevators based on the 'type' parameter.
        /// </remarks>
        IElevator CreateElevator(string type, int id, int capacity, int maxFloors);
    }
}