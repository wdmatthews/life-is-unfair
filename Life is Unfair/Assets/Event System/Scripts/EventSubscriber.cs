using System;
using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Provides a MonoBehaviour interface for subscribing to events.
    /// Put this component on any GameObject that needs to subscribe to or trigger events,
    /// then reference this component to use its methods.
    /// </summary>
    [AddComponentMenu("Event System/Event Subscriber")]
    [DisallowMultipleComponent]
    public class EventSubscriber : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField] private EventManagerSO _eventManager = null;
        #endregion

        #region Public Methods
        /// <summary>
        /// Subscribes to the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(string eventName, Action action) => _eventManager?.Subscribe(this, eventName, action);
        /// <summary>
        /// Subscribes to the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(string eventName, Action<string> action) => _eventManager?.Subscribe(this, eventName, action);
        /// <summary>
        /// Subscribes to the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(string eventName, Action<int> action) => _eventManager?.Subscribe(this, eventName, action);
        /// <summary>
        /// Subscribes to the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(string eventName, Action<float> action) => _eventManager?.Subscribe(this, eventName, action);
        /// <summary>
        /// Subscribes to the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(string eventName, Action<GameObject> action) => _eventManager?.Subscribe(this, eventName, action);

        /// <summary>
        /// Unsubscribes from the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(string eventName, Action action) => _eventManager?.Unsubscribe(this, eventName, action);
        /// <summary>
        /// Unsubscribes from the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(string eventName, Action<string> action) => _eventManager?.Unsubscribe(this, eventName, action);
        /// <summary>
        /// Unsubscribes from the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(string eventName, Action<int> action) => _eventManager?.Unsubscribe(this, eventName, action);
        /// <summary>
        /// Unsubscribes from the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(string eventName, Action<float> action) => _eventManager?.Unsubscribe(this, eventName, action);
        /// <summary>
        /// Unsubscribes from the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(string eventName, Action<GameObject> action) => _eventManager?.Unsubscribe(this, eventName, action);

        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        public void Trigger(string eventName) => _eventManager?.Trigger(eventName);
        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data">A normal string, JSON data, etc.</param>
        public void Trigger(string eventName, string data) => _eventManager?.Trigger(eventName, data);
        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, int data) => _eventManager?.Trigger(eventName, data);
        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, float data) => _eventManager?.Trigger(eventName, data);
        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, GameObject data) => _eventManager?.Trigger(eventName, data);
        #endregion
    }
} 