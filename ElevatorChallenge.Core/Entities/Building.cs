// This file is a placeholder for the core building logic.
// It will be expanded in future tasks to include the building's properties and methods.
using ElevatorChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Represents a building with multiple floors and elevators.
    /// This class implements the IBuilding interface and provides methods to manage elevators and floors.
    /// It allows adding elevators, retrieving the list of elevators, and getting the number of floors in the building.
    /// This is a placeholder implementation that can be extended in future tasks.
    /// <remarks>
    /// This class is a placeholder for the core building logic.
    /// It will be expanded in future tasks to include the building's properties and methods.
    /// </remarks>
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
            _numberOfFloors = numberOfFloors;
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
            // Returns the total number of floors in the building.
            return _numberOfFloors;
        }
    }
}