using ElevatorChallenge.Core.Interfaces;
using ElevatorChallenge.Core;

namespace ElevatorChallenge.Application
{
    /// <summary>
    /// ElevatorController class for managing elevator requests and statuses.
    /// This class implements the IElevatorController interface and provides methods to request elevators and get their statuses.
    /// It is a placeholder implementation that can be extended in future tasks.
    /// </summary>
    public class ElevatorController : IElevatorController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorController"/> class.
        /// This constructor takes an IElevatorDispatcher and IBuilding as parameters.
        /// It is a placeholder implementation that will be expanded in future tasks.
        /// </summary>        
        /// <param name="dispatcher"></param>
        /// <param name="building"></param>
        /// <remarks>
        /// This class is responsible for managing elevator requests and statuses.
        /// It will handle the logic for requesting elevators and retrieving their statuses.
        /// </remarks>
        public ElevatorController(IElevatorDispatcher dispatcher, IBuilding building)
        {
            // Initialize the controller with the dispatcher and building
            // This will be expanded in future tasks
        }

        /// <summary>
        /// Requests an elevator from a specific floor with a given direction and passenger count. 
        /// This method is a placeholder and will be expanded in future tasks.
        /// </summary>
        /// <param name="fromFloor">The floor from which the elevator is requested.</param>
        /// <param name="PassengerCount">The number of passengers waiting on the specified floor.</param>
        /// <param name="direction">The direction in which the elevator should move (e.g., "up" or "down").</param>
        /// <remarks>
        /// This method is used to request an elevator to pick up passengers from a specific floor.
        /// It takes the floor number, the count of passengers waiting, and the direction of travel as parameters.
        /// The direction parameter can be used to optimize the elevator's route based on the requested direction.
        /// </remarks>
        public void RequestElevator(int fromFloor, int PassengerCount, string direction)
        {
            // Logic to request an elevator based on the floor and type
            // This will be expanded in future tasks
        }

        /// <summary>
        /// Retrieves the current status of the specified elevator, including its location and operational state.
        /// </summary>
        /// <param name="elevatorId">The unique identifier of the elevator.</param>
        /// <returns>An <see cref="ElevatorStatus"/> object representing the current status of the elevator.</returns>
        /// <remarks>
        /// This method is used to get the status of a specific elevator.
        /// It returns an ElevatorStatus object containing information about the elevator's current floor, movement state, and direction.
        /// </remarks>
        public ElevatorStatus GetElevatorStatus(int elevatorId)
        {
            // Logic to get the status of a specific elevator
            // This will be expanded in future tasks
            return new ElevatorStatus
            {
                CurrentFloor = 0, // Placeholder value
                IsMoving = false, // Placeholder value
                Direction = "Up", // Placeholder value
                PassengerCount = 0 // Placeholder value
            };
        }
    }
}