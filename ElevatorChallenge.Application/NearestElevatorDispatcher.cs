using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;

namespace ElevatorChallenge.Application
{
    /// <summary>
    /// Dispatcher class for managing elevator requests.
    /// This implementation finds the nearest elevator based on the request.
    /// It is a placeholder implementation that can be extended in future tasks.
    /// </summary>
    /// <remarks>
    /// This class implements the IElevatorDispatcher interface and provides a method to dispatch elevators based on floor requests.
    /// The logic to find the nearest elevator will be implemented in future tasks.
    /// The constructor initializes the dispatcher with a building instance, which can be used to access elevator information.
    /// </remarks>
    public class NearestElevatorDispatcher : IElevatorDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NearestElevatorDispatcher"/> class.
        ///  This constructor is a placeholder and will be expanded in future tasks.
        /// </summary>
        /// <param name="building">The building instance containing elevators and floors.</param>
        /// <remarks>
        /// This constructor initializes the dispatcher with a building instance.
        /// It is used to access the elevators and their statuses for dispatching purposes.
        /// </remarks>
        public NearestElevatorDispatcher(IBuilding building)
        {
        }

        /// <summary>
        /// Dispatches an elevator based on the specified floor request.    
        /// This is a placeholder implementation that will be expanded in future tasks.
        /// </summary>
        /// <param name="request">The floor request containing the requested floor and elevator type.</param>
        /// <returns>An instance of <see cref="IElevator"/> representing the nearest elevator.</returns>
        /// <remarks>
        /// This method is responsible for finding the nearest elevator that can handle the specified floor request.
        /// It takes a FloorRequest object as a parameter, which contains the details of the request such as the requested floor and the type of elevator needed.
        /// The logic to find the nearest elevator will be implemented in future tasks.
        /// </remarks>
        public IElevator DispatchElevator(FloorRequest request)
        {
            // Logic to find the nearest elevator of the specified type
            // This will be expanded in future tasks
            return null; // Placeholder return value
        }
    }
}