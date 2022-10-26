﻿// *************************************************************
// project:  graphql-aspnet
// --
// repo: https://github.com/graphql-aspnet
// docs: https://graphql-aspnet.github.io
// --
// License:  MIT
// *************************************************************

namespace GraphQL.AspNet.Interfaces.Subscriptions
{
    using System.Threading.Tasks;
    using GraphQL.AspNet.Execution.Subscriptions;

    /// <summary>
    /// An interface describing an object used for routing published subscription events to
    /// the recievers that need to handle them.  This object is schema agnostic and should be registered as a global
    /// singleton in a DI container.
    /// </summary>
    /// <remarks>
    /// This object is typically called by
    /// a platform dependent listener (such as a service bus client) and will route
    /// deserialized events from an event source to the connected client proxies.<br/>
    /// <b>Note:</b> In most use cases, you will NOT have to implement your own version of
    /// this object. Think twice before writing your own.
    /// </remarks>
    public interface ISubscriptionEventRouter
    {
        /// <summary>
        /// Instructs this router to raise the published event to each subscribed receiver.
        /// </summary>
        /// <param name="eventData">The data package representing a raised event.</param>
        void RaisePublishedEvent(SubscriptionEvent eventData);

        /// <summary>
        /// Instructs the router to raise any events of the supplied name to the given receiver.
        /// </summary>
        /// <param name="receiver">The receiver to receive the event data.</param>
        /// <param name="eventName">Name of the event to listen for.</param>
        void AddReceiver(ISubscriptionEventReceiver receiver, SubscriptionEventName eventName);

        /// <summary>
        /// Removes the receiver from being notified of the given event.
        /// </summary>
        /// <param name="receiver">The receiver to drop.</param>
        /// <param name="eventName">Name of the event to stop listening for.</param>
        void RemoveReceiver(ISubscriptionEventReceiver receiver, SubscriptionEventName eventName);

         /// <summary>
        /// Removes the receiver from being notified of ALL events that it may be registered to.
        /// </summary>
        /// <param name="receiver">The receiver to remove.</param>
        void RemoveReceiver(ISubscriptionEventReceiver receiver);
    }
}