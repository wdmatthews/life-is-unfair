using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Stores a dictionary of event subscribers and their action to
    /// invoke when the event is triggered.
    /// </summary>
    public class Event
    {
        #region Fields and Properties
        private Dictionary<EventSubscriber, Action> _actions = new Dictionary<EventSubscriber, Action>();
        private Dictionary<EventSubscriber, Action<string>> _actionsWithString = new Dictionary<EventSubscriber, Action<string>>();
        private Dictionary<EventSubscriber, Action<int>> _actionsWithInt = new Dictionary<EventSubscriber, Action<int>>();
        private Dictionary<EventSubscriber, Action<float>> _actionsWithFloat = new Dictionary<EventSubscriber, Action<float>>();
        private Dictionary<EventSubscriber, Action<GameObject>> _actionsWithGameObject = new Dictionary<EventSubscriber, Action<GameObject>>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Subscribes the given subscriber to this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, Action action)
        {
            if (action == null) return;
            if (_actions.ContainsKey(subscriber))
            {
                _actions[subscriber] += action;
            }
            else _actions.Add(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, Action<string> action)
        {
            if (action == null) return;
            if (_actionsWithString.ContainsKey(subscriber))
            {
                _actionsWithString[subscriber] += action;
            }
            else _actionsWithString.Add(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, Action<int> action)
        {
            if (action == null) return;
            if (_actionsWithInt.ContainsKey(subscriber))
            {
                _actionsWithInt[subscriber] += action;
            }
            else _actionsWithInt.Add(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, Action<float> action)
        {
            if (action == null) return;
            if (_actionsWithFloat.ContainsKey(subscriber))
            {
                _actionsWithFloat[subscriber] += action;
            }
            else _actionsWithFloat.Add(subscriber, action);
        }
        /// <summary>
        /// Subscribes the given subscriber to this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action">The action to invoke when the event is triggered.</param>
        public void Subscribe(EventSubscriber subscriber, Action<GameObject> action)
        {
            if (action == null) return;
            if (_actionsWithGameObject.ContainsKey(subscriber))
            {
                _actionsWithGameObject[subscriber] += action;
            }
            else _actionsWithGameObject.Add(subscriber, action);
        }

        /// <summary>
        /// Unsubscribes the given subscriber from this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, Action action)
        {
            if (!_actions.ContainsKey(subscriber)) return;
            if (action != null) _actions[subscriber] -= action;
            if (action == null || _actions[subscriber] == null)
            {
                _actions.Remove(subscriber);
            }
        }
        /// <summary>
        /// Unsubscribes the given subscriber from this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, Action<string> action)
        {
            if (!_actionsWithString.ContainsKey(subscriber)) return;
            if (action != null) _actionsWithString[subscriber] -= action;
            if (action == null || _actionsWithString[subscriber] == null)
            {
                _actionsWithString.Remove(subscriber);
            }
        }
        /// <summary>
        /// Unsubscribes the given subscriber from this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, Action<int> action)
        {
            if (!_actionsWithInt.ContainsKey(subscriber)) return;
            if (action != null) _actionsWithInt[subscriber] -= action;
            if (action == null || _actionsWithInt[subscriber] == null)
            {
                _actionsWithInt.Remove(subscriber);
            }
        }
        /// <summary>
        /// Unsubscribes the given subscriber from this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, Action<float> action)
        {
            if (!_actionsWithFloat.ContainsKey(subscriber)) return;
            if (action != null) _actionsWithFloat[subscriber] -= action;
            if (action == null || _actionsWithFloat[subscriber] == null)
            {
                _actionsWithFloat.Remove(subscriber);
            }
        }
        /// <summary>
        /// Unsubscribes the given subscriber from this event.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="action"></param>
        public void Unsubscribe(EventSubscriber subscriber, Action<GameObject> action)
        {
            if (!_actionsWithGameObject.ContainsKey(subscriber)) return;
            if (action != null) _actionsWithGameObject[subscriber] -= action;
            if (action == null || _actionsWithGameObject[subscriber] == null)
            {
                _actionsWithGameObject.Remove(subscriber);
            }
        }

        /// <summary>
        /// Triggers the event.
        /// </summary>
        public void Trigger()
        {
            // Sometimes unsubscriptions can occur while invoking an action,
            // which would cause a modification of the actions dictionary,
            // and therefore an error. Looping over the keys in the
            // dictionary prevents that issue.
            List<EventSubscriber> subscribers = new List<EventSubscriber>(_actions.Keys);
            foreach (EventSubscriber subscriber in subscribers)
            {
                if (subscriber && subscriber.gameObject) _actions[subscriber]?.Invoke();
                // Remove the subscriber if it no longer exists,
                // which could mean the GameObject was deleted or its Scene was unloaded.
                else _actions.Remove(subscriber);
            }
        }
        /// <summary>
        /// Triggers the event, passing in the given data.
        /// </summary>
        /// <param name="data">A normal string, JSON data, etc.</param>
        public void Trigger(string data)
        {
            List<EventSubscriber> subscribers = new List<EventSubscriber>(_actionsWithString.Keys);
            foreach (EventSubscriber subscriber in subscribers)
            {
                if (subscriber && subscriber.gameObject) _actionsWithString[subscriber]?.Invoke(data);
                else _actionsWithString.Remove(subscriber);
            }
        }
        /// <summary>
        /// Triggers the event, passing in the given data.
        /// </summary>
        /// <param name="data"></param>
        public void Trigger(int data)
        {
            List<EventSubscriber> subscribers = new List<EventSubscriber>(_actionsWithInt.Keys);
            foreach (EventSubscriber subscriber in subscribers)
            {
                if (subscriber && subscriber.gameObject) _actionsWithInt[subscriber]?.Invoke(data);
                else _actionsWithInt.Remove(subscriber);
            }
        }
        /// <summary>
        /// Triggers the event, passing in the given data.
        /// </summary>
        /// <param name="data"></param>
        public void Trigger(float data)
        {
            List<EventSubscriber> subscribers = new List<EventSubscriber>(_actionsWithFloat.Keys);
            foreach (EventSubscriber subscriber in subscribers)
            {
                if (subscriber && subscriber.gameObject) _actionsWithFloat[subscriber]?.Invoke(data);
                else _actionsWithFloat.Remove(subscriber);
            }
        }
        /// <summary>
        /// Triggers the event, passing in the given data.
        /// </summary>
        /// <param name="data"></param>
        public void Trigger(GameObject data)
        {
            List<EventSubscriber> subscribers = new List<EventSubscriber>(_actionsWithGameObject.Keys);
            foreach (EventSubscriber subscriber in subscribers)
            {
                if (subscriber && subscriber.gameObject) _actionsWithGameObject[subscriber]?.Invoke(data);
                else _actionsWithGameObject.Remove(subscriber);
            }
        }
        #endregion
    }
}