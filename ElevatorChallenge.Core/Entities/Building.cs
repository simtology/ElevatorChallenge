using ElevatorChallenge.Core.Interfaces;

namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Represents a building with multiple floors and elevators.
    /// This class implements the IBuilding interface and provides methods to manage elevators and floors.
    /// It allows adding elevators, retrieving the list of elevators, and getting the number of floors in the building.    
    /// </summary>
    public class Building : IBuilding
    {
        /// <summary>
        /// Represents the total number of floors in the building.
        /// This field is initialized in the constructor and is used to manage the building's structure.
        /// </summary>
        private readonly int _numberOfFloors;
        /// <summary>
        /// Represents the collection of elevators in the building.
        /// This field is initialized as a list and is used to manage the elevators available in the building.
        /// </summary>
        /// <remarks>
        /// This field is a private list that holds the elevators.
        /// It is used to manage the elevators available in the building.
        /// </remarks>
        private readonly IList<IElevator> _elevators = new List<IElevator>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/> class.
        /// This constructor sets the total number of floors in the building.
        /// </summary>
        /// <param name="numberOfFloors">The total number of floors in the building.</param>
        /// <remarks>
        /// This constructor initializes the building with a specified number of floors.
        /// It is used to create a building instance with the given number of floors.
        /// </remarks>
        public Building(int numberOfFloors)
        {
            if (numberOfFloors <= 0)
            {
                throw new ArgumentException("Number of floors must be positive.", nameof(numberOfFloors));
            }
    
            _numberOfFloors = numberOfFloors;
            _elevators = new List<IElevator>();
        }

        /// <summary>
        /// Adds an elevator to the building.   
        /// This method allows the addition of an elevator to the building's collection.
        /// </summary>
        public void AddElevator(IElevator elevator)
        {
            _elevators.Add(elevator);
        }

        /// <summary>
        /// Retrieves an elevator by its unique identifier.
        /// This method allows access to a specific elevator based on its ID.
        /// </summary>
        /// <param name="elevatorId">The unique identifier of the elevator.</param>
        /// <returns>The elevator with the specified ID.</returns>
        /// <remarks>
        /// This method is used to retrieve an elevator from the building's collection.
        /// It takes the elevator ID as a parameter and returns the corresponding elevator instance.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the elevator with the specified ID does not exist.</exception>        
        /// <exception cref="InvalidOperationException">Thrown when the elevator with the specified ID does not exist.</exception>
        public IElevator GetElevatorById(int elevatorId)
        {
            // Retrieves an elevator by its unique identifier.
            // This method allows access to a specific elevator based on its ID.
            if (elevatorId < 0)
            {
                throw new ArgumentException("Elevator ID cannot be negative.", nameof(elevatorId));
            }

            return _elevators.FirstOrDefault(e => e.Id == elevatorId) ?? throw new InvalidOperationException($"Elevator with ID {elevatorId} not found.");
        }

        /// <summary>
        /// Retrieves a read-only list of elevators in the building.
        /// This method provides access to the elevators present in the building.
        /// </summary>
        /// <returns>A read-only list of elevators.</returns>
        public IReadOnlyList<IElevator> GetElevators()
        {
            // Returns a read-only list of elevators in the building.
            return _elevators.AsReadOnly();
        }

        /// <summary>
        /// Gets the total number of floors in the building.
        /// This method returns the number of floors available in the building.
        /// </summary>
        /// <returns>The total number of floors in the building.</returns>
        public int GetNumberOfFloors()
        {           
            return _numberOfFloors;
        }        
    }
}