using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Manages event subscriptions and triggering.
    /// </summary>
    [CreateAssetMenu(fileName = "Event Manager", menuName = "Event System/Event Manager")]
    public class EventManagerSO : ScriptableObject
    {
        #region Fields and Properties
        private Dictionary<string, Event> _events = new Dictionary<string, Event>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Subscribes the given subscriber to the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, string eventName, Action action)
        {
            if (!subscriber || action == null) return;
            if (!_events.ContainsKey(eventName)) _events.Add(eventName, new Event());
            _events[eventName].Subscribe(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, string eventName, Action<string> action)
        {
            if (!subscriber || action == null) return;
            if (!_events.ContainsKey(eventName)) _events.Add(eventName, new Event());
            _events[eventName].Subscribe(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, string eventName, Action<int> action)
        {
            if (!subscriber || action == null) return;
            if (!_events.ContainsKey(eventName)) _events.Add(eventName, new Event());
            _events[eventName].Subscribe(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, string eventName, Action<float> action)
        {
            if (!subscriber || action == null) return;
            if (!_events.ContainsKey(eventName)) _events.Add(eventName, new Event());
            _events[eventName].Subscribe(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, string eventName, Action<GameObject> action)
        {
            if (!subscriber || action == null) return;
            if (!_events.ContainsKey(eventName)) _events.Add(eventName, new Event());
            _events[eventName].Subscribe(subscriber, action);
        }

        /// <summary>
        /// Unsubscribes the given subscriber from the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, string eventName, Action action)
        {
            if (!subscriber || !_events.ContainsKey(eventName)) return;
            _events[eventName].Unsubscribe(subscriber, action);
        }
        /// <summary>
        /// Unsubscribes the given subscriber from the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, string eventName, Action<string> action)
        {
            if (!subscriber || !_events.ContainsKey(eventName)) return;
            _events[eventName].Unsubscribe(subscriber, action);
        }
        /// <summary>
        /// Unsubscribes the given subscriber from the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, string eventName, Action<int> action)
        {
            if (!subscriber || !_events.ContainsKey(eventName)) return;
            _events[eventName].Unsubscribe(subscriber, action);
        }
        /// <summary>
        /// Unsubscribes the given subscriber from the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, string eventName, Action<float> action)
        {
            if (!subscriber || !_events.ContainsKey(eventName)) return;
            _events[eventName].Unsubscribe(subscriber, action);
        }
        /// <summary>
        /// Unsubscribes the given subscriber from the given event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, string eventName, Action<GameObject> action)
        {
            if (!subscriber || !_events.ContainsKey(eventName)) return;
            _events[eventName].Unsubscribe(subscriber, action);
        }

        /// <summary>
        /// Triggers the given event.
        /// </summary>
        /// <param name="eventName"></param>
        public void Trigger(string eventName)
        {
            if (!_events.ContainsKey(eventName)) return;
            _events[eventName].Trigger();
        }
        /// <summary>
        /// Triggers the given event, passing in the given data.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data">A normal string, JSON data, etc.</param>
        public void Trigger(string eventName, string data)
        {
            if (!_events.ContainsKey(eventName)) return;
            _events[eventName].Trigger(data);
        }
        /// <summary>
        /// Triggers the given event, passing in the given data.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, int data)
        {
            if (!_events.ContainsKey(eventName)) return;
            _events[eventName].Trigger(data);
        }
        /// <summary>
        /// Triggers the given event, passing in the given data.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, float data)
        {
            if (!_events.ContainsKey(eventName)) return;
            _events[eventName].Trigger(data);
        }
        /// <summary>
        /// Triggers the given event, passing in the given data.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void Trigger(string eventName, GameObject data)
        {
            if (!_events.ContainsKey(eventName)) return;
            _events[eventName].Trigger(data);
        }
        #endregion
    }
}