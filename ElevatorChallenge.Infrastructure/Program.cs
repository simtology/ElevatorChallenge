using ElevatorChallenge.Application;
using ElevatorChallenge.Core;
using ElevatorChallenge.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ElevatorChallenge.Infrastructure
{
    /// <summary>
    /// Main entry point for the Elevator application.
    /// This program sets up the dependency injection container and initializes the building with elevators.
    /// </summary>
    /// <remarks>
    /// This is a placeholder for the main loop and will be expanded in future tasks.
    /// </remarks>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Dependency Injection
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<IBuilding, Building>(sp => new Building(10)); // Building with 10 floors
            services.AddSingleton<IElevatorDispatcher, NearestElevatorDispatcher>();
            services.AddSingleton<IElevatorController, ElevatorController>();
            services.AddSingleton<IElevatorFactory, ElevatorFactory>();

            // Register two elevator instances (Passenger and Freight)
            services.AddSingleton<IElevator>(sp =>
                sp.GetRequiredService<IElevatorFactory>().CreateElevator(nameof(PlaceholderElevator ), 1, 10, 10)); // Passenger elevator
            services.AddSingleton<IElevator>(sp =>
                sp.GetRequiredService<IElevatorFactory>().CreateElevator(nameof(PlaceholderElevator ), 2, 100, 10)); // Freight elevator

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve and initialize building
            var building = serviceProvider.GetRequiredService<IBuilding>();
            var elevators = serviceProvider.GetServices<IElevator>();

            foreach (var elevator in elevators)
            {
                building.AddElevator(elevator);
            }

            // Resolve controller
            var controller = serviceProvider.GetRequiredService<IElevatorController>();

            // Placeholder main loop (to be expanded in future tasks)
            Console.WriteLine("Elevator Simulation Starting...");
            Console.WriteLine("Elevator Simulation Initialized with DI");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}