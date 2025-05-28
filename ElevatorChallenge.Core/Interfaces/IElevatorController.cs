namespace ElevatorChallenge.Core.Interfaces
{
    /// <summary>
    /// Interface for the Elevator Controller.
    /// This interface defines the methods for controlling elevator operations.
    /// </summary>
    public interface IElevatorController
    {
        /// <summary>
        /// Requests an elevator to pick up passengers from a specified floor.
        /// </summary>
        /// <param name="fromFloor">The floor from which the elevator should pick up passengers.</param>
        /// <param name="PassengerCount">The number of passengers waiting on the specified floor.</param>
        /// <param name="direction">The direction in which the elevator should move (e.g., "up" or "down").</param>
        /// <remarks>
        /// This method is used to request an elevator to pick up passengers from a specific floor.
        /// It takes the floor number, the count of passengers waiting, and the direction of travel as parameters.
        /// The direction parameter can be used to optimize the elevator's route based on the requested direction.
        /// </remarks>
        void RequestElevator(int fromFloor, int PassengerCount, string direction);

        /// <summary>
        /// Retrieves the current status of the specified elevator, including its location and operational state.
        /// </summary>
        /// <param name="elevatorId">The unique identifier of the elevator.</param>
        /// <returns>An <see cref="ElevatorStatus"/> object representing the current status of the elevator.</returns>
        ElevatorStatus GetElevatorStatus(int elevatorId);
    }
}