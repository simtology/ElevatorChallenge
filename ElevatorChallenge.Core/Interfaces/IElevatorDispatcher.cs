namespace ElevatorChallenge.Core.Interfaces
{
    /// <summary>
    /// Interface for an elevator dispatcher.
    /// This interface defines the method for dispatching an elevator to handle a floor request.
    /// </summary>
    /// <remarks>
    /// This interface is responsible for managing the logic of selecting the appropriate elevator based on the floor request.
    /// It will be implemented by classes that handle the dispatching of elevators in the system.
    /// </remarks>
    public interface IElevatorDispatcher
    {
        /// <summary>
        /// Dispatches an elevator to handle a floor request.
        /// </summary>
        /// <param name="request">The floor request containing the requested floor and elevator type.</param>
        /// <returns>An instance of <see cref="IElevator"/> representing the dispatched elevator.</returns>
        /// <remarks>
        /// This method is used to find and return the nearest elevator that can handle the specified floor request.
        /// It takes a FloorRequest object as a parameter, which contains the details of the request such as the requested floor and the type of elevator needed.
        /// </remarks>
        IElevator DispatchElevator(FloorRequest request);
    }
}