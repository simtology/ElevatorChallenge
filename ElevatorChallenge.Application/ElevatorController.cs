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
        private readonly IElevatorDispatcher _dispatcher;
        private readonly IBuilding _building;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorController"/> class.
        /// This constructor takes an IElevatorDispatcher and IBuilding as parameters.
        /// It is a placeholder implementation that will be expanded in future tasks.
        /// </summary>        
        /// <param name="dispatcher">The dispatcher responsible for managing elevator requests.</param>
        /// <param name="building">The building where the elevators are located.</param>
        /// <remarks>
        /// This class is responsible for managing elevator requests and statuses.
        /// It will handle the logic for requesting elevators and retrieving their statuses.
        /// </remarks>
        public ElevatorController(IElevatorDispatcher dispatcher, IBuilding building)
        {
            // Initialize the controller with the dispatcher and building           
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _building = building ?? throw new ArgumentNullException(nameof(building));
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified floor is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown when the direction is not valid.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the dispatcher or building is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator cannot be dispatched.</exception>
        public void RequestElevator(int fromFloor, int passengerCount, string direction)
        {
            // Logic to request an elevator based on the floor and type
            if (fromFloor < 1 || fromFloor >= _building.GetNumberOfFloors())
            {
                throw new ArgumentException("Invalid floor.", nameof(fromFloor));
            }

            if (passengerCount < 0)
            {
                throw new ArgumentException("Passenger count cannot be negative.", nameof(passengerCount));
            }

            if (direction != "Up" && direction != "Down")
            {
                throw new ArgumentException("Direction must be 'Up' or 'Down'.", nameof(direction));
            }

            var request = new FloorRequest
            {
                Floor = fromFloor,
                PassengerCount = passengerCount,
                Direction = direction
            };

            var elevator = _dispatcher.DispatchElevator(request);

            elevator.MoveToFloor(fromFloor);
            elevator.AddPassengers(passengerCount);
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
        /// <exception cref="ArgumentException">Thrown when the elevator ID is not found.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator with the specified ID does not exist.</exception>
        public ElevatorStatus GetElevatorStatus(int elevatorId)
        {
            if (elevatorId < 0)
            {
                throw new InvalidOperationException("Invalid elevator ID.");
            }

            var elevator = _building.GetElevatorById(elevatorId);

            if (elevator == null)
            {
                throw new ArgumentException($"No elevator found with ID {elevatorId}.");
            }

            return elevator.GetStatus();
        }
    }
}