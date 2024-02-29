Event Aggregator Design Pattern Implementation for Unity 3D

This repository contains an implementation of the Event Aggregator design pattern for Unity 3D. The Event Aggregator pattern facilitates the communication between various components of a system without directly coupling them, thus promoting a more modular and decoupled architecture.

Components:
1- AbstractEventAggregator:
Abstract class providing the interface for event aggregation functionalities.
Includes methods for checking if a handler exists for a specific message type, subscribing to events, and publishing messages.

2- EventAggregator:
Concrete implementation of the Event Aggregator pattern.
Utilizes weak references to handle event handlers, allowing for automatic cleanup of unused handlers.
Provides methods for subscribing to and unsubscribing from events, as well as publishing messages.
Implements singleton pattern for easy access throughout the application.

3-IHandle and IHandle<TMessage>:
Interfaces defining the contract for classes that handle specific types of messages.
Allows for the implementation of message handlers in a type-safe manner.

Usage:
Subscribing to Events: Components can subscribe to specific event types by implementing the IHandle<TMessage> interface and passing themselves as subscribers to the Subscribe method of the EventAggregator instance.

Publishing Events: Events can be published using the Publish method of the EventAggregator instance. Subscribed components implementing the corresponding IHandle<TMessage> interface will receive and handle these events.

Unsubscribing from Events: Components can unsubscribe from events by calling the Unsubscribe method of the EventAggregator instance with themselves as the argument.

Singleton Access:
The EventAggregator class implements the singleton pattern to provide a single, global instance throughout the application. This ensures easy access to the event aggregation functionalities from any part of the codebase.

Note:
This implementation promotes loose coupling and flexibility in managing inter-component communication within Unity 3D projects. It allows for efficient event handling while maintaining a clean and modular codebase.

Feel free to explore and integrate this Event Aggregator implementation into your Unity projects to enhance code organization and maintainability. Contributions and feedback are welcome!

Disclaimer: This implementation is inspired by common design patterns and adapted for Unity 3D development. It aims to provide a robust solution for event-driven communication within Unity projects.
