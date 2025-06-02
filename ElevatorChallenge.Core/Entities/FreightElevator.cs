using ElevatorChallenge.Core.Interfaces;

namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Represents a freight elevator in the elevator system.
    /// This elevator is designed to carry goods and has specific restrictions on floors it can access.
    /// It implements the IElevator interface and provides methods to manage the elevator's state and operations.
    /// </summary>
    public class FreightElevator : IElevator
    {
        private readonly int _id;
        private readonly int _weightCapacity;
        private readonly int _maxFloors;
        private readonly List<int> _restrictedFloors = new List<int> { 5 }; // Example of a restricted floor for freight elevators
        private int _currentFloor = 1;
        private int _currentWeight;
        private string _direction = "None";
        private bool _isMoving;

        /// <summary>
        /// Initializes a new instance of the <see cref="FreightElevator"/> class.
        /// This constructor sets the ID, weight capacity, and maximum number of floors for the freight elevator.
        /// </summary>
        /// <param name="id">The unique identifier for the elevator.</param>
        /// <param name="weightCapacity">The maximum weight capacity the elevator can carry.</param>
        /// <param name="maxFloors">The maximum number of floors the elevator can service.</param>
        /// <remarks>
        /// This constructor initializes the freight elevator with a specified ID, weight capacity, and maximum number of floors.
        /// It is used to create a freight elevator instance with the given parameters.
        /// The ID is used to uniquely identify the elevator, while the weight capacity and maxFloors define its operational limits.
        /// The freight elevator has specific restrictions on which floors it can access, such as not being able to access the 5th floor.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when weight capacity or max floors are not positive.</exception>       
        public FreightElevator(int id, int weightCapacity, int maxFloors)
        {
            if (weightCapacity <= 0)
            {
                throw new ArgumentException("Weight capacity must be positive.", nameof(weightCapacity));
            }

            if (maxFloors <= 0)
            {
                throw new ArgumentException("Max floors must be positive.", nameof(maxFloors));
            }

            _id = id;
            _weightCapacity = weightCapacity;
            _maxFloors = maxFloors;
        }

        /// <summary>
        /// Gets the unique identifier for the freight elevator.
        /// </summary>
        /// <remarks>
        /// This property represents the unique ID of the freight elevator.
        /// It is used to identify the elevator in the system.
        /// </remarks>
        public int Id { get { return _id; } }

        /// <summary>
        /// Gets the type of the elevator.
        /// </summary>
        /// <remarks>
        /// This property represents the type of the elevator, which is "FreightElevator" in this case.
        /// It is used to differentiate between different elevator types in the system.
        /// </remarks>
        public string ElevatorType { get { return nameof(FreightElevator); } }

        /// <summary>
        /// Moves the freight elevator to a specified floor.
        /// This method checks if the requested floor is valid and not restricted for freight elevators.
        /// </summary>
        /// <param name="floor">The floor to which the elevator should move.</param>
        /// <remarks>
        /// This method is used to change the freight elevator's current floor to the specified floor.
        /// It takes the floor number as a parameter and updates the elevator's current position.
        /// It also checks if the requested floor is within the valid range and not restricted for freight elevators.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the floor number is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the elevator cannot access the specified floor.</exception>
        public void MoveToFloor(int floor)
        {
            if (floor < 1 || floor > _maxFloors)
            {
                throw new ArgumentException($"Floor must be between 1 and {_maxFloors}.", nameof(floor));
            }

            if (_restrictedFloors.Contains(floor))
            {
                throw new InvalidOperationException($"Freight elevator cannot access floor {floor}.");
            }

            _isMoving = true;
            _direction = floor > _currentFloor ? "Up" : floor < _currentFloor ? "Down" : "None";
            _currentFloor = floor;
            _isMoving = false;
        }

        /// <summary>
        /// Adds passengers to the freight elevator.
        /// This method checks if the weight of the passengers exceeds the elevator's weight capacity.
        /// </summary>
        /// <param name="weight">The weight of the passengers to be added.</param>
        /// <remarks>
        /// This method is used to increase the current weight of passengers in the freight elevator.
        /// It takes the weight of the passengers as a parameter and updates the elevator's current weight.
        /// It also checks if the total weight exceeds the elevator's weight capacity.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the weight is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when adding passengers exceeds the weight capacity.</exception>
        public void AddPassengers(int weight)
        {
            if (weight < 0)
            {
                throw new ArgumentException("Weight cannot be negative.", nameof(weight));
            }

            if (_currentWeight + weight > _weightCapacity)
            {
                throw new InvalidOperationException("Exceeds weight capacity.");
            }

            _currentWeight += weight;
        }

        /// <summary>
        /// Removes passengers from the freight elevator.
        /// This method checks if the weight to be removed is valid and does not exceed the current weight.
        /// </summary>
        /// <param name="weight">The weight of the passengers to be removed.</param>
        /// <remarks>
        /// This method is used to decrease the current weight of passengers in the freight elevator.
        /// It takes the weight of the passengers to be removed as a parameter and updates the elevator's current weight.
        /// It also checks if the weight to be removed is valid and does not exceed the current weight.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the weight is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when removing passengers exceeds the current weight.</exception>
        public void RemovePassengers(int weight)
        {
            if (weight < 0)
            {
                throw new ArgumentException("Weight cannot be negative.", nameof(weight));
            }

            if (_currentWeight - weight < 0)
            {
                throw new InvalidOperationException("Cannot remove more weight than present.");
            }

            _currentWeight -= weight;
        }

        /// <summary>
        /// Gets the current status of the freight elevator.
        /// This method retrieves the current floor, direction, movement state, and passenger count of the elevator.
        /// </summary>
        /// <returns>An <see cref="ElevatorStatus"/> object representing the current status of the elevator.</returns>
        /// <remarks>
        /// This method is used to get the status of the freight elevator.
        /// It returns an ElevatorStatus object containing information about the elevator's current floor, direction, movement state, and passenger count.
        /// The ElevatorStatus object can be used to monitor the elevator's operational state and current position.
        /// </remarks>
        public ElevatorStatus GetStatus()
        {
            return new ElevatorStatus
            {
                CurrentFloor = _currentFloor,
                Direction = _direction,
                IsMoving = _isMoving,
                PassengerCount = _currentWeight
            };
        }
    }
}