namespace ElevatorChallenge.Core
{   
    /// <summary>
    /// Represents a request for an elevator to service a specific floor.
    /// Contains the floor number, the number of passengers, and the direction of travel.
    /// This class is used to encapsulate the details of a floor request in the elevator system.
    /// The FloorRequest class is used to pass information about the requested floor, the number of passengers, and the direction of travel.
    /// This class is essential for the elevator dispatching logic, allowing the system to determine which elevator should respond to the request.
    /// The FloorRequest class is part of the ElevatorChallenge.Core namespace and is used throughout the application to handle elevator requests.
    /// </summary>
    public class FloorRequest
    {
        /// <summary>
        /// Gets or sets the floor number for the elevator request.
        /// This property indicates the floor where the elevator is requested to go.
        /// It is an integer value representing the floor level in the building.        
        /// </summary>
        /// <remarks>
        /// The Floor property is used to specify the target floor for the elevator request.
        /// It is essential for the elevator system to know which floor the passengers are waiting on,
        /// so that it can dispatch the appropriate elevator to that location.
        /// This property is part of the FloorRequest class, which encapsulates all necessary information for an elevator request.
        /// </remarks>
        public int Floor { get; set; }
        /// <summary>
        /// Gets or sets the number of passengers requesting the elevator.
        /// This property indicates how many passengers are waiting for the elevator on the requested floor.
        /// It is an integer value that helps the elevator system determine the capacity needed for the request.        
        /// </summary>
        /// <remarks>
        /// The PassengerCount property is used to specify how many passengers are waiting for the elevator on the requested floor.
        /// This information is crucial for the elevator system to manage its capacity and ensure that it can accommodate the waiting passengers.
        /// It is part of the FloorRequest class, which contains all the necessary details for processing an elevator request.
        /// </remarks>
        public int PassengerCount { get; set; }
        /// <summary>
        /// Gets or sets the direction of travel for the elevator request.
        /// This property indicates the desired direction of travel for the elevator, such as "Up" or "Down".
        /// It is a string value that helps the elevator system understand the intended movement of the elevator in response to the request.
        /// </summary>
        /// <remarks>
        /// The Direction property is used to specify the direction in which the elevator should move to service the request.
        /// This information is essential for the elevator system to optimize its routing and ensure efficient service.
        /// It is part of the FloorRequest class, which encapsulates all necessary information for an elevator request.
        /// </remarks>
        public string Direction { get; set; } = "Up";
    }    
}