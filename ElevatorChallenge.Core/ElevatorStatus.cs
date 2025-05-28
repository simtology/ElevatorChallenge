namespace ElevatorChallenge.Core
{
    /// <summary>
    /// Represents the status of an elevator.
    /// This class contains properties that describe the current state of the elevator,
    /// including its current floor, direction of movement, whether it is moving,
    /// and the number of passengers it is carrying.
    /// </summary>
    public class ElevatorStatus
    {
        /// <summary>
        /// Gets or sets the current floor of the elevator.
        /// This property indicates the floor number where the elevator is currently located.
        /// It is an integer value representing the floor level in the building.
        /// </summary>
        public int CurrentFloor { get; init; }
        /// <summary>
        /// Gets or sets the direction of the elevator's movement.
        /// This property indicates the current direction of the elevator, such as "Up", "Down", or "None" if it is stationary.
        /// </summary>
        public string Direction { get; init; } = "None";
        /// <summary>
        /// Gets or sets a value indicating whether the elevator is currently moving.
        /// This property is a boolean value that indicates whether the elevator is in motion (true) or stationary (false).
        /// </summary>
        /// <remarks>
        /// This property is used to determine the operational state of the elevator.
        /// If true, the elevator is currently moving to a different floor; if false, it is either stationary or at its destination.
        /// </remarks>
        public bool IsMoving { get; init; }
        /// <summary>
        /// Gets or sets the number of passengers currently in the elevator.
        /// This property indicates how many passengers are currently inside the elevator.
        /// It is an integer value that helps in managing the elevator's capacity and ensuring safety.
        /// </summary>
        /// <remarks>
        /// This property is important for tracking the load of the elevator.
        /// It can be used to determine if the elevator is at capacity or if it can accept more passengers.
        /// </remarks>
        public int PassengerCount { get; init; }
    }
}